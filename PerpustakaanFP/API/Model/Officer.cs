using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("Officer")]
    public class Officer
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [Key, Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }
        //cardinality
        [JsonIgnore]
        public Borrow? Borrow { get; set; }
    }
}
