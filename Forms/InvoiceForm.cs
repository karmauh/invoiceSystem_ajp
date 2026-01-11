using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceSystem.Data;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Text.Json;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;

namespace InvoiceSystem.Forms
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT id, name FROM contractors";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbContractor.Items.Add(new
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name")
                        });
                    }
                }
            }

            cmbContractor.DisplayMember = "Name";
            cmbCurrency.SelectedIndex = 0;
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (cmbCurrency.SelectedItem == null)
            {
                MessageBox.Show("Wybierz walutę");
                return;
            }
            if (cmbContractor.SelectedItem == null)
            {
                MessageBox.Show("Wybierz kontrahenta");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                MessageBox.Show("Wprowadź numer faktury");
                return;
            }
            if (!decimal.TryParse(txtExchangeRate.Text, out decimal exchangeRate))
            {
                MessageBox.Show("Nieprawidłowy kurs waluty");
                return;
            }

            string invoiceNumber = txtInvoiceNumber.Text;
            DateTime issueDate = dtIssueDate.Value;
            string currency = cmbCurrency.SelectedItem.ToString();

            dynamic contractor = cmbContractor.SelectedItem;
            int contractorId = contractor.Id;

            CalculateTotals(out decimal totalNet, out decimal totalGross);
            decimal totalPln = totalGross * exchangeRate;

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO invoices 
        (invoice_number, issue_date, currency, exchange_rate, total_net, total_gross, total_pln, user_id, contractor_id)
        VALUES
        (@number, @date, @currency, @rate, @net, @gross, @pln, @user, @contractor)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@number", invoiceNumber);
                    command.Parameters.AddWithValue("@date", issueDate);
                    command.Parameters.AddWithValue("@currency", currency);
                    command.Parameters.AddWithValue("@rate", exchangeRate);
                    command.Parameters.AddWithValue("@net", totalNet);
                    command.Parameters.AddWithValue("@gross", totalGross);
                    command.Parameters.AddWithValue("@pln", totalPln);
                    command.Parameters.AddWithValue("@user", 1);
                    command.Parameters.AddWithValue("@contractor", contractorId);

                    command.ExecuteNonQuery();
                    long invoiceId = command.LastInsertedId;
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        if (row.Cells["Description"].Value == null)
                            continue;

                        string description = row.Cells["Description"].Value.ToString();
                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                        decimal unitPrice = decimal.Parse(row.Cells["UnitPrice"].Value.ToString());
                        decimal net = decimal.Parse(row.Cells["NetValue"].Value.ToString());
                        decimal gross = decimal.Parse(row.Cells["GrossValue"].Value.ToString());

                        string itemQuery = @"INSERT INTO invoice_items
    (invoice_id, description, quantity, unit_price, net_value, gross_value)
    VALUES
    (@invoice, @desc, @qty, @price, @net, @gross)";

                        using (MySqlCommand itemCmd = new MySqlCommand(itemQuery, connection))
                        {
                            itemCmd.Parameters.AddWithValue("@invoice", invoiceId);
                            itemCmd.Parameters.AddWithValue("@desc", description);
                            itemCmd.Parameters.AddWithValue("@qty", quantity);
                            itemCmd.Parameters.AddWithValue("@price", unitPrice);
                            itemCmd.Parameters.AddWithValue("@net", net);
                            itemCmd.Parameters.AddWithValue("@gross", gross);
                            itemCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Faktura zapisana");
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvItems.Rows[e.RowIndex];

                if (row.Cells["Quantity"].Value == null || row.Cells["UnitPrice"].Value == null)
                    return;

                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                decimal unitPrice = decimal.Parse(row.Cells["UnitPrice"].Value.ToString());

                decimal net = quantity * unitPrice;
                decimal gross = net * 1.23m;

                row.Cells["NetValue"].Value = net;
                row.Cells["GrossValue"].Value = gross;
            }
            catch
            {
            }
        }
        private void CalculateTotals(out decimal totalNet, out decimal totalGross)
        {
            totalNet = 0;
            totalGross = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells["NetValue"].Value == null || row.Cells["GrossValue"].Value == null)
                    continue;

                totalNet += decimal.Parse(row.Cells["NetValue"].Value.ToString());
                totalGross += decimal.Parse(row.Cells["GrossValue"].Value.ToString());
            }
        }
        private async void btnGetRate_Click(object sender, EventArgs e)
        {
            if (cmbCurrency.SelectedItem == null)
            {
                MessageBox.Show("Wybierz walutę");
                return;
            }

            string currency = cmbCurrency.SelectedItem.ToString();
            string url = $"https://api.nbp.pl/api/exchangerates/rates/A/{currency}/?format=json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);

                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        JsonElement root = doc.RootElement;
                        JsonElement rates = root.GetProperty("rates");
                        JsonElement rate = rates[0].GetProperty("mid");

                        txtExchangeRate.Text = rate.GetDecimal().ToString(System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nie udało się pobrać kursu z NBP");
            }
        }
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (GlobalFontSettings.FontResolver == null)
            {
                GlobalFontSettings.FontResolver = new CustomFontResolver();
            }

            if (dgvItems.Rows.Count <= 1)
            {
                MessageBox.Show("Faktura nie zawiera żadnych pozycji");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Pliki PDF (*.pdf)|*.pdf";
            dialog.FileName = "faktura.pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            Document document = new Document();
            document.Styles["Normal"].Font.Name = "Arial";
            Section section = document.AddSection();

            section.AddParagraph("Faktura")
                .Format.Font.Size = 16;

            section.AddParagraph($"Numer faktury: {txtInvoiceNumber.Text}");
            section.AddParagraph($"Data wystawienia: {dtIssueDate.Value:yyyy-MM-dd}");
            section.AddParagraph($"Waluta: {cmbCurrency.SelectedItem}");
            section.AddParagraph($"Kurs: {txtExchangeRate.Text}");

            section.AddParagraph(" ");

            Table table = section.AddTable();
            table.Borders.Width = 0.75;

            table.AddColumn("6cm");
            table.AddColumn("2cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");
            table.AddColumn("3cm");

            Row header = table.AddRow();
            header.Cells[0].AddParagraph("Opis");
            header.Cells[1].AddParagraph("Ilość");
            header.Cells[2].AddParagraph("Cena");
            header.Cells[3].AddParagraph("Netto");
            header.Cells[4].AddParagraph("Brutto");

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                Row r = table.AddRow();
                r.Cells[0].AddParagraph(row.Cells["Description"]?.Value?.ToString() ?? "");
                r.Cells[1].AddParagraph(row.Cells["Quantity"]?.Value?.ToString() ?? "0");
                r.Cells[2].AddParagraph(row.Cells["UnitPrice"]?.Value?.ToString() ?? "0");
                r.Cells[3].AddParagraph(row.Cells["NetValue"]?.Value?.ToString() ?? "0");
                r.Cells[4].AddParagraph(row.Cells["GrossValue"]?.Value?.ToString() ?? "0");
            }

            CalculateTotals(out decimal totalNet, out decimal totalGross);
            decimal exchangeRate = decimal.Parse(
                txtExchangeRate.Text,
                System.Globalization.CultureInfo.InvariantCulture
            );

            decimal totalPln = totalGross * exchangeRate;

            section.AddParagraph(" ");
            section.AddParagraph($"Suma netto: {totalNet}");
            section.AddParagraph($"Suma brutto: {totalGross}");
            section.AddParagraph($"Suma w PLN: {totalPln}");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(dialog.FileName);

            MessageBox.Show("Plik PDF został zapisany");
        }
    }
}
