namespace WebApplication4.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Id}. {UserName}: age - {Age}, pass - {Password}";
        }
    }
}
