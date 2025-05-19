namespace Charity_Project.Models
{
    public class CauseCart:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double RaisedNumber { get; set; }
        public double GoalNUmber { get; set; }
    }
}
