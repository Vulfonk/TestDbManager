using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DTO
{
    [Table("Attributes")]
    public class Attribute
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ObjectId")]
        public Subject Object { get; set; }

        [Column("objectid")]
        public int ObjectId { get; set; }

        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("Value")]
        [StringLength(150)]
        public string Value{ get; set; }
    }
}