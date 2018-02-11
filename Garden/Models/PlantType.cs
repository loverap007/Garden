using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class PlantType : AModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Name { get; set; }

        public List<Plant> Plants { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
