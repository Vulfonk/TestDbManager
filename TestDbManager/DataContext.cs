using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DataBase
{
    public class UserContext : DbContext
    {
        public DbSet<Subject> Objects => Set<Subject>();

        public DbSet<Link> Links => Set<Link>();

        public UserContext() : base("DbConnection") { }
    }

    [Table("Links")]
    public class Link
    {
        [Key]
        public int Id { get; set; }

        public int? ChildId { get; set; }

        [ForeignKey("ChildId")]
        public Subject Child { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Subject Parent { get; set; }
    }

    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}