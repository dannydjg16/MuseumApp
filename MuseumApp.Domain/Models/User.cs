﻿using System;
namespace MuseumApp.Domain.Models
{
    public class User
    {
        public User()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FromLocation { get; set; }
    }
}