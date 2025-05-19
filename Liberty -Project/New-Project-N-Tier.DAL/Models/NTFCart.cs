using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Project_N_Tier.DAL.Models
{
    public class NTFCart
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int minNumber { get; set; }
        public int maxNumber { get; set; }
        public string Category { get; set; }
    }
}
