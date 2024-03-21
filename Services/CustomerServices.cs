using Employee_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Employee_api.Services
{
    public class CustomerServices : ICustomerServices
    {

        private readonly IMongoCollection<Customer> _collection;
        public CustomerServices(IEmployeeStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _collection = database.GetCollection<Customer>(setting.UserCollectionName);
        }

        //public async Task<IEnumerable<User>> Get() =>
        //   await _collection.Find(_ => true).ToListAsync();

        public async Task<IEnumerable<Customer>> Get()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$lookup",new BsonDocument
                {
                    {"from","Employee" },
                    {"localField","EmpId" },
                    {"foreignField","_id" },
                    {"as","employee_user" }
                }),
                new BsonDocument("$unwind","$employee_user"),
                new BsonDocument("$project",new BsonDocument
                {
                    {"_id", 1},
                    { "EmpId",1},
                    {"customerName",1 },
                    {"customerMail",1},
                    {"customerGender",1 },
                    {"customerAddress",1 },
                    {"emp_Name","$employee_user.emp_Name" }
                })
            };

            var results = await _collection.Aggregate<Customer>(pipeline).ToListAsync();

            return results;


            //var usersWithPosts = _collection
            // .AsQueryable()
            // .ToList();

            //return usersWithPosts;
        }


        public async Task<Customer> Get(string id) =>
            await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();


        public async Task Create(Customer customer) =>
            await _collection.InsertOneAsync(customer);


        public async Task Update(string id, Customer customer) =>
            await _collection
            .ReplaceOneAsync(a => a.Id == id, customer);


        public async Task Delete(string id) =>
            await _collection.DeleteOneAsync(a => a.Id == id);
    }
}
