using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoolandiaMVC.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string ImageFileName { get; set; }
        public Image ImageFileData { get; set; }
        public int IdAnimal { get; set; }
    }
}
