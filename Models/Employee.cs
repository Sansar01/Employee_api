using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Employee_api.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("emp_Name")]
        public string? emp_Name { get; set; } = string.Empty;

        [BsonElement("emp_Email")]
        public string emp_Email { get; set;} = string.Empty;

        [BsonElement("emp_Gender")]
        public string emp_Gender { get; set; } = string.Empty;

        [BsonElement("emp_Address")]
        public string emp_Address { get; set; } = string.Empty;

    }
}
