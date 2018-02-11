using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class Company : AModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Название не может быть длиннее 50 символов")]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Описание не может быть длиннее 200 символов")]
        public string Description { get; set; }

        public bool Confirmed { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<Offer> Offers { get; set; }
    }
}
