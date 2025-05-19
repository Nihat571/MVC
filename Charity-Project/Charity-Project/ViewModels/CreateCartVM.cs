namespace Charity_Project.ViewModels
{
    public class CreateCartVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double RaisedNumber { get; set; }
        public double GoalNumber { get; set; }
        public IFormFile formFile { get; set; }
    }
}
