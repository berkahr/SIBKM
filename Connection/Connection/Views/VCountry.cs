using Connection.Models;

namespace Connection.Views
{
    public class VCountry
    {
        public void GetAll(List<country> countries)
        {
            foreach (var country in countries)
            {
                Console.WriteLine("======================");
                Console.WriteLine("ID : " + country.Id);
                Console.WriteLine("Name : " + country.Name);
                Console.WriteLine("Region : " + country.region);
            }
        }
        public void Success(string message)
        {
            Console.WriteLine($"Data has been {message}");
        }

        public void Failure(string message)
        {
            Console.WriteLine($"Data has not been {message}");
        }
        public void DataNotFound()
        {
            Console.WriteLine("Data Not Found");
        }
    }
}
