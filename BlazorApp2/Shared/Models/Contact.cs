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
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [MaxLength(7, ErrorMessage = "Debe ingresar un número de telefono fijo que contenga maximo 7 digitos") ,
        MinLength(7, ErrorMessage = "Debe ingresar un número de telefono fijo que contenga minimo 7 digitos")]
        public string phone { get; set; }
        [Required(ErrorMessage = "El celular es obligatorio")]
        [MaxLength(10, ErrorMessage = "Debe ingresar un número de celular que contenga maximo 10 digitos") ,
        MinLength(10, ErrorMessage = "Debe ingresar un número de celular que contenga minimo 10 digitos")]
        public string cellPhone { get; set; }
    }
}