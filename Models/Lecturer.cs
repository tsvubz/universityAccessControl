namespace UniversityAccessControl.Models;

public class Lecturer : User
{
    public string EmployeeId { get; set; }
    public string Department { get; set; }

    public Lecturer(string id, string name, string employeeId, string department) 
        : base(id, name, "LECTURER")
    {
        EmployeeId = employeeId;
        Department = department;
    }

    public override bool HasAccess(Room room)
    {
        // Lecturers have extended access
        return DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 22;
    }
}