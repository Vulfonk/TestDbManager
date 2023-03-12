using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
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
        public string Name { get; set; }

        [Column("Value")]
        public string Value{ get; set; }
    }
}