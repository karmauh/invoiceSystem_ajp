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

namespace InvoiceSystem.Forms
{
    public partial class TwoFactorForm : Form
    {
        private int _userId;

        public TwoFactorForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT id FROM two_factor_codes WHERE user_id = @user_id AND code = @code AND is_used = 0 AND expires_at > @now";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", _userId);
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@now", DateTime.Now);

                    object result = command.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Nieprawidłowy lub wygasły kod");
                        return;
                    }

                    int codeId = Convert.ToInt32(result);

                    string updateQuery = "UPDATE two_factor_codes SET is_used = 1 WHERE id = @id";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@id", codeId);
                        updateCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Logowanie zakończone sukcesem");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

    }
}
