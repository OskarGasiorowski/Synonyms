using System;
using Microsoft.EntityFrameworkCore;
using Synonyms.Database.Models;

namespace Synonyms.Database
{
    public sealed class AppContext : DbContext
    {
        private readonly DatabaseSettings databaseSettings;
        
        public DbSet<SynonymsRecord> Synonyms { get; set; }

        public AppContext(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.databaseSettings.ConnectionString);
        }
    }
}