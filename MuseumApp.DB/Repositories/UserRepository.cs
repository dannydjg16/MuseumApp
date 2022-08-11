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
            var dbUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);

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
            var dbUser = _context.Users.SingleOrDefault(u => u.Id == userID);
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
            var dbUser = _context.Users.SingleOrDefault(u => u.Id == user.ID);

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

            // If dbuser CurrentCity is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(user.CurrentCity))
            {
                // Change the CurrentCity 
                dbUser.CurrentCity = user.CurrentCity;
            }

            // If dbuser CurrentCountry is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(user.CurrentCountry))
            {
                // Change the CurrentCountry 
                dbUser.CurrentCountry = user.CurrentCountry;
            }

            // If dbuser CurrentStateProvince is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(user.CurrentStateProvince))
            {
                // Change the CurrentStateProvince 
                dbUser.CurrentStateProvince = user.CurrentStateProvince;
            }

            _context.SaveChanges();

            return true;
        }

        // Get User By Email
        public Domain.Models.User GetUserByEmail(string email)
        {
            try
            {
                IQueryable<User> fullUsers = _context.Users.Include(user => user.Likes);


                if (fullUsers == null)
                {
                    return null;
                }

                var user = Mappers.UserMapper.Map(fullUsers.SingleOrDefault(u => u.Email == email));

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
            IQueryable<User> fullUsers = _context.Users.Include(user => user.Likes);

            if (fullUsers == null)
            {
                return null;
            }

            var user = Mappers.UserMapper.Map(fullUsers.SingleOrDefault(u => u.Id == id));

            return user;
        }

        // Get all users/search by users name
        public IEnumerable<Domain.Models.User> GetUsers(string name = null)
        {
            List<User> dbUsers;

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
