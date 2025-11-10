using UniversityAccessControl.Models;
using UniversityAccessControl.Patterns.Factory;
using UniversityAccessControl.Patterns.Observer;
using UniversityAccessControl.Patterns.Singleton;
using UniversityAccessControl.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== University Access Control System ===");
        Console.WriteLine("Demonstrating Singleton, Factory Method, and Observer Patterns\n");

        // Initialize components
        var userFactory = new UniversityUserFactory();
        var accessSystem = new AccessControlSystem(userFactory);

        // Create rooms with observers
        var labRoom = new RoomWithObservers("LAB_A", "Computer Lab A", 30);
        var libraryRoom = new RoomWithObservers("LIB_01", "Main Library", 100);

        // Create observers
        var mainDashboard = new Dashboard("MAIN_DASH");
        var mobileApp = new MobileApp("STUDENT_APP");
        var adminDashboard = new Dashboard("ADMIN_DASH");

        // Attach observers to rooms
        labRoom.Attach(mainDashboard);
        labRoom.Attach(mobileApp);
        libraryRoom.Attach(adminDashboard);

        // Test data
        var studentData = new UserData("S001", "John Student", "STUDENT")
        {
            StudentId = "STU12345",
            Courses = new List<string> { "CS101", "MATH202" }
        };

        var lecturerData = new UserData("L001", "Dr. Smith", "LECTURER")
        {
            EmployeeId = "EMP55001",
            Department = "Computer Science"
        };

        var adminData = new UserData("A001", "Admin User", "ADMIN")
        {
            StaffId = "ADM77001",
            AccessLevel = 5
        };

        // Demonstrate the system
        Console.WriteLine("\n--- Testing Student Access ---");
        TestUserAccess(accessSystem, studentData, labRoom, labRoom);

        Console.WriteLine("\n--- Testing Lecturer Access ---");
        TestUserAccess(accessSystem, lecturerData, labRoom, labRoom);

        Console.WriteLine("\n--- Testing Admin Access ---");
        TestUserAccess(accessSystem, adminData, libraryRoom, libraryRoom);

        // Try accessing restricted area
        var serverRoom = new RoomWithObservers("SERVER_ROOM", "Server Room", 5);
        Console.WriteLine("\n--- Testing Restricted Area ---");
        TestUserAccess(accessSystem, studentData, serverRoom, serverRoom);

        // Display logs
        Logger.Instance.DisplayLogs();

        Console.WriteLine("\n=== System Demonstration Complete ===");
    }

    static void TestUserAccess(AccessControlSystem system, UserData userData, Room room, RoomWithObservers observableRoom)
    {
        var user = system.AuthenticateUser($"CARD_{userData.Id}", userData);
        if (user != null)
        {
            bool granted = system.GrantAccess(user, room, observableRoom);
            Console.WriteLine($"Result: Access {(granted ? "GRANTED" : "DENIED")} for {user.Name} to {room.Name}");
        }
    }
}