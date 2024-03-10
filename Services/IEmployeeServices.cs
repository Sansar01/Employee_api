using Employee_api.Models;

namespace Employee_api.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> Get();

        Task<Employee> Get(string id);

        Task Create(Employee employee);

        Task Update(string id, Employee employee);

        Task Delete(string id);
    }
}
