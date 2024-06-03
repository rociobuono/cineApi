namespace ATDapi.Models;

public class CombosModel{

    public int? id {get; set;}
    public string? titulo {get; set;}
    public string? imagen { get; set; }
    public string? descripcion { get; set; }

    public string InsertByQuery()
    {
        return string.Format("INSERT INTO Combos VALUES ('{0}', '{1}', '{2}', '{3}')", this.titulo, this.imagen, this.descripcion);
    }

    public static string GetAll()
    {
        return string.Format("SELECT * FROM Combos;");
    }

    public static string DeleteByQuery(int id)
    {
        return string.Format("DELETE FROM Combos WHERE id = {0}", id);
    }

}