using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class Plant : AModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string PathToAvatar { get; set; }

        public List<PlantPhoto> Photos { get; set; }

        public int PlantTypeId { get; set; }
        public PlantType PlantType { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
