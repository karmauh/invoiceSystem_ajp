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

namespace InvoiceSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string phone = txtPhone.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Uzupełnij wymagane pola");
                return;
            }

            string passwordHash = ComputeHash(password);

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO users (email, phone, password_hash, is_active, created_at) VALUES (@email, @phone, @password_hash, @is_active, @created_at)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@password_hash", passwordHash);
                    command.Parameters.AddWithValue("@is_active", true);
                    command.Parameters.AddWithValue("@created_at", DateTime.Now);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Rejestracja zakończona sukcesem");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Błąd podczas rejestracji użytkownika");
                    }
                }
            }
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
