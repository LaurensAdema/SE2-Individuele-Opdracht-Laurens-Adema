// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Editor.cs" company="">
//   
// </copyright>
// <summary>
//   The editor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The editor.
    /// </summary>
    public class Editor : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
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
        /// <param name="editorId">
        /// The editor id.
        /// </param>
        /// <param name="fullName">
        /// The full name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="writesOver">
        /// The writes over.
        /// </param>
        /// <param name="authorSince">
        /// The author since.
        /// </param>
        public Editor(
            int userId, 
            string username, 
            string email, 
            int tweakotine, 
            int karma, 
            DateTime birthdate, 
            string city, 
            char gender, 
            int editorId, 
            string fullName, 
            string description, 
            string writesOver, 
            DateTime authorSince)
            : base(userId, username, email, tweakotine, karma, birthdate, city, gender)
        {
            this.EditorID = editorId;
            this.FullName = fullName;
            this.Description = description;
            this.WritesOver = writesOver;
            this.AuthorSince = authorSince;
        }

        /// <summary>
        /// Gets or sets the editor id.
        /// </summary>
        public int EditorID { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the writes over.
        /// </summary>
        public string WritesOver { get; set; }

        /// <summary>
        /// Gets or sets the author since.
        /// </summary>
        public DateTime AuthorSince { get; set; }
    }
}