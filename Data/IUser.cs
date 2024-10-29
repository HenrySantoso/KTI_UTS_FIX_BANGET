using System;
using SampleSecureWeb.Models;

namespace SampleSecureWeb.Data;

public interface IUser
{
    User Registration(User user);
    User Login(User user);
    IEnumerable<User> GetUsers();
    User GetUserByUsername(string username);
    void UpdatePassword(User user);
}
