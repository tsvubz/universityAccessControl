using UniversityAccessControl.Models;

namespace UniversityAccessControl.Patterns.Observer;

public class MobileApp : IRoomObserver
{
    public string AppId { get; }

    public MobileApp(string appId)
    {
        AppId = appId;
    }

    public void Update(Room room, bool isOccupied)
    {
        string status = isOccupied ? "occupied" : "available";
        Logger.Instance.Log($"MobileApp {AppId}: Room {room.RoomId} is now {status}");
        SendNotification($"Room {room.Name} is now {status}");
    }

    private void SendNotification(string message)
    {
        Console.WriteLine($"📱 Mobile Notification: {message}");
    }
}