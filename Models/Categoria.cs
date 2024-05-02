namespace projectef.Models;

public class Categoria
{
    public Guid CategoriaId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public virtual Icollection<Tarea> Tareas { get; set; }
}
