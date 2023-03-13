using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DTO
{
    [Table("Links")]
    public class Link
    {
        [Key]
        public int Id { get; set; }

        [Column("idchild")]
        public int? ChildId { get; set; }

        [ForeignKey("ChildId")]
        public Subject Child { get; set; }

        [Column("idparent")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Subject Parent { get; set; }

        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
    }
}