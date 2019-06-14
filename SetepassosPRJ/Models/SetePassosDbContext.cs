using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class SetePassosDbContext : DbContext
    {
        //Lista de todos os Scores
        public DbSet<HighScore> Scores {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection =
            @"Server=(localdb)\mssqllocaldb;Database=KillCharlie-SetepassosPRJ;
            Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
