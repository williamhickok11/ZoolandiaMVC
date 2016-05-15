using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoolandiaMVC.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IdHabitat { get; set; }
        public int IdSpecies { get; set; }
    }
}
