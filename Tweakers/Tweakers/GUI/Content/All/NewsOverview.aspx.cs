// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsOverview.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The news overview.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI.Content.NotLogged
{
    #region

    using System;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The news overview.
    /// </summary>
    public partial class NewsOverview : Page
    {
        /// <summary>
        /// The page_ pre init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                switch (authTicket.UserData)
                {
                    case "Tweakers.Admin":
                        this.MasterPageFile = "~/GUI/Masterpages/Admin.master";
                        break;
                    case "Tweakers.Editor":
                        this.MasterPageFile = "~/GUI/Masterpages/Editor.master";
                        break;
                    case "Tweakers.Account":
                        this.MasterPageFile = "~/GUI/Masterpages/User.master";
                        break;
                    default:
                        this.MasterPageFile = "~/GUI/Masterpages/NotLogged.master";
                        break;
                }
            }
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int history = 0;
            int.TryParse(this.Request.QueryString["history"], out history);
            this.LoadNews(DateTime.Now.AddDays(history));
            this.HeaderNewsOverview();
            this.PageTurner();
        }

        /// <summary>
        /// The load news.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        protected void LoadNews(DateTime dateTime)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            foreach (Article article in Administration.AdministrationProp.GetAllNewsArticles(dateTime))
            {
                if (article.Editor is Editor)
                {
                    Editor editor = article.Editor as Editor;
                    htmlBuilder.Append(
                        string.Format(
                            "<h2><a href=\"/GUI/Content/All/News.aspx?id={0}\">{1}</a></h2><p class=\"lead\">by <a href=\"/GUI/Content/All/User.aspx?id={2}\">{3}</a></p><p><span class=\"glyphicon glyphicon-time\"></span> Geplaatst op {4}</p><hr><p>{5}</p><a class=\"btn btn-primary\" href=\"/GUI/Content/All/News.aspx?id={0}\">Lees meer <span class=\"glyphicon glyphicon-chevron-right\"></span></a><hr>", 
                            article.ArticleID, 
                            article.Title, 
                            article.Editor.UserID, 
                            editor.FullName, 
                            article.Date.ToLongDateString() + " om " + article.Date.ToLongTimeString(), 
                            article.Content));
                }
                else if (article.Editor is Admin)
                {
                    Admin editor = article.Editor as Admin;
                    htmlBuilder.Append(
                        string.Format(
                            "<h2><a href=\"/GUI/Content/All/News.aspx?id={0}\">{1}</a></h2><p class=\"lead\">by <a href=\"/GUI/Content/All/User.aspx?id={2}\">{3}</a></p><p><span class=\"glyphicon glyphicon-time\"></span> Geplaatst op {4}</p><hr><p>{5}</p><a class=\"btn btn-primary\" href=\"/GUI/Content/All/News.aspx?id={0}\">Lees meer <span class=\"glyphicon glyphicon-chevron-right\"></span></a><hr>", 
                            article.ArticleID, 
                            article.Title, 
                            article.Editor.UserID, 
                            editor.FullName, 
                            article.Date.ToLongDateString() + " om " + article.Date.ToLongTimeString(), 
                            article.Content));
                }
            }

            this.newsArticles.InnerHtml = htmlBuilder.ToString();
        }

        /// <summary>
        /// The header news overview.
        /// </summary>
        protected void HeaderNewsOverview()
        {
            int history = 0;
            int.TryParse(this.Request.QueryString["history"], out history);
            DateTime dateTime = DateTime.Now.AddDays(history);

            this.headerNewsOverview.InnerHtml = string.Format(
                "<h1 class=\"page-header\">{0} <small>{1}</small></h1>", 
                FirstCharToUpper(dateTime.ToString("dddd")), 
                dateTime.ToString("d MMMM yyyy"));
        }

        /// <summary>
        /// The page turner.
        /// </summary>
        protected void PageTurner()
        {
            int history = 0;
            int.TryParse(this.Request.QueryString["history"], out history);
            if (history != 0)
            {
                this.pageTurner.InnerHtml +=
                    string.Format(
                        "<li class=\"previous\"><a href=\"?history={0}\">&larr; {1}</a></li>", 
                        history + 1, 
                        FirstCharToUpper(DateTime.Now.AddDays(history + 1).ToString("dddd d MMMM yyyy")));
            }

            this.pageTurner.InnerHtml += string.Format(
                "<li class=\"next\"><a href=\"?history={0}\">{1} &rarr;</a></li>", 
                history - 1, 
                FirstCharToUpper(DateTime.Now.AddDays(history - 1).ToString("dddd d MMMM yyyy")));
        }

        /// <summary>
        /// The first char to upper.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string FirstCharToUpper(string input)
        {
            return !string.IsNullOrEmpty(input) ? input.First().ToString().ToUpper() + input.Substring(1) : input;
        }
    }
}