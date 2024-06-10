using System.Reflection.Metadata;

namespace ATDapi.Models;

public class CarteleraModel : Queries
{
    public int id { get; set; } //? para que el valor pueda ser null
    public string? titulo { get; set;}
    public string? sinopsis { get; set;}
    public string? url { get; set;}
    public string? genero { get; set;}
    public string? director { get; set;}
    public string? actores { get; set;}
    public string? publico { get; set;}

    

    public override string insert()
    {
        return string.Format("INSERT INTO Cartelera VALUES ('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}')", this.titulo, this.sinopsis, this.url,this.genero,this.director,this.actores,this.publico);
    }

    
        public override string update(string name,int id)
    {
        List<string> updates = new List<string>();
        if (titulo != "string")
        {
            updates.Add($"titulo = '{titulo}'");
        }
        if (sinopsis != "string")
        {
            updates.Add($"imagen = '{sinopsis}'");
        }
        if (url != "string")
        {
            updates.Add($"descripcion = '{url}'");
        }
        if (genero != "string")
        {
            updates.Add($"descripcion = '{genero}'");
        }
        if (director != "string")
        {
            updates.Add($"descripcion = '{director}'");
        }
        if (actores != "string")
        {
            updates.Add($"descripcion = '{actores}'");
        }
        if (publico != "string")
        {
            updates.Add($"descripcion = '{publico}'");
        }


        if (updates.Count == 0)
        {
            return "No se ha proporcionado ningún valor para actualizar.";
        }

        string updateFields = string.Join(", ", updates);
        return string.Format($"UPDATE {name} SET {updateFields} WHERE id = {id}");
    }
}

