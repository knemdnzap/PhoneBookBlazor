using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class Contact
    {
        [Key]
        public int id { get; set;}
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string name { get; set; }
        public string phone { get; set; }
        public string cellPhone { get; set; }
    }
}