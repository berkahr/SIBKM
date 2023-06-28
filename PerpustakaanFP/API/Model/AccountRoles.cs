using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
/*        [JsonIgnore]
        public Accounts Accounts { get; set; }
        [JsonIgnore]
        public Roles Roles { get; set; }*/
     }
}
