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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.Totable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).HasMaxLength(150).IsRequired();
            categoria.Property(p => p.Descripcion);
            categoria.HasMany(c => c.Tareas).WithOne(t => t.Categoria).HasForeignKey(t => t.CategoriaId);
        });
           
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