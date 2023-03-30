using System.Data.SqlClient;

namespace Connection;

public class Program
{
    private static SqlConnection connection;

    private static string connectionString = "Data Source=DESKTOP-QVABO1H\\SQLSERVER2019;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";

    public static void Main()
    {
        /*connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Connection Open!");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Connection Failed : " + e);
        }*/

        //GetAllCountry();
        //GetByIdCountry("ID");
        //InsertCountry("PRIOK", "PK", 1);
        //UpdateRegion("PK", "Priok Terupdate");
        //DeleteCountry("PK");
    }

    // GET ALL : Country
    public static void GetAllCountry()
    {
        // Membuat instance SQL Server Connection
        connection = new SqlConnection(connectionString);

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
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Country is Empty!");
        }
        reader.Close();
        connection.Close();
    }

    // GET BY ID : Country
    public static void GetByIdCountry(String id)
    {
        // Membuat instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        // Membuat instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From Country Where id = @id;";

        // Membuat instance SQL Parameter
        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = System.Data.SqlDbType.VarChar;
        pId.Value = id;
        command.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            Console.WriteLine("Id : " + reader[0]);
            Console.WriteLine("Name : " + reader[1]);
            Console.WriteLine("Region : " + reader[2]);
        }
        else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    // INSERT : Country
    public static void InsertCountry(String name, String Id, int region)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into Country (name,Id,region) Values (@name,@Id,@region);";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@Id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = Id;
            command.Parameters.Add(pId);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            pRegion.Value = region;
            command.Parameters.Add(pRegion);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
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
    }

    // UPDATE : Country
    public static void UpdateRegion(String id, string name)
    {
        connection = new SqlConnection(connectionString);
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
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
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
    }

    // DELETE : Country
    public static void DeleteCountry(String id)
    {
        connection = new SqlConnection(connectionString);
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
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
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
    }
}
