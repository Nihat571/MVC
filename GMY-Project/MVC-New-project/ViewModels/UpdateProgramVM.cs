namespace MVC_New_project.ViewModels;

public class UpdateProgramVM
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile? File { get; set; }
}
