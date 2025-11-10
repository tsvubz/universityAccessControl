namespace UniversityAccessControl.Models;

public class Room
{
    public string RoomId { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }

    public Room(string roomId, string name, int capacity)
    {
        RoomId = roomId;
        Name = name;
        Capacity = capacity;
    }

    public override string ToString() => $"{Name} ({RoomId})";
}