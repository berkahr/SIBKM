using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Roles
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar(100)")]
        public string name { get; set; }
        
        //cardinality
        public ICollection<AccountRoles> AccountRoles { get; set; }
    }
}
