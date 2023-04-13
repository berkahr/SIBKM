using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Universities
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar(100)")]
        public string name { get; set; }
        
        //cardinality
        public ICollection<Educations> Educations { get; set; }
    }
}
