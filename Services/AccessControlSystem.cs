using UniversityAccessControl.Models;
using UniversityAccessControl.Patterns.Factory;
using UniversityAccessControl.Patterns.Observer;
using UniversityAccessControl.Patterns.Singleton;

namespace UniversityAccessControl.Services;

public class AccessControlSystem
{
    private readonly AccessPolicyManager _policyManager;
    private readonly IUserFactory _userFactory;
    private readonly Logger _logger;

    public AccessControlSystem(IUserFactory userFactory)
    {
        _policyManager = AccessPolicyManager.Instance;
        _userFactory = userFactory;
        _logger = Logger.Instance;
    }

    public User? AuthenticateUser(string cardId, UserData userData)
    {
        try
        {
            var user = _userFactory.CreateUser(userData.Role, userData);
            _logger.Log($"User authenticated: {user.Name} ({user.Role}) with card {cardId}");
            return user;
        }
        catch (ArgumentException ex)
        {
            _logger.Log($"Authentication failed for card {cardId}: {ex.Message}");
            return null;
        }
    }

    public bool GrantAccess(User user, Room room, IRoomSubject roomSubject)
    {
        bool allowed = _policyManager.ValidateAccess(user, room);
        
        if (allowed)
        {
            _logger.Log($"Access GRANTED: {user.Name} to {room.Name}");
            
            // Notify observers about room occupancy change
            if (roomSubject is RoomWithObservers observableRoom)
            {
                observableRoom.SetOccupied(true);
            }
        }
        else
        {
            _logger.Log($"Access DENIED: {user.Name} to {room.Name}");
        }

        return allowed;
    }
}

// Observable room implementation
public class RoomWithObservers : Models.Room, IRoomSubject
{
    private readonly List<IRoomObserver> _observers;
    private bool _isOccupied;

    public RoomWithObservers(string roomId, string name, int capacity) 
        : base(roomId, name, capacity)
    {
        _observers = new List<IRoomObserver>();
        _isOccupied = false;
    }

    public bool IsOccupied => _isOccupied;

    public void Attach(IRoomObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Detach(IRoomObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this, _isOccupied);
        }
    }

    public void SetOccupied(bool occupied)
    {
        if (_isOccupied != occupied)
        {
            _isOccupied = occupied;
            NotifyObservers();
        }
    }
}