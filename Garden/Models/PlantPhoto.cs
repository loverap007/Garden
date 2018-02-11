using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class PlantPhoto : Photo
    {
        public int? PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
