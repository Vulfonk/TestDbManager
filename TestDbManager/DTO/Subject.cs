using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DTO
{
    [Table("Objects")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Column("product")]
        public string Product { get; set; }

        [Column("type")]
        public string Type { get; set; }

    }
}