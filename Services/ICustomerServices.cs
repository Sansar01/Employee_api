using Employee_api.Models;

namespace Employee_api.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> Get();

        Task<Customer> Get(string id);

        Task Create(Customer customer);

        Task Update(string id, Customer customer);

        Task Delete(string id);
    }
}
