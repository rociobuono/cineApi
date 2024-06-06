

public class Queries{

        public string select(string clase)
        {
                return string.Format($"SELECT * FROM {clase};");
        }
        
        public string DeleteByQuery(string clase,int id)
        {
                return string.Format($"DELETE FROM {clase} WHERE id = {0}", id);
        }

}