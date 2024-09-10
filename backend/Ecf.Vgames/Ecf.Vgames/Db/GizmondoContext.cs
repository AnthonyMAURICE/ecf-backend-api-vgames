using Ecf.Vgames.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecf.Vgames.Db
{
    public class GizmondoContext : DbContext
    {
        public DbSet<Gizmondo> Gizmondoes { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_ecf_vgames");
        }
    }
}
