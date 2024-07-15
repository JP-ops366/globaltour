using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Entitys
{
    public class Place
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public string ImageUrl { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country country{get; set;}

        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        
    }

    
}