// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Account.cs" company="">
//   
// </copyright>
// <summary>
//   The account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="tweakotine">
        /// The tweakotine.
        /// </param>
        /// <param name="karma">
        /// The karma.
        /// </param>
        /// <param name="birthdate">
        /// The birthdate.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="gender">
        /// The gender.
        /// </param>
        public Account(
            int userId, 
            string username, 
            string email, 
            int tweakotine, 
            int karma, 
            DateTime birthdate, 
            string city, 
            char gender)
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

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the tweakotine.
        /// </summary>
        public int Tweakotine { get; set; }

        /// <summary>
        /// Gets or sets the karma.
        /// </summary>
        public int Karma { get; set; }

        /// <summary>
        /// Gets or sets the birthdate.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public char Gender { get; set; }
    }
}