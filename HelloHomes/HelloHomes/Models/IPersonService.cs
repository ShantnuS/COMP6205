using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public interface IPersonService
    {
        Task<Person> FindAsync(long id);
        Task<Person> FindByEmailAsync(string emailAddress);
        Task<Person> FindByEmailAsync(string emailAddress, string password);
        Task SaveAsync(Person person);
    }
}
