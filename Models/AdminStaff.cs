namespace UniversityAccessControl.Models;

public class AdminStaff : User
{
    public string StaffId { get; set; }
    public int AccessLevel { get; set; }

    public AdminStaff(string id, string name, string staffId, int accessLevel) 
        : base(id, name, "ADMIN")
    {
        StaffId = staffId;
        AccessLevel = accessLevel;
    }

    public override bool HasAccess(Room room)
    {
        // Admins have 24/7 access
        return true;
    }
}