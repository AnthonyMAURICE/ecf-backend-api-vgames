using Ecf.Vgames.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecf.Vgames.Db
{
    public class GizmondoContext : DbContext
    {
        public DbSet<Gizmondos> Gizmondos { get; set; }

        public DbSet<Publishers> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_ecf_vgames");
        }
    }
}
