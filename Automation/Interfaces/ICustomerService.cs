using Automation.Model;

namespace Automation.Interfaces
{
    public interface ICustomerService
    {
        Task<ICollection<Customer>> GetAllCustomers();

        Task<int> SaveCustomer(Customer customer);

        Task<int> UpdateCustomerDetails(int id, Customer model);

        Task<int> DeleteCustomerDetails(int id);
    }
}
