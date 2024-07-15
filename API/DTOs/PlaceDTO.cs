
using Core.Entitys;

namespace API.DTOs
{
    public class PlaceDTO
    {      
        public int id { get; set; }
        public string name { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public string ImageUrl { get; set; }

        public string country{get; set;}
               
        public string category { get; set; }
    }
}