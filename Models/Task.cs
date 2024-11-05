namespace TaskListCli.Models;

using MongoDB.Bson.Serialization.Attributes;

public class Task
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    public required string Description { get; set; }
    public required bool Completed { get; set; }
}