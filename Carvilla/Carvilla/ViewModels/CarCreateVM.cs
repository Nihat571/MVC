

namespace Carvilla.ViewModels
{
    public class CarCreateVM
    {
   
        public string Name { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public int HP { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }

        public IFormFile ImgFile { get; set; }
    }
}
