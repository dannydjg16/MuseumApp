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

        public bool EditAccount(Domain.Models.User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == user.ID);

            if (dbUser == null)
            {
                return false;
            }

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.FromLocation = user.FromLocation;
            _context.SaveChanges();
            return true;
        }

        public Domain.Models.User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

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

        public IEnumerable<Domain.Models.User> GetUsers(string name = null)
        {
            throw new NotImplementedException();
        }
    }
}
