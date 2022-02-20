using Microsoft.EntityFrameworkCore;
using ProjectExample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectExample.DAL.Database
{
    public class DbContainer : DbContext
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = . ; database = ProjectNet; integrated security = true" );
        }
    }
}
