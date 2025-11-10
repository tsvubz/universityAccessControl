using UniversityAccessControl.Models;

namespace UniversityAccessControl.Patterns.Observer;

public interface IRoomObserver
{
    void Update(Room room, bool isOccupied);
}