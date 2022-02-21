using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Shared
{
    public class Contact
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string name { get; set; }
        public int phone { get; set; }
        public int cellPhone { get; set; }
    }
}