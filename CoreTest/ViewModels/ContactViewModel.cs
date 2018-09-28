using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name should be at least 2 character long.")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
