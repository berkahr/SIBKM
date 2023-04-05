using Connection.koneksi;
using Connection.Models;
using Connection.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Connection.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public List<country> GetAll()
        {
            List<country> listcountry = new List<country>();

            // Membuat instance SQL Server Connection
            var connection = MyKoneksi.GetConnection();

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From Country;";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id : " + reader[0]);
                    Console.WriteLine("Name : " + reader[1]);
                    Console.WriteLine("Region : " + reader[2]);
                }
            }
            else
            {
               return null;
            }
            reader.Close();
            connection.Close();
            return listcountry;
        }

        public country GetById(string Id)
        {
            country Country = new country();
            // Membuat instance SQL Server Connection
            var connection = MyKoneksi.GetConnection();

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From Country Where id = @id;";

            // Membuat instance SQL Parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = Id;
            command.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id : " + reader[0]);
                    Console.WriteLine("Name : " + reader[1]);
                    Console.WriteLine("Region :" + reader[2]);
                }
            }
            else
            {
                Console.WriteLine($"id = {Id} is not found!");
            }
            reader.Close();
            connection.Close();
            return Country;
        }

        public int Insert(country country)
        {
            var result = 0;
            var connection = MyKoneksi.GetConnection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into Country (Name,Id,region) Values (@name,@Id,@region);";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = country.Name;
                command.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = country.Id;
                command.Parameters.Add(pId);

                SqlParameter pRegion = new SqlParameter();
                pRegion.ParameterName = "@region";
                pRegion.SqlDbType = System.Data.SqlDbType.Int;
                pRegion.Value = country.region;
                command.Parameters.Add(pRegion);

                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Insert Success!");
                connection.Close();
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return result;
        }

        public int Update(country country)
        {
            var result = 0;
            var connection = MyKoneksi.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update Country Set name = @name Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = country.Name;
                command.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = country.Id;
                command.Parameters.Add(pId);

                int a = command.ExecuteNonQuery();
                if (a > 0)
                {
                    Console.WriteLine("Update Success!");
                }
                else
                {
                    Console.WriteLine("Something Wrong!");
                }

                transaction.Commit();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return result;
        }
        public int Delete(string Id)
        {
            var result = 0;
            var connection = MyKoneksi.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete From Country Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = Id;
                command.Parameters.Add(pId);

                int a = command.ExecuteNonQuery();
                if (a > 0)
                {
                    Console.WriteLine("Delete Success!");
                }
                else
                {
                    Console.WriteLine("Something Wrong!");
                }

                transaction.Commit();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong! : " + e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return result;
        }
    }
}
