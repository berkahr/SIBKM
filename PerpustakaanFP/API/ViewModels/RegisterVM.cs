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
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int OfficerId { get; set; }
            public int MemberId { get; set; }
            public int BookId { get; set; }
            public string BookTitle { get; set; }
            public string Author { get; set; }
            public string Type { get; set; }
            public string Publisher { get; set; }
            public string PublicationYear { get; set; }
        }
    }
