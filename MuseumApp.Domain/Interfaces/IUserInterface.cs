using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface IUserInterface
    {
        bool CreateAccount(User user);
        bool DeleteAccount(int userID);
        bool EditAccount(User user);

        IEnumerable<User> GetUsers(string name = null);
        User GetUserByID(int id);
        User GetUserByEmail(string email);
        User GetFullUserByEmail(string email);
    }
}
