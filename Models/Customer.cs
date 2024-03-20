using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Employee_api.Models
{
    public class Customer
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string customerName { get; set; } = string.Empty;

        public string customerMail { get; set; } = string.Empty;

        public string customerGender { get; set; } = string.Empty;

        public string customerAddress { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string EmpId { get; set; } = string.Empty;

        [BsonIgnoreIfNull]
        public string? emp_Name { get; set; } = string.Empty;
    }
}
