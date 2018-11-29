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
            return GetAll(count, page).Where(x => x.ApprovalStatus == Property.ApprovalEnum.Approved).ToArrayAsync();
        }

        public Task<Property[]> GetAllUnapprovedAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).Where(x => x.ApprovalStatus == Property.ApprovalEnum.Pending).ToArrayAsync();
        }

        public Task<Property[]> GetAllForLandlordAsync(long landlordId, int? count = null, int? page = null)
        {
            return GetAll(count, page).Where(x => x.LandlordID == landlordId).ToArrayAsync();
        }

        public async Task SaveAsync(Property property)
        {
            var isNew = property.Id == default(long);

            _context.Entry(property).State = isNew ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateApprovalStatusAsync(long id, Property.ApprovalEnum approvalEnum, string approvalComment)
        {
            Property property = _context.Property.First(x => x.Id == id);
            property.ApprovalStatus = approvalEnum;
            property.ApprovalComment = approvalComment;
            await _context.SaveChangesAsync();
        }

        public async void RemovePropertyAsync(long id)
        {
            Property property = await FindAsync(id);
            _context.Remove(property);
            await _context.SaveChangesAsync();

            Property[] properties = await GetAllAsync();

            for (long i = id + 1; i < properties.Length; i++)
            {
                properties[i].Id = i - 1;
                await SaveAsync(properties[i]);
            }
        }
    }
}
