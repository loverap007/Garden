using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Models
{
    public class AddPlantViewModel
    {
        [Required]
        [Display(Name = "Название")]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Name { get; set; }

        [Required]
        public int Type { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
