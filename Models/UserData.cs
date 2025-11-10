namespace UniversityAccessControl.Models;

public class UserData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string? StudentId { get; set; }  
    public string? EmployeeId { get; set; } 
    public string? StaffId { get; set; }    
    public string? Department { get; set; } 
    public int AccessLevel { get; set; }
    public List<string> Courses { get; set; }

    public UserData(string id, string name, string role)
    {
        Id = id;
        Name = name;
        Role = role;
        Courses = new List<string>();
        AccessLevel = 0; 
    }
}