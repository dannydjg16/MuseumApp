using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class UserRepository: IUserInterface
    {
        private readonly ArtApplicationContext _context;

        public UserRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Create Account
        public bool CreateAccount(Domain.Models.User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == user.ID);

            if(dbUser != null)
            {
                return false;
            }

            _context.Users.Add(Mappers.UserMapper.Map(user));
            _context.SaveChanges();
            return true;
        }

        // Delete Account
        public bool DeleteAccount(int userID)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == userID);
            if (dbUser == null)
            {
                return false;
            }
            _context.Users.Remove(dbUser);
            _context.SaveChanges();
            return true;
        }

        // Edit Account
        public bool EditAccount(Domain.Models.User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == user.ID);

            if (dbUser == null)
            {
                return false;
            }

            // If dbuser name is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(user.Name))
            {
                // Change the name 
                dbUser.Name = user.Name;
            }

            // If dbuser location is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(user.FromLocation))
            {
                // Change the location 
                dbUser.FromLocation = user.FromLocation;
            }

            // If dbuser profilepicURL is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(user.ProfilePicURL))
            {
                // Change the name 
                dbUser.ProfilePicUrl = user.ProfilePicURL;
            }

            _context.SaveChanges();
            return true;
        }

        // Get User By Email - can implement later
        public Domain.Models.User GetUserByEmail(string email)
        {
            try
            {
                var dbUser = _context.Users.FirstOrDefault(u => u.Email == email);

                if (dbUser == null)
                {
                    return null;
                }

                Domain.Models.User user = Mappers.UserMapper.Map(dbUser);

                return user;
            }
            catch(Exception e)
            {
                Console.Write("Exception: " + e);
            }
            return null;
        }

        // Get Users By ID
        public Domain.Models.User GetUserByID(int id)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser == null)
            {
                return null;
            }
            Domain.Models.User user = new Domain.Models.User
            {
                ID = dbUser.Id,
                Name = dbUser.Name,
                Email = dbUser.Email,
                FromLocation = dbUser.FromLocation
            };
            return user;
        }

        // Get all users/search by users name
        public IEnumerable<Domain.Models.User> GetUsers(string name = null)
        {
            List<User> dbUsers = new List<User>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                dbUsers = _context.Users.Where(u => u.Name.Contains(name)).ToList();
            }
            else
            {
                dbUsers = _context.Users.ToList();
            }

            if (!dbUsers.Any())
            {
                return new List<Domain.Models.User>();
            }

            List<Domain.Models.User> users = dbUsers.Select(u => Mappers.UserMapper.Map(u)).ToList();

            return users; 
        }
    }
}
