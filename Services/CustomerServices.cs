using Employee_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Employee_api.Services
{
    public class CustomerServices : ICustomerServices
    {

        private readonly IMongoCollection<User> _collection;
        public CustomerServices(IEmployeeStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _collection = database.GetCollection<User>(setting.UserCollectionName);
        }

        //public async Task<IEnumerable<User>> Get() =>
        //   await _collection.Find(_ => true).ToListAsync();

        public async Task<IEnumerable<User>> Get()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$lookup",new BsonDocument
                {
                    {"from","EmployeeCollectionName" },
                    {"localField","EmpId" },
                    {"foreignField","_id" },
                    {"as","employee_user" }
                }),
                new BsonDocument("$unwind","$employee_user"),
                new BsonDocument("$project",new BsonDocument
                {
                    {"_id", 1},
                    { "EmpId",1},
                    {"username",1 },
                    {"employeeName","$employee_user.employeeName" }
                })
            };

            var results = await _collection.Aggregate<User>(pipeline).ToListAsync();

            return results;
        }


        public async Task<User> Get(string id) =>
            await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();


        public async Task Create(User user) =>
            await _collection.InsertOneAsync(user);


        public async Task Update(string id, User user) =>
            await _collection
            .ReplaceOneAsync(a => a.Id == id, user);


        public async Task Delete(string id) =>
            await _collection.DeleteOneAsync(a => a.Id == id);
    }
}
