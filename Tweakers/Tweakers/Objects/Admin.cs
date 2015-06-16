// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="">
//   
// </copyright>
// <summary>
//   The admin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The admin.
    /// </summary>
    public class Admin : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class.
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
        /// <param name="adminId">
        /// The admin id.
        /// </param>
        /// <param name="fullName">
        /// The full name.
        /// </param>
        public Admin(
            int userId, 
            string username, 
            string email, 
            int tweakotine, 
            int karma, 
            DateTime birthdate, 
            string city, 
            char gender, 
            int adminId, 
            string fullName)
            : base(userId, username, email, tweakotine, karma, birthdate, city, gender)
        {
            this.AdminID = adminId;
            this.FullName = fullName;
        }

        /// <summary>
        /// Gets or sets the admin id.
        /// </summary>
        public int AdminID { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }
    }
}