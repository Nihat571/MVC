namespace Fashion_Project.ViewModels
{
    public class UpdateProductVM
    {
        public string State { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
