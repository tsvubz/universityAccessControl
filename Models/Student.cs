namespace UniversityAccessControl.Models;

public class Student : User
{
    public string StudentId { get; set; }
    public List<string> EnrolledCourses { get; set; }

    public Student(string id, string name, string studentId, List<string> courses) 
        : base(id, name, "STUDENT")
    {
        StudentId = studentId;
        EnrolledCourses = courses;
    }

    public override bool HasAccess(Room room)
    {
        // Students have access during day hours
        return DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 20;
    }
}