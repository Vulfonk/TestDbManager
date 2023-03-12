using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<Object> Objects => Set<Object>();

        public DbSet<Link> Links => Set<Link>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfCoreBasicDb;Trusted_Connection=True;");/*
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .LogTo();*/
    }

    [Table("Links")]
    public class Link
    {
        [Key]
        public int Id { get; set; }

        public int ChildId { get; set; }

        [ForeignKey("ChildId")]
        public Object Child { get; set; }

        public int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Object Parent { get; set; }
    }

    [Table("Objects")]
    public class Object
    {
        [Key]
        public int Id { get; set; }

    }
}