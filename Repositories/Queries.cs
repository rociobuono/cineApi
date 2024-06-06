

public class Queries{

        public string select(string clase){

                return string.Format($"SELECT * FROM {clase};");
        }

}