using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbManager.DataBase.DTO
{
    [Table("Links")]
    public class Link
    {
        [Key]
        public int Id { get; set; }

        [Column("idchild")]
        [ForeignKey("Child")]
        public int? ChildId { get; set; }

        public Subject Child { get; set; }

        [Column("idparent")]
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public Subject Parent { get; set; }

        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
    }
}