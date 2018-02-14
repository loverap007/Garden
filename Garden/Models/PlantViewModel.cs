using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Models
{
    public class PlantViewModel
    {
        public Plant Plant { get; set; }
        
        public List<PlantPhoto> PlantPhotos { get; set; }

        public List<Parameter> Parameters { get; set; }

        public List<Offer> Offers { get; set; }
    }
}
