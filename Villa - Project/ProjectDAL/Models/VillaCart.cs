using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Models
{
    public class VillaCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Area { get; set; }
        public string Floor { get; set; }
        public string Parking { get; set; }
        public string ImgUrl { get; set; }
        public string Type { get; set; }

    }
}
