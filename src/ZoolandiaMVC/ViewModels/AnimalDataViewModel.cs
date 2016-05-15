using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoolandiaMVC.ViewModels
{
    public class AnimalDataViewModel
    {
        public int ID { get; set; }
        public string animal { get; set; }
        public string animalHabitatName { get; set; }
        public string animalSpecies { get; set; }
    }
}
