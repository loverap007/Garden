using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class Offer : AModel
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        [Required]
        public int Count { get; set; }

        public DateTime Created { get; set; }
    }
}
