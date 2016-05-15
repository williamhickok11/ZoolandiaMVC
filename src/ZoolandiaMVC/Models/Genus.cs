using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoolandiaMVC.Models
{
    public class Genus
    {
        public int ID { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string URL { get; set; }
    }
}
