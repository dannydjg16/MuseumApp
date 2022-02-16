﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public bool DeleteAccount(int userID)
        {
            throw new NotImplementedException();
        }

        public bool EditAccount(Domain.Models.User user)
        {
            throw new NotImplementedException();
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