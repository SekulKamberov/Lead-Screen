namespace LeadScreen.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using LeadScreen.Models.EntityModels;

    public class LeadScreenDBContext : DbContext
    {
        public LeadScreenDBContext(DbContextOptions<LeadScreenDBContext> dbContextOptions) : base(dbContextOptions)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<SubArea> SubAreas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
