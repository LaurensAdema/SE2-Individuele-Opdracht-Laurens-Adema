// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Video.cs" company="">
//   
// </copyright>
// <summary>
//   The video.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The video.
    /// </summary>
    public class Video : Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Video"/> class.
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
        /// <param name="videoID">
        /// The video id.
        /// </param>
        /// <param name="videoPath">
        /// The video path.
        /// </param>
        public Video(
            int articleId, 
            Account editor, 
            string title, 
            string content, 
            DateTime date, 
            int views, 
            List<Category> categories, 
            List<Reaction> reactions, 
            int videoID, 
            string videoPath)
            : base(articleId, editor, title, content, date, views, categories, reactions)
        {
            this.VideoID = videoID;
            this.VideoPath = videoPath;
        }

        /// <summary>
        /// Gets or sets the video path.
        /// </summary>
        public string VideoPath { get; set; }

        /// <summary>
        /// Gets or sets the video id.
        /// </summary>
        public int VideoID { get; set; }
    }
}