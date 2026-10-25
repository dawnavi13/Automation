using Automation.Data;
using Automation.Interfaces;
using Automation.Model;
using Microsoft.EntityFrameworkCore;

namespace Automation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> DeleteCustomerDetails(int id)
        {
            var result = _context.CustomerTbls.Where(it => it.Id == id);
            _context.CustomerTbls.RemoveRange(result);
            _context.SaveChanges();
            return Task.FromResult(1);
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            var result = await _context.CustomerTbls.AsNoTracking().Select(it=> new Customer
            {
                Id = it.Id,
                CustName = it.CustName,
                Email = it.Email,
                Mobile = it.Mobile
            }).ToListAsync();

            return result;
        }

        public async Task<int> SaveCustomer(Customer customer)
        {
            var entity = new CustomerTbl        
            {
                CustName = customer.CustName,
                Email = customer.Email,
                Mobile = customer.Mobile
            };

            _context.CustomerTbls.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public Task<int> UpdateCustomerDetails(int id, Customer model)
        {
            var customer = _context.CustomerTbls.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.CustName = model.CustName;
                customer.Mobile = model.Mobile;
                customer.Email = model.Email;
                
                _context.SaveChanges();
            }
            return Task.FromResult(id);
        }
    }
}
