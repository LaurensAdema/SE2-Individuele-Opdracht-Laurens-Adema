using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Article
    {
        public Article(int articleId, Account editor, string title, string content, DateTime date, int views, List<Category> categories, List<Reaction> reactions)
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

        public int ArticleID { get; set; }

        public Account Editor { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int Views { get; set; }

        public List<Reaction> Reactions { get; set; }

        public List<Category> Categories { get; set; }
    }
}
