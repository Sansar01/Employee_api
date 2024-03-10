using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Employee_api.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string username { get; set; } = string.Empty;

        public string usermail { get; set; } = string.Empty;

        public string userGender { get; set; } = string.Empty;

        public string userAddress { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string EmpId { get; set; } = string.Empty;

        [BsonIgnoreIfNull]
        public string? employeeName { get; set; } = string.Empty;
    }
}
