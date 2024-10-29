using System;
using SampleSecureWeb.Models;

namespace SampleSecureWeb.Data;

public class UserData : IUser
{
    private readonly ApplicationDbContext _db;

    public UserData(ApplicationDbContext db)
    {
        _db = db;
    }

    public User Login(User user)
    {
        var _user = _db.Users.FirstOrDefault(u => u.Username == user.Username);
        if (_user == null)
        {
            throw new Exception("User not found");
        }
        if (!BCrypt.Net.BCrypt.Verify(user.Password, _user.Password))
        {
            throw new Exception("Password is  inccorect");
        }
        return _user;
    }

    public User Registration(User user)
    {
        try
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IEnumerable<User> GetUsers()
    {
        var users = _db.Users.OrderBy(u => u.Username);
        return users;
    }

    public User GetUserByUsername(string username)
    {
        // Mengambil user dari database berdasarkan username
        var user = _db.Users.FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public void UpdatePassword(User user)
    {
        var existingUser = _db.Users.FirstOrDefault(u => u.Username == user.Username);
        if (existingUser != null)
        {
            existingUser.Password = user.Password;
            _db.SaveChanges();
        }
    }
}
