using UniversityAccessControl.Models;

namespace UniversityAccessControl.Patterns.Factory;

public interface IUserFactory
{
    User CreateUser(string type, UserData data);
}