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

        public async Task<int> DeleteCustomerDetails(int id)
        {
            var result = await _context.CustomerTbls.Where(it => it.Id == id).ToListAsync();
            _context.CustomerTbls.RemoveRange(result);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            try
            {
                var result = await _context.CustomerTbls.AsNoTracking().Select(it => new Customer
                {
                    Id = it.Id,
                    CustName = it.CustName,
                    Email = it.Email,
                    Mobile = it.Mobile
                }).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<int> SaveCustomer(Customer customer)
        {
            var entity = new CustomerTbl        
            {
                CustName = customer.CustName,
                Email = customer.Email,
                Mobile = customer.Mobile
            };

            try
            {
                _context.CustomerTbls.Add(entity);
                await _context.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception)
            {
                return 0;                
            }            
        }

        public async Task<int> UpdateCustomerDetails(int id, Customer model)
        {
            try
            {
                var customer = await _context.CustomerTbls.FirstOrDefaultAsync(c => c.Id == id);
                if (customer != null)
                {
                    customer.CustName = model.CustName;
                    customer.Mobile = model.Mobile;
                    customer.Email = model.Email;

                    await _context.SaveChangesAsync();
                }
                return 1;
            }
            catch(Exception)
            {
                
                return 0; 
            }
        }
    }
}
