using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHomes.Models
{
    public class PropertyService : IPropertyService
    {
        private readonly HelloHomesPropertyContext _context;

        public PropertyService()
        {
            var connString = Startup.propertyConnString;
            var options = new DbContextOptionsBuilder<HelloHomesPropertyContext>()
                .UseSqlServer(connString)
                .Options;

            _context = new HelloHomesPropertyContext(options);
        }

        public PropertyService(HelloHomesPropertyContext context)
        {
            _context = context;
        }

        public Task<Property> FindAsync(long id)
        {
            return _context.Property.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Property> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _context.Property
                        .Skip(actualCount * page.GetValueOrDefault(0))
                        .Take(actualCount);
        }

        public Task<Property[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public Task<Property[]> GetAllApprovedAsync(int? count = null, int? page = null)
        {
            Func<Property[]> function = () =>
               {
                   Property[] ret = { };

                   foreach (Property property in GetAll(count, page))
                   {
                       if (property.ApprovalStatus == Property.ApprovalEnum.Approved)
                       {
                           ret.Append(property);
                       }
                   }

                   return ret;
               };

            return Task.Run(function);
        }

        public Task<Property[]> GetAllUnapprovedAsync(int? count = null, int? page = null)
        {
            Func<Property[]> function = () =>
               {
                   Property[] ret = { };

                   foreach (Property property in GetAll(count, page))
                   {
                       if (property.ApprovalStatus == Property.ApprovalEnum.Pending)
                       {
                           ret.Append(property);
                       }
                   }

                   return ret;
               };

            return Task.Run(function);
        }

        public Task<Property[]> GetAllForLandlordAsync(long landlordId)
        {
            Func<Property[]> function = () =>
               {
                   Property[] ret = { };

                   foreach (Property property in GetAll())
                   {
                       if (property.LandlordID == landlordId)
                       {
                           ret.Append(property);
                       }
                   }

                   return ret;
               };

            return Task.Run(function);
        }

        public async Task SaveAsync(Property property)
        {
            var isNew = property.Id == default(long);

            _context.Entry(property).State = isNew ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
