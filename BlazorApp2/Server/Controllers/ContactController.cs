using Microsoft.AspNetCore.Mvc;
using BlazorApp2.Shared;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            _context = context;
        }

        // Operaciones

        // GET: api/Contact
        [HttpGet]
        public IEnumerable<Contact> GetAllEmployees()
        {
            try{
                return _context.Contacts.ToList();
            }catch (Exception e){
                throw;
            }
        }

        [HttpGet("{name}")]
        public Contact GetContactByName(string name)
        {
            try {
                return _context.Contacts.SingleOrDefault(contact => contact.name == name);
            }catch (Exception){
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact){
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(_context.Contacts.ToList());
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteContact(string name)
        {
            var contactDelete = _context.Contacts.SingleOrDefault(delete => delete.name == name);
            try{
                if (contactDelete == null)
                {
                    return NotFound("Contacto con el nombre " + name + " no existe.");
                } else {
                    _context.Contacts.Remove(contactDelete);
                    _context.SaveChanges();
                    return Ok("Contacto con el nombre " + name + " se a eliminado correctamente.");
                }
            } catch (Exception e){
                return NotFound("No se elimino el contacto correctamente.");
            }
        }

        [HttpGet("exist/{name}")]
        public bool ExitsContact(string name)
        {
            var contact = _context.Contacts.FirstOrDefault(exist => exist.name == name);
            if (contact != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}