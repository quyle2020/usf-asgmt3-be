using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usf_asgmt3_api.model;

namespace usf_asgmt3_api.Integration.LocalDataRepo
{
    public class LocalDBContext: DbContext
    {
        //https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
        public LocalDBContext(DbContextOptions<LocalDBContext> options)
           : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company_Dividend>()
                .HasKey(c => new { c.symbol, c.exDate});

            modelBuilder.Entity<Company_Financial>()
              .HasKey(c => new { c.symbol, c.reportDate });
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Company_Detail> Company_Details { get; set; }
        public DbSet<Company_Dividend> Company_Dividends { get; set; }
        public DbSet<Company_Financial> Company_Financials { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
    }
}
