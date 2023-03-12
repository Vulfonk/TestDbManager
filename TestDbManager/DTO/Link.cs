using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
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
    }
}