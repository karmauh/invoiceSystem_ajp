namespace InvoiceSystem.Forms
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtInvoiceNumber = new TextBox();
            label2 = new Label();
            dtIssueDate = new DateTimePicker();
            label3 = new Label();
            cmbCurrency = new ComboBox();
            label4 = new Label();
            txtExchangeRate = new TextBox();
            label5 = new Label();
            cmbContractor = new ComboBox();
            btnSaveInvoice = new Button();
            dgvItems = new DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            NetValue = new DataGridViewTextBoxColumn();
            GrossValue = new DataGridViewTextBoxColumn();
            btnGetRate = new Button();
            btnExportPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Numer faktury";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(12, 27);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(191, 23);
            txtInvoiceNumber.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 2;
            label2.Text = "Data wystawienia";
            // 
            // dtIssueDate
            // 
            dtIssueDate.Location = new Point(12, 82);
            dtIssueDate.Name = "dtIssueDate";
            dtIssueDate.Size = new Size(191, 23);
            dtIssueDate.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 124);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "Waluta";
            // 
            // cmbCurrency
            // 
            cmbCurrency.FormattingEnabled = true;
            cmbCurrency.Items.AddRange(new object[] { "EUR", "USD", "GBP" });
            cmbCurrency.Location = new Point(12, 142);
            cmbCurrency.Name = "cmbCurrency";
            cmbCurrency.Size = new Size(191, 23);
            cmbCurrency.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 177);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 6;
            label4.Text = "Kurs waluty";
            // 
            // txtExchangeRate
            // 
            txtExchangeRate.Location = new Point(12, 195);
            txtExchangeRate.Name = "txtExchangeRate";
            txtExchangeRate.Size = new Size(66, 23);
            txtExchangeRate.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 231);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 8;
            label5.Text = "Kontrahent";
            // 
            // cmbContractor
            // 
            cmbContractor.FormattingEnabled = true;
            cmbContractor.Location = new Point(12, 249);
            cmbContractor.Name = "cmbContractor";
            cmbContractor.Size = new Size(191, 23);
            cmbContractor.TabIndex = 9;
            // 
            // btnSaveInvoice
            // 
            btnSaveInvoice.Location = new Point(12, 278);
            btnSaveInvoice.Name = "btnSaveInvoice";
            btnSaveInvoice.Size = new Size(191, 33);
            btnSaveInvoice.TabIndex = 10;
            btnSaveInvoice.Text = "Zapisz fakturę";
            btnSaveInvoice.UseVisualStyleBackColor = true;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { Description, Quantity, UnitPrice, NetValue, GrossValue });
            dgvItems.Dock = DockStyle.Right;
            dgvItems.Location = new Point(209, 0);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(544, 360);
            dgvItems.TabIndex = 11;
            dgvItems.CellEndEdit += dgvItems_CellEndEdit;
            // 
            // Description
            // 
            Description.HeaderText = "Opis";
            Description.Name = "Description";
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Ilość";
            Quantity.Name = "Quantity";
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "Cena jednostkowa";
            UnitPrice.Name = "UnitPrice";
            // 
            // NetValue
            // 
            NetValue.HeaderText = "Netto";
            NetValue.Name = "NetValue";
            NetValue.ReadOnly = true;
            // 
            // GrossValue
            // 
            GrossValue.HeaderText = "Brutto";
            GrossValue.Name = "GrossValue";
            GrossValue.ReadOnly = true;
            // 
            // btnGetRate
            // 
            btnGetRate.Location = new Point(84, 195);
            btnGetRate.Name = "btnGetRate";
            btnGetRate.Size = new Size(121, 23);
            btnGetRate.TabIndex = 12;
            btnGetRate.Text = "Pobierz kurs z NBP";
            btnGetRate.UseVisualStyleBackColor = true;
            btnGetRate.Click += btnGetRate_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(12, 317);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(191, 33);
            btnExportPdf.TabIndex = 13;
            btnExportPdf.Text = "Eksportuj do PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 360);
            Controls.Add(btnExportPdf);
            Controls.Add(btnGetRate);
            Controls.Add(dgvItems);
            Controls.Add(btnSaveInvoice);
            Controls.Add(cmbContractor);
            Controls.Add(label5);
            Controls.Add(txtExchangeRate);
            Controls.Add(label4);
            Controls.Add(cmbCurrency);
            Controls.Add(label3);
            Controls.Add(dtIssueDate);
            Controls.Add(label2);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(label1);
            Name = "InvoiceForm";
            Text = "Faktura";
            Load += InvoiceForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtInvoiceNumber;
        private Label label2;
        private DateTimePicker dtIssueDate;
        private Label label3;
        private ComboBox cmbCurrency;
        private Label label4;
        private TextBox txtExchangeRate;
        private Label label5;
        private ComboBox cmbContractor;
        private Button btnSaveInvoice;
        private DataGridView dgvItems;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn NetValue;
        private DataGridViewTextBoxColumn GrossValue;
        private Button btnGetRate;
        private Button btnExportPdf;
    }
}