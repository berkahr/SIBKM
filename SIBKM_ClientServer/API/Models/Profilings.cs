using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Profilings
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public string employee_nik { get; set; }
        
        [Column("education_id")]
        public int education_id { get; set; }
        
        //cardinality
        public Educations Educations { get; set; }
        public Employee Employee { get; set; }
    }
}
