using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCperson.Models
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter persons name"), MaxLength(20), MinLength(3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter persons phone number"), MaxLength(8), MinLength(6)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter persons city"), MaxLength(20), MinLength(2)]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}

