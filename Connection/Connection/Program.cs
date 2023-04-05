using Connection.Controllers;
using Connection.koneksi;
using Connection.Models;
using Connection.Repositories;
using Connection.Repositories.Interfaces;
using Connection.Views;
using System.Data.SqlClient;

namespace Connection;

public class Program
{
    public static void Main()
    {
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Database Connectivity=========");
            Console.WriteLine("1. Manage Table Region");
            Console.WriteLine("2. Manage Table Country");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Region();
                    break;
                case 2:
                    Country();
                    break;
                case 3:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }
    public static void Country()
    {
        ICountryRepository repository = new CountryRepository();
        VCountry vCountry = new VCountry();
        CountryController countryController = new CountryController(repository, vCountry);
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=======GetAll=======");
                    countryController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=======GetById=======");
                    Console.Write("input id : ");
                    var id = Console.ReadLine();
                    countryController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Region=======");
                    Console.Write("Input Id : ");
                    var Iid = Console.ReadLine(); 
                    Console.Write("Input Name : ");
                    var name = Console.ReadLine();
                    Console.Write("Input Region : ");
                    var region = Convert.ToInt32(Console.ReadLine());
                    countryController.insert(new country { Id = Iid, Name = name, region = region });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Region=======");
                    Console.Write("Input Id : ");
                    var Uid = Console.ReadLine(); 
                    Console.Write("Input Name : ");
                    var Uname = Console.ReadLine();
                    Console.Write("Input Region : ");
                    var Uregion = Convert.ToInt32(Console.ReadLine());
                    countryController.update(new country { Id = Uid, Name = Uname, region = Uregion });
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Region=======");
                    Console.Write("Input Id : ");
                    var Did = Console.ReadLine();
                    countryController.delete(Did);
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }
    public static void Region()
    {
        RegionController regionController = new RegionController(new RegionRepository(), new VRegion());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=======GetAll=======");
                    regionController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=======GetById=======");
                    Console.Write("Input Id : ");
                    var id = Convert.ToInt32(Console.ReadLine());
                    regionController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Region========");
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    regionController.Insert(new Region
                    {
                        Name = name
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Region=======");
                    Console.Write("Input Id : ");
                    var Uid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Input Name : ");
                    var Uname = Console.ReadLine();
                    regionController.Update(new Region { Id = Uid, Name = Uname });
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Region=======");
                    Console.Write("Input Id :");
                    var Did = Convert.ToInt32(Console.ReadLine());
                    regionController.Delete(Did);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);

    }
}