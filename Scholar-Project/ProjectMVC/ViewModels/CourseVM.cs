using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.ViewModels
{
    public class CourseVM
    {
        [Required(ErrorMessage ="Kurs adi daxil edin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kursun muellifini daxil edin")]
        public string Author { get; set; }


        [Required(ErrorMessage = "Kursun qiymetini daxil edin")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Kurs haqqinda info daxil edin")]
        public string Subject { get; set; }
        public IFormFile? File { get; set; }
    }
}
