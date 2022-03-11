using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class Contact
    {
        public Contact (string name, string cellPhone, string phone) {
            this.name = name;
            this.cellPhone = cellPhone;
            this.phone = phone;
        }

        public Contact (string name) {
            this.name = name;
        }

        public Contact (){}

        [Key]
        public int id { get; set;}
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(15, ErrorMessage = "El nombre del contacto es demasiado largo. Intenta con otro.")]
        [MinLength(3, ErrorMessage = "No es un nombre de contacto válido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "No es un nombre de contacto válido.")]
        public string name { get; set; }
        [Phone(ErrorMessage = "No es un número de teléfono válido.")]
        [MaxLength(7, ErrorMessage = "Debe ingresar un número de telefono fijo que contenga maximo 7 digitos") ,
        MinLength(7, ErrorMessage = "Debe ingresar un número de telefono fijo que contenga minimo 7 digitos")]
        public string phone { get; set; }
        [Phone(ErrorMessage = "No es un número de celular válido.")]
        [MaxLength(10, ErrorMessage = "Debe ingresar un número de celular que contenga maximo 10 digitos") ,
        MinLength(10, ErrorMessage = "Debe ingresar un número de celular que contenga minimo 10 digitos")]
        public string cellPhone { get; set; }

        public bool equals(Contact contact)
        {
            if (this.name.Trim().Equals(contact.name.Trim())){
                return true;
            }
            return false;
        }
    }
}