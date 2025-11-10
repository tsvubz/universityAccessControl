# University Access Control System

A C# implementation demonstrating three key design patterns:
- **Singleton** - AccessPolicyManager and Logger
- **Factory Method** - User creation system
- **Observer** - Real-time room occupancy notifications

## Patterns Demonstrated

### Singleton Pattern
- `AccessPolicyManager` - Global access policy management
- `Logger` - Centralized logging service

### Factory Method Pattern  
- `UniversityUserFactory` - Creates different user types (Student, Lecturer, Admin)

### Observer Pattern
- Room occupancy notifications to multiple subscribers
- Dashboard and MobileApp observers

## How to Run

```bash
git clone https://github.com/yourusername/UniversityAccessControl.git
cd UniversityAccessControl
dotnet run