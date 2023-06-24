using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("Member")]
    public class Member
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [Column(name: "FirstName", TypeName = "varchar(25)")]
        public String FirstName { get; set; }
        [Column(name: "LastName", TypeName = "varchar(25)")]
        public String LastName { get; set; }
        [Column(name: "PhoneNumber", TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(name: "Address", TypeName = "varchar(255)")]
        public string Address { get; set; }
        [Column(name: "Email", TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column("password", TypeName = "varchar(255)")]
        public string password { get; set; }
        //cardinality
        [JsonIgnore]
        public Borrow? Borrow { get; set; }
    }
}
