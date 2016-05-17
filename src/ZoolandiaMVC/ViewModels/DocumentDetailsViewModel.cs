using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ZoolandiaMVC.Models;

namespace ZoolandiaMVC.ViewModels
{
    public class DocumentDetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IdHabitat { get; set; }
        public int IdSpecies { get; set; }

        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public byte[] Contents { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadUserId { get; set; }
        public List<ZoolandiaMVC.Models.Document> Documents { get; set; }
    }
}
