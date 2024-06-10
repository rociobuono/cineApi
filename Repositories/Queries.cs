

public abstract class Queries{

        public string select(string clase)
        {
                return string.Format($"SELECT * FROM {clase};");
        }
        
        public string DeleteByQuery(string clase,int id)
        {
                return string.Format($"DELETE FROM {clase} WHERE id = {id}");
        }

        public abstract string insert();

        public abstract string update(string name, int id);
}