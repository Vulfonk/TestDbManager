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

        public DbSet<Attribute> Attributes => Set<Attribute>();

        public UserContext() : base("DbConnection") { }
    }

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