using UniversityAccessControl.Models;

namespace UniversityAccessControl.Patterns.Factory;

public class UniversityUserFactory : IUserFactory
{
    public User CreateUser(string type, UserData data)
    {
        return type.ToUpper() switch
        {
            "STUDENT" => new Student(data.Id, data.Name, data.StudentId, data.Courses),
            "LECTURER" => new Lecturer(data.Id, data.Name, data.EmployeeId, data.Department),
            "ADMIN" => new AdminStaff(data.Id, data.Name, data.StaffId, data.AccessLevel),
            _ => throw new ArgumentException($"Unknown user type: {type}")
        };
    }
}