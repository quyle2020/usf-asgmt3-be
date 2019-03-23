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
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
