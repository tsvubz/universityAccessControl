using UniversityAccessControl.Models;

namespace UniversityAccessControl.Patterns.Singleton;

public class AccessPolicyManager
{
    private static AccessPolicyManager _instance;
    private static readonly object _lock = new object();
    
    private readonly Dictionary<string, bool> _accessRules;

    private AccessPolicyManager()
    {
        _accessRules = new Dictionary<string, bool>();
        InitializeDefaultRules();
    }

    public static AccessPolicyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new AccessPolicyManager();
                }
            }
            return _instance;
        }
    }

    public bool ValidateAccess(User user, Room room)
    {
        string key = $"{user.Role}:{room.RoomId}";
        
        if (_accessRules.ContainsKey(key))
        {
            return _accessRules[key] && user.HasAccess(room);
        }
        
        // Default deny
        return false;
    }

    private void InitializeDefaultRules()
    {
        // Student access rules
        _accessRules.Add("STUDENT:LAB_A", true);
        _accessRules.Add("STUDENT:LIB_01", true);
        _accessRules.Add("STUDENT:CLASS_101", true);

        // Lecturer access rules
        _accessRules.Add("LECTURER:LAB_A", true);
        _accessRules.Add("LECTURER:LIB_01", true);
        _accessRules.Add("LECTURER:CLASS_101", true);
        _accessRules.Add("LECTURER:RESEARCH_LAB", true);

        // Admin access rules
        _accessRules.Add("ADMIN:LAB_A", true);
        _accessRules.Add("ADMIN:LIB_01", true);
        _accessRules.Add("ADMIN:CLASS_101", true);
        _accessRules.Add("ADMIN:RESEARCH_LAB", true);
        _accessRules.Add("ADMIN:SERVER_ROOM", true);
    }

    public void AddAccessRule(string role, string roomId, bool allowed)
    {
        string key = $"{role}:{roomId}";
        _accessRules[key] = allowed;
    }
}