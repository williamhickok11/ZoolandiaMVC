using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZoolandiaMVC.Models
{
    public class Animal
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(1, 100)]
        public int IdHabitat { get; set; }
        [Range(1, 100)]
        public int IdSpecies { get; set; }
    }
}
