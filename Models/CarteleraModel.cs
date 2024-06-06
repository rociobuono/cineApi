namespace ATDapi.Models;

public class CarteleraModel : Queries
{
    public int? id { get; set; } //? para que el valor pueda ser null
    public string? titulo { get; set;}
    public string? sinopsis { get; set;}
    public string? url { get; set;}
    public string? genero { get; set;}
    public string? director { get; set;}
    public string? actores { get; set;}
    public string? publico { get; set;}

    

    public string InsertByQuery()
    {
        return string.Format("INSERT INTO Cartelera VALUES ('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}')", this.titulo, this.sinopsis, this.url,this.genero,this.director,this.actores,this.publico);
    }

    /*public static string GetAll()
    {
        return string.Format("SELECT * FROM Cartelera;");
    }*/

    public static string DeleteByQuery(int id)
    {
        return string.Format("DELETE FROM Cartelera WHERE id = {0}", id);
    }
}
