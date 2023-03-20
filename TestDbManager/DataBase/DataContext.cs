using TestDbManager.DataBase.DTO;
using System.Collections.Generic;
using System.Data.Entity;

namespace TestDbManager.DataBase
{
    public class UserContext : DbContext
    {
        public DbSet<Subject> Objects => Set<Subject>();

        public DbSet<Link> Links => Set<Link>();

        public DbSet<Attribute> Attributes => Set<Attribute>();

        public UserContext() : base("DbCon") { }
    }
}