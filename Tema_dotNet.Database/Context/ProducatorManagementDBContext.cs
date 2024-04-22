using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Context
{
    public class ProducatorManagementDBContext : DbContext
    {
        public DbSet<Producator> Producatori { get; set; }
        public DbSet<Produs> Produse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Server=localhost;Database=ProducatorManagement;User Id=sa;Password=sa123;TrustServerCertificate=True").LogTo(Console.WriteLine);
        }
    }
}
