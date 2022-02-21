using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Shared;

namespace PhoneBook.Server
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options){}

        public DbSet<Contact> contacts { get; set; }
    }
}