using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Pollsters
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int PoliticsId { get; set; }

        [ForeignKey("FK_Politics_Pollster")]
        public Politics Politics { get; set; }
    }
}
