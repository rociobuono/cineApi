namespace ATDapi.Models;

public class CarteleraModel
{
    public Guid? id { get; set; } //? para que el valor pueda ser null
    public string titulo { get; set;}
    public string sinopsis { get; set;}
    public string url { get; set;}
    public string genero { get; set;}
    public string duracion { get; set;}
    public string director { get; set;}
    public string actores { get; set;}
    public string publico { get; set;}
}
