using Employee_api.Models;

namespace Employee_api.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<User>> Get();

        Task<User> Get(string id);

        Task Create(User user);

        Task Update(string id, User user);

        Task Delete(string id);
    }
}
