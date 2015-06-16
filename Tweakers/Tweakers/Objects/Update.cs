// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Update.cs" company="">
//   
// </copyright>
// <summary>
//   The update.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The update.
    /// </summary>
    public class Update : Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Update"/> class.
        /// </summary>
        /// <param name="articleId">
        /// The article id.
        /// </param>
        /// <param name="editor">
        /// The editor.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="views">
        /// The views.
        /// </param>
        /// <param name="categories">
        /// The categories.
        /// </param>
        /// <param name="reactions">
        /// The reactions.
        /// </param>
        /// <param name="updateId">
        /// The update id.
        /// </param>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="release">
        /// The release.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <param name="download">
        /// The download.
        /// </param>
        /// <param name="website">
        /// The website.
        /// </param>
        /// <param name="fileSize">
        /// The file size.
        /// </param>
        /// <param name="license">
        /// The license.
        /// </param>
        /// <param name="os">
        /// The os.
        /// </param>
        public Update(
            int articleId, 
            Account editor, 
            string title, 
            string content, 
            DateTime date, 
            int views, 
            List<Category> categories, 
            List<Reaction> reactions, 
            int updateId, 
            Update parent, 
            string release, 
            string version, 
            string download, 
            string website, 
            string fileSize, 
            string license, 
            List<OS> os)
            : base(articleId, editor, title, content, date, views, categories, reactions)
        {
            this.UpdateID = updateId;
            this.Parent = parent;
            this.Release = release;
            this.Version = version;
            this.Download = download;
            this.Website = website;
            this.FileSize = fileSize;
            this.License = license;
            this.OS = os;
        }

        /// <summary>
        /// Gets or sets the update id.
        /// </summary>
        public int UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        public Update Parent { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the release.
        /// </summary>
        public string Release { get; set; }

        /// <summary>
        /// Gets or sets the download.
        /// </summary>
        public string Download { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the file size.
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// Gets or sets the license.
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// Gets or sets the os.
        /// </summary>
        public List<OS> OS { get; set; }
    }
}