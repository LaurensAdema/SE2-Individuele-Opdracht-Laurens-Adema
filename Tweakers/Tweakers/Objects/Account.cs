using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Account
    {
        public Account(int userId, string username, string email, int tweakotine, int karma, DateTime birthdate, string city, char gender)
        {
            this.UserID = userId;
            this.Username = username;
            this.Email = email;
            this.Tweakotine = tweakotine;
            this.Karma = karma;
            this.Birthdate = birthdate;
            this.City = city;
            this.Gender = gender;
        }

        public int UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int Tweakotine { get; set; }

        public int Karma { get; set; }

        public DateTime Birthdate { get; set; }

        public string City { get; set; }

        public char Gender { get; set; }
    }
}
