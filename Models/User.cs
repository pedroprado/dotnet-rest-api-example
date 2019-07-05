namespace web_api_example.Models
{
    public class User
    {
        public User(int userId, string name, string senha, string email)
        {
            this.userId = userId;
            this.name = name;
            this.senha = senha;
            this.email = email;
        }

        public int userId {get; set;}
        public string name {get; set;}
        public string senha {get; set;}
        public string email {get; set;}


    }
}