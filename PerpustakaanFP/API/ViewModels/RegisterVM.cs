using API.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ViewModels
    {
        public class RegisterVM
        {
            public int Id { get; set; }
            public string FirstName { get;set; }
            public string LastName { get; set; }
            public string TelpNumber { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
