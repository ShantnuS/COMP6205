using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public class PropertyService : IPropertyService
    {
        public Task<Property> FindAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Property[]> GetAllApprovedAsync(int? count = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        public Task<Property[]> GetAllAsync(int? count = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        public Task<Property[]> GetAllUnapprovedAsync(int? count = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
