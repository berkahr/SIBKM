using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class AccountRoles
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("AccountId")]
        public int AccountId { get; set; }
        [Column("role_id")]
        public int role_id { get; set; }
        
        //cardinality
        public Accounts Accounts { get; set; }
        public Roles Roles { get; set; }
     }
}
