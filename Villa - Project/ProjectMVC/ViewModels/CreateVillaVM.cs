using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.ViewModels
{
    public class CreateVillaVM
    {
        [Required(ErrorMessage = "Adi dogru daxil edin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pulu dogru daxil edin")]
        public double Price { get; set; }

        [Required(ErrorMessage = "bedroom dogru daxil edin")]
        public int Bedrooms { get; set; }
        [Required(ErrorMessage = "bashroom dogru daxil edin")]
        public int Bathrooms { get; set; }
        [Required(ErrorMessage = "Area dogru daxil edin")]
        public string Area { get; set; }
        [Required(ErrorMessage = "Floor dogru daxil edin")]
        public string Floor { get; set; }
        [Required(ErrorMessage = "Parking dogru daxil edin")]
        public string Parking { get; set; }
        [Required(ErrorMessage = "Type dogru daxil edin")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Fayli dogru daxil edin")]
        public IFormFile File { get; set; }
    }
}
