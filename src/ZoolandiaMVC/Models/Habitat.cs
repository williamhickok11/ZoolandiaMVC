using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoolandiaMVC.Models
{
    public class Habitat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IdHabitatType { get; set; }
        public int IdEmployee { get; set; }
    }
}
