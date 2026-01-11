using MySql.Data.MySqlClient;

namespace InvoiceSystem.Data
{
    public static class DatabaseConnection
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=invoicesystem;Uid=root;Pwd=rootpassword;";
            return new MySqlConnection(connectionString);
        }
    }
}