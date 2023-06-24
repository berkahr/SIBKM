using API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Accounts
    {
        [Key, Column("memberId")]
        public int memberId { get; set; }
        [Column("password", TypeName = "varchar(255)")]
        public string password { get; set; }
        
        //Cardinality
        public Member Member { get; set; }
        public ICollection<AccountRoles> AccountRoles { get; set; }
    }
}
