using System.ComponentModel.DataAnnotations.Schema;

namespace Carvilla.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImgUrl { get; set; }
    public int Year { get; set; }
    public string Model { get;set;}
    public int HP { get; set; }
    public string Type { get; set; }
    public string Desc { get; set; }

  
   
}
