using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context) { }
        public string GetFullNameByEmail(string email)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.email == email)!;
            return employee.first_name + " " + employee.last_name;
        }
    }
}