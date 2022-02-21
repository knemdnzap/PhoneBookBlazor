using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Shared;

namespace PhoneBook.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public PhoneBookController(ContactDbContext context)
        {
            _context = context;
        }

        // Operaciones

        [HttpGet]
        public List<Contact> GetContacts()
        {
            return _context.contacts.ToList();
        }

        [HttpGet("{name}")]
        public Contact GetContactByName(string name)
        {
            return _context.contacts.SingleOrDefault(e => e.name == name);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var emp = _context.contacts.SingleOrDefault(x => x.name == name);
            if ( emp == null)
            {
                return NotFound("Contacto con el nombre " + name + " no existe.");
            }
            _context.contacts.Remove(emp);
            _context.SaveChanges();
            return Ok("El contacto con el nombre " + name + " se a eliminado correctamente.");
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _context.contacts.Add(contact);
            _context.SaveChanges();
            return Created("api/contact/" + contact.name, contact);
        }

        [HttpGet("{name}")]
        public IActionResult Find(string name, Contact contact)
        {
            var findName = _context.contacts.SingleOrDefault(x => x.name == name);
            if ( findName == null)
            {
                return NotFound("Contacto con el nombre " + name + " no existe.");
            }
            // if (contact.Name != null)
            // {
            //     findName.Name = contact.Name;
            // }
            // if (contact.Phone != 0)
            // {
            //     findName.Phone = contact.Phone;
            // }
            // if (contact.CellPhone != 0)
            // {
            //     findName.CellPhone = contact.CellPhone;
            // }
            return Ok($"Tu contacto {name} tiene el numero de telefono");
        }
    }
}