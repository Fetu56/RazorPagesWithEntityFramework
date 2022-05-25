namespace WebApplication4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"{Id}. {ProductName}: desc - {Description}, cost - {Cost}, Category id - {Category.Id}";
        }
    }
}
