using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCRUDOperations.Enitites;

public class User
{
    [BsonId] public Guid Id { get; set; }
    [BsonElement("Name")] public string Name { get; set; }
    [BsonElement("Family")] public string Family { get; set; }

    [BsonIgnore] public string FullName => $"{Name} {Family}";
}