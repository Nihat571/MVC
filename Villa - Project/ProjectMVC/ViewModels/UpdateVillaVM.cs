namespace ProjectMVC.ViewModels
{
    public class UpdateVillaVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Area { get; set; }
        public string Floor { get; set; }
        public string Parking { get; set; }
        public string Type { get; set; }
        public IFormFile? File { get; set; }
    }
}
