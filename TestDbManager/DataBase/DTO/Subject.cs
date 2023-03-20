using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbManager.DataBase.DTO
{
    [Table("Objects")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Column("product")]
        [StringLength(150)]
        public string Product { get; set; }

        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }

    }
}