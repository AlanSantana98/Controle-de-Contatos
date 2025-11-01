//using Microsoft.EntityFrameworkCore;
//using Bando_de_Dados_Elton.Models;

//namespace Bando_de_Dados_Elton.Properties.Context
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }

//        public DbSet<CondominioViewModel> Condominio { get; set; }
//        public DbSet<EquipeViewModel> Equipe { get; set; }
//        public DbSet<IgrejaViewModel> Igreja { get; set; }
//        public DbSet<LiderancaViewModel> Lideranca { get; set; }
//        public DbSet<SegmentoViewModel> Segmento { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configurações adicionais se necessário
//        }
//    }
//}
using Microsoft.EntityFrameworkCore;
using Bando_de_Dados_Elton.Models;

namespace Bando_de_Dados_Elton.Properties.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CondominioViewModel> Condominio { get; set; }
        public DbSet<EquipeViewModel> Equipe { get; set; }
        public DbSet<IgrejaViewModel> Igreja { get; set; }
        public DbSet<LiderancaViewModel> Lideranca { get; set; }
        public DbSet<SegmentoViewModel> Segmento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir chave primária para EquipeViewModel
            modelBuilder.Entity<EquipeViewModel>()
                .HasKey(e => e.Id_Equipe);

            // Definir chave primária para CondominioViewModel (supondo um campo Id_Condominio)
            modelBuilder.Entity<CondominioViewModel>()
                .HasKey(c => c.Id_Condominio); // Ajuste o nome do campo conforme necessário

            // Definir chave primária para IgrejaViewModel (supondo um campo Id_Igreja)
            modelBuilder.Entity<IgrejaViewModel>()
                .HasKey(i => i.Id_Igreja); // Ajuste o nome do campo conforme necessário

            // Definir chave primária para LiderancaViewModel (supondo um campo Id_Lideranca)
            modelBuilder.Entity<LiderancaViewModel>()
                .HasKey(l => l.Id_Liderança); // Ajuste o nome do campo conforme necessário

            // Definir chave primária para SegmentoViewModel (supondo um campo Id_Segmento)
            modelBuilder.Entity<SegmentoViewModel>()
                .HasKey(s => s.Id_Segmento); // Ajuste o nome do campo conforme necessário

            base.OnModelCreating(modelBuilder);
        }
    }
}


