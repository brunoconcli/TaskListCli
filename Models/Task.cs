namespace TaskListCli.Models;

public class Task
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required Boolean Completed { get; set; }
}