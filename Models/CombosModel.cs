namespace ATDapi.Models;

public class CombosModel : Queries{

    public int id {get; set;}
    public string? titulo {get; set;}
    public string? imagen { get; set; }
    public string? descripcion { get; set; }

    public override string insert()
    {
        return string.Format("INSERT INTO Combos VALUES ('{0}', '{1}', '{2}', '{3}')", this.titulo, this.imagen, this.descripcion);
    }

    public override string update(string name,int id)
    {
        List<string> updates = new List<string>();
        if (titulo != "string")
        {
            updates.Add($"titulo = '{titulo}'");
        }
        if (imagen != "string")
        {
            updates.Add($"imagen = '{imagen}'");
        }
        if (descripcion != "string")
        {
            updates.Add($"descripcion = '{descripcion}'");
        }
        /*if (!string.IsNullOrEmpty(titulo))
        {
            updates.Add($"titulo = '{titulo}'");
        }
        if (!string.IsNullOrEmpty(imagen))
        {
            updates.Add($"imagen = '{imagen}'");
        }
        if (!string.IsNullOrEmpty(descripcion))
        {
            updates.Add($"descripcion = '{descripcion}'");
        }*/


        if (updates.Count == 0)
        {
            return "No se ha proporcionado ningún valor para actualizar.";
        }

        string updateFields = string.Join(", ", updates);
        return string.Format($"UPDATE {name} SET {updateFields} WHERE id = {id}");
    }
    /*public static string GetAll()

    public static string GetAll()
    {
        return string.Format("SELECT * FROM Combos;");
    }

    public static string DeleteByQuery(int id)
    {
        return string.Format("DELETE FROM Combos WHERE id = {0}", id);

    }*/

}


