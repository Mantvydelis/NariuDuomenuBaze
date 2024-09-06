using Microsoft.EntityFrameworkCore;
using NariuDuomenuBaze.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Members;Trusted_Connection=True;TrustServerCertificate=true;");
        }

    }
}
