namespace UniversityAccessControl.Models;

public abstract class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }

    protected User(string id, string name, string role)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    public abstract bool HasAccess(Room room);
}