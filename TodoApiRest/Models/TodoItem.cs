using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApiRest.Models
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Name")]
        public string Name { get; set; }

        [DefaultValue(false)]
        [BsonElement("IsComplete")]
        public bool IsComplete { get; set; }
    }
}
