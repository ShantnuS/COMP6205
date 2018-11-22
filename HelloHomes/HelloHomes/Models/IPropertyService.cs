using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public interface IPropertyService
    {
        Task<Property> FindAsync(long id);
        Task<Property[]> GetAllAsync(int? count = null, int? page = null);
        Task<Property[]> GetAllApprovedAsync(int? count = null, int? page = null);
        Task<Property[]> GetAllUnapprovedAsync(int? count = null, int? page = null);
        Task SaveAsync(Property property);
    }
}
