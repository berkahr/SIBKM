using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("Borrow")]
    public class Borrow
    {
        [Key, Column(name: "Id")]
        public int Id { get; set; }
        [Column(name: "OfficerId")]
        public int OfficerId { get; set; }
        [Column(name: "MemberId")]
        public int MemberId { get; set; }
        [Column(name: "BookId")]
        public int BookId { get; set; }
        [Column(name: "BorrowDate", TypeName = "date")]
        public DateOnly BorrowDate { get; set; }
        [Column(name:"Returndate", TypeName = "date")]
        public DateOnly ReturnDate { get; set; }
        [Column(name: "Fine")]
        public int Fine { get; set; }

        //cardinality
        [JsonIgnore]
        public Book? Book { get; set; }
    }
}
