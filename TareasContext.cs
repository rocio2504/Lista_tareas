using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TareasContext : DbContext
{
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options)
    {
    }
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tareas.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>()
            .HasOne(t => t.Categoria)
            .WithMany(c => c.Tareas)
            .HasForeignKey(t => t.CategoriaId);
    }
    */
}