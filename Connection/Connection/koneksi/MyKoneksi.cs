using System.Data.SqlClient;

namespace Connection.koneksi
{
    internal class MyKoneksi
    {
        private static SqlConnection connection;

        private static string connectionString = "Data Source=DESKTOP-QVABO1H\\SQLSERVER2019;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public static SqlConnection GetConnection()
        { 
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed : " + e);
            }
            return connection;
        }
    }
}
