using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public class PersonService : IPersonService
    {

        private readonly HelloHomesPersonContext _context;

        public PersonService()
        {
            var connString = Startup.personConnString;
            var options = new DbContextOptionsBuilder<HelloHomesPersonContext>()
                .UseSqlServer(connString)
                .Options;

            _context = new HelloHomesPersonContext(options);
        }

        public PersonService(HelloHomesPersonContext context)
        {
            _context = context;
        }

        public Task<Person> FindAsync(long id)
        {
            return _context.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Person> FindByEmailAsync(string emailAddress)
        {
            return _context.Person.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
        }

        public Task<Person> FindByEmailAsync(string emailAddress, string password)
        {
            return _context.Person.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress && x.Password == password);
        }

        public async Task SaveAsync(Person person)
        {
            var isNew = person.Id == default(long);

            _context.Entry(person).State = isNew ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
