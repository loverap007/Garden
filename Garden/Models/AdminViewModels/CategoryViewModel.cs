using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Models
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "Название")]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Title { get; set; }
    }
}
