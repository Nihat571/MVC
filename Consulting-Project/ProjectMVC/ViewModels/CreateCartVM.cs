using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.ViewModels;

public class CreateCartVM
{
    [Required(ErrorMessage = "Ad daxil edin!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Peşə daxil edin!")]
    public string Specialty { get; set; }

    [Required(ErrorMessage = "İnfo daxil edin!")]
    public string Description { get; set; }

    public IFormFile? File { get; set; }
}
