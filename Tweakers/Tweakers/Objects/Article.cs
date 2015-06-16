// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Article.cs" company="">
//   
// </copyright>
// <summary>
//   The article.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
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
        public Article(
            int articleId, 
            Account editor, 
            string title, 
            string content, 
            DateTime date, 
            int views, 
            List<Category> categories, 
            List<Reaction> reactions)
        {
            this.ArticleID = articleId;
            this.Editor = editor;
            this.Title = title;
            this.Content = content;
            this.Date = date;
            this.Views = views;
            this.Categories = categories;
            this.Reactions = reactions;
        }

        /// <summary>
        /// Gets or sets the article id.
        /// </summary>
        public int ArticleID { get; set; }

        /// <summary>
        /// Gets or sets the editor.
        /// </summary>
        public Account Editor { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Gets or sets the reactions.
        /// </summary>
        public List<Reaction> Reactions { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public List<Category> Categories { get; set; }
    }
}