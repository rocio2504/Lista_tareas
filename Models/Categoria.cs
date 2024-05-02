using System.ComponentModel.DataAnnotations;
namespace projectef.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId { get; set; }
    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; }

    public string Descripcion { get; set; }
    public virtual Icollection<Tarea> Tareas { get; set; }
}
