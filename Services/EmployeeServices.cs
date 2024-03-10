using Employee_api.Models;
using MongoDB.Driver;

namespace Employee_api.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        private readonly IMongoCollection<Employee> _collection;
        public EmployeeServices(IEmployeeStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _collection = database.GetCollection<Employee>(setting.EmployeeCollectionName);
        }

        public async Task<IEnumerable<Employee>> Get() =>
           await _collection.Find(_ => true).ToListAsync();


        public async Task<Employee> Get(string id) =>
            await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();


        public async Task Create(Employee employee) =>
            await _collection.InsertOneAsync(employee);


        public async Task Update(string id, Employee employee) =>
            await _collection
            .ReplaceOneAsync(a => a.Id == id, employee);


        public async Task Delete(string id) =>
            await _collection.DeleteOneAsync(a => a.Id == id);
    }
}
