namespace ProjectMVC.ViewModels;

public class UpdateCartVM
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    public string Description { get; set; }
    public IFormFile? File { get; set; }
}
