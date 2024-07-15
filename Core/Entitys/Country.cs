using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Core.Entitys
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool State { get; set; }

    }
}