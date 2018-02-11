using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class Parameter : AModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Значение не может быть длиннее 50 символов")]
        public string Value { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public PlantType PlantType { get; set; }
    }
}
