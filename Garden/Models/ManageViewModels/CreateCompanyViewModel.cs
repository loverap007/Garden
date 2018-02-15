using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.Models.ManageViewModels
{
    public class CreateCompanyViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Описание не может быть длиннее 200 символов")]
        public string Description { get; set; }

        public IFormFile File { get; set; }
    }
}
