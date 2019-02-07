using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApiRest.Models
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("IsComplete")]
        public bool IsComplete { get; set; }
    }
}
