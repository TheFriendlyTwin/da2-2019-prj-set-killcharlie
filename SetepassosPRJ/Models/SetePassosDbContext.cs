using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class SetePassosDbContext : DbContext
    {

    public DbSet<Jogo> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection =
            @"Server=(localdb)\mssqllocaldb;Database=DA2_2018_LABCOMPRAS;
Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connection);
        }
    }

}
