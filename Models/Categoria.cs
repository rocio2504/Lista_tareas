using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace projectef.Models;

public class Categoria
{
  //  [Key]
    public Guid CategoriaId { get; set; }
  //comentar los atributos xq se usa el fluent api en TareasContext.cs
   // [Required]
   // [MaxLength(150)]
    public string Nombre { get; set; }

    public string Descripcion { get; set; }
    public virtual ICollection<Tarea> Tareas { get; set; }
}
