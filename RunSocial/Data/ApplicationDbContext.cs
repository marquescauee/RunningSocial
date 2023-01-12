using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RunSocial.Models;

namespace RunSocial.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {}
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Clube> Clubes { get; set; }
        public DbSet<Corrida> Corridas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
