using UniversityAccessControl.Models;
using UniversityAccessControl.Patterns.Singleton; 

namespace UniversityAccessControl.Patterns.Observer;

public class Dashboard : IRoomObserver
{
    public string DashboardId { get; }

    public Dashboard(string dashboardId)
    {
        DashboardId = dashboardId;
    }

    public void Update(Room room, bool isOccupied)
    {
        string status = isOccupied ? "OCCUPIED" : "AVAILABLE";
        Logger.Instance.Log($"Dashboard {DashboardId}: Room {room.RoomId} is now {status}");
    }

    public void DisplayRoomStatus(Room room, bool isOccupied)
    {
        string status = isOccupied ? "🔴 OCCUPIED" : "🟢 AVAILABLE";
        Console.WriteLine($"Dashboard {DashboardId}: {room.Name} - {status}");
    }
}