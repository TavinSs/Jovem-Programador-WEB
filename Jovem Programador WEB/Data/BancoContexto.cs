using Jovem_Programador_WEB.Data.Mapeamento;
using Jovem_Programador_WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace Jovem_Programador_WEB.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options): base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
	}
}
