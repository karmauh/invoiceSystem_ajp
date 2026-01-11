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
using System.Security.Cryptography;
using InvoiceSystem.Services;

namespace InvoiceSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Uzupełnij dane logowania");
                return;
            }

            string passwordHash = ComputeHash(password);

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT id FROM users WHERE email = @email AND password_hash = @password_hash AND is_active = 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password_hash", passwordHash);

                    object result = command.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Nieprawidłowy login lub hasło");
                        return;
                    }

                    int userId = Convert.ToInt32(result);

                    GenerateTwoFactorCode(userId);
                    TwoFactorForm twoFactorForm = new TwoFactorForm(userId);
                    if (twoFactorForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Użytkownik zalogowany");
                    }

                }
            }
        }
        private void GenerateTwoFactorCode(int userId)
        {
            string code = new Random().Next(100000, 999999).ToString();
            string email = txtEmail.Text;

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO two_factor_codes (user_id, code, expires_at, is_used) VALUES (@user_id, @code, @expires_at, @is_used)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@expires_at", DateTime.Now.AddMinutes(5));
                    command.Parameters.AddWithValue("@is_used", false);
                    command.ExecuteNonQuery();
                }
            }

            EmailService.SendCode(email, code);
        }
        private string ComputeHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
