using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Roles
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        //cardinality
/*        [JsonIgnore]
        public AccountRoles AccountRoles { get; set; }*/
    }
}
