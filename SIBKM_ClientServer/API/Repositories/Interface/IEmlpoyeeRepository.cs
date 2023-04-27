using API.Models;

namespace API.Repositories.Interface
{
    public interface IEmlpoyeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int nik);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(int nik);
    }
}
