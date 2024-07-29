using JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<UsuarioModel>Usuario { get; set; }
    }
}
