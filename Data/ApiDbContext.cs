using Microsoft.EntityFrameworkCore;
using ApiDemo.Models;
using ApiDemo.Enums;

namespace ApiDemo.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Tarefa>? Tarefas { get; set; }




        // Caso precise configurar mapeamentos específicos, você pode sobrescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemplo de configuração: ModelBuilder para enum como string
            modelBuilder.Entity<Tarefa>()
                .Property(u => u.Status)
                .HasConversion(
                    v => v.ToString(), // Salva o enum como string
                    v => (StatusTarefaEnum)Enum.Parse(typeof(StatusTarefaEnum), v) // Converte de string para enum
                );
        }
    }
}
