using System.ComponentModel.DataAnnotations;

namespace New_Project_N_Tier.MVC.ViewModels
{
    public class UpdateCartVM
    {
        [Required(ErrorMessage = "Ad əlavə etmək məcburidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "minNumber əlavə etmək məcburidir")]
        public int minNumber { get; set; }
        [Required(ErrorMessage = "maxNumber əlavə etmək məcburidir")]
        public int maxNumber { get; set; }
        [Required(ErrorMessage = "Category əlavə etmək məcburidir")]
        public string Category { get; set; }

        public IFormFile File { get; set; }
    }
}
