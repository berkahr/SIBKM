using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context) { }
        public int Register(RegisterVM registerVM)
        {
            int result = 0;

            //insert to universitie table
            var universities = new Universities
            {
                name = registerVM.UniversitiesName,
            };
            _context.Set<Universities>().Add(universities);
            result = _context.SaveChanges();

            //insert to education table
            var educations = new Educations
            {
                major = registerVM.Major,
                degree = registerVM.Degree,
                gpa = registerVM.Gpa,
                university_id = universities.id
            };
            _context.Set<Educations>().Add(educations);
            result += _context.SaveChanges();

            //insert to employee table
            var employee = new Employee
            {
                nik = registerVM.NIK,
                first_name = registerVM.FirstName,
                last_name = registerVM.LastName,
                gender = registerVM.Gender,
                birthdate = registerVM.BirthDate,
                email = registerVM.Email,
                hiring_date = DateTime.Now,
                phone_number = registerVM.PhoneNumber
            };
            _context.Set<Employee>().Add(employee);
            result += _context.SaveChanges();

            //insert to Account table
            var accounts = new Accounts
            {
                employee_nik = registerVM.NIK,
                password = registerVM.password
            };
            _context.Set<Accounts>().Add(accounts);
            result += _context.SaveChanges();

            //insert to Profiling table
            var profilings = new Profilings
            {
                employee_nik = registerVM.NIK,
                education_id = educations.id,
            };
            _context.Set<Profilings>().Add(profilings);
            result += _context.SaveChanges();

            //insert to AccountRole table
            var accountRoles = new AccountRoles
            {
                account_nik = registerVM.NIK,
                role_id = 2
            };
            _context.Set<AccountRoles>().Add(accountRoles);
            result += _context.SaveChanges();

            return result;
        }
        public bool Login(LoginVM loginVM)
        {
            //Ambil data dari database berdasarkan Email di tabel employee
            //Gabungkan data dari tabel employee dengan tabel account berdasarkan NIK
            //Cocokan data tersebut dengan Password yang diinputkan
            //Cek apakah data valid atau tidak
            return false;
        }
    }
}