using Connection.Repositories.Interfaces;
using Connection.Views;
using Connection.Models;

namespace Connection.Controllers
{
    public class CountryController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly VCountry _vcountry;
        
        public CountryController(ICountryRepository countryRepository, VCountry vCountry)
        {
            _countryRepository = countryRepository;
            _vcountry = new VCountry();
        }

        public void GetAll()
        {
            var country = _countryRepository.GetAll();
            if (country == null)
            {
                _vcountry.DataNotFound();
            }
        }
        public void GetById(string id)
        {
            var country = _countryRepository.GetById(id);
            if (country == null)
            {
                _vcountry.DataNotFound();
            }
        }
        public void insert(country country)
        {
            var result = _countryRepository.Insert(country);
            if (result > 0)
            {
                _vcountry.Success("inserted");
            }
            else
            {
                _vcountry.Failure("insert");
            }
        }
        public void update(country country)
        {
            var result = _countryRepository.Update(country);
            if (result > 0)
            {
                _vcountry.Success("Updated");
            }
            else
            {
                _vcountry.Failure("Update");
            }
        }
        public void delete(string Id)
        {
            var result = _countryRepository.Delete(Id);
            if (result > 0)
            {
                _vcountry.Success("Deleted");
            }
            else
            {
                _vcountry.Failure("Delete");
            }
        }
    }
}
