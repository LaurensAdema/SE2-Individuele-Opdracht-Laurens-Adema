using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Content.NotLogged
{
    public partial class NewsOverview : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                switch (authTicket.UserData)
                {
                    case "Tweakers.Admin":
                        MasterPageFile = "~/GUI/Masterpages/Admin.master";
                        break;
                    case "Tweakers.Editor":
                        MasterPageFile = "~/GUI/Masterpages/Editor.master";
                        break;
                    case "Tweakers.Account":
                        MasterPageFile = "~/GUI/Masterpages/User.master";
                        break;
                    default:
                        MasterPageFile = "~/GUI/Masterpages/NotLogged.master";
                        break;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int history = 0;
            Int32.TryParse(Request.QueryString["history"], out history);
            LoadNews(DateTime.Now.AddDays(history));
            HeaderNewsOverview();
            PageTurner();
        }

        protected void LoadNews(DateTime dateTime)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            foreach (Article article in Administration.AdministrationProp.GetAllNewsArticles(dateTime))
            {
                if (article.Editor is Editor)
                {
                    Editor editor = article.Editor as Editor;
                    htmlBuilder.Append(String.Format(
                    "<h2><a href=\"/GUI/Content/All/News.aspx?id={0}\">{1}</a></h2><p class=\"lead\">by <a href=\"/GUI/Content/All/User.aspx?id={2}\">{3}</a></p><p><span class=\"glyphicon glyphicon-time\"></span> Geplaatst op {4}</p><hr><p>{5}</p><a class=\"btn btn-primary\" href=\"/GUI/Content/All/News.aspx?id={0}\">Lees meer <span class=\"glyphicon glyphicon-chevron-right\"></span></a><hr>",
                    article.ArticleID, article.Title, article.Editor.UserID, editor.FullName,
                    article.Date.ToLongDateString() + " om " + article.Date.ToLongTimeString(), article.Content));
                }
                else if (article.Editor is Admin)
                {
                    Admin editor = article.Editor as Admin;
                    htmlBuilder.Append(String.Format(
                    "<h2><a href=\"/GUI/Content/All/News.aspx?id={0}\">{1}</a></h2><p class=\"lead\">by <a href=\"/GUI/Content/All/User.aspx?id={2}\">{3}</a></p><p><span class=\"glyphicon glyphicon-time\"></span> Geplaatst op {4}</p><hr><p>{5}</p><a class=\"btn btn-primary\" href=\"/GUI/Content/All/News.aspx?id={0}\">Lees meer <span class=\"glyphicon glyphicon-chevron-right\"></span></a><hr>",
                    article.ArticleID, article.Title, article.Editor.UserID, editor.FullName,
                    article.Date.ToLongDateString() + " om " + article.Date.ToLongTimeString(), article.Content));
                }
            }
            newsArticles.InnerHtml = htmlBuilder.ToString();
        }

        protected void HeaderNewsOverview()
        {
            int history = 0;
            Int32.TryParse(Request.QueryString["history"], out history);
            DateTime dateTime = DateTime.Now.AddDays(history);

            headerNewsOverview.InnerHtml =
                String.Format("<h1 class=\"page-header\">{0} <small>{1}</small></h1>", FirstCharToUpper(dateTime.ToString("dddd")),
                    dateTime.ToString("d MMMM yyyy"));

        }

        protected void PageTurner()
        {
            int history = 0;
            Int32.TryParse(Request.QueryString["history"], out history);
            if (history != 0)
            {
                pageTurner.InnerHtml += String.Format("<li class=\"previous\"><a href=\"?history={0}\">&larr; {1}</a></li>", history + 1, FirstCharToUpper(DateTime.Now.AddDays(history+1).ToString("dddd d MMMM yyyy")));
            }
            
            pageTurner.InnerHtml += String.Format("<li class=\"next\"><a href=\"?history={0}\">{1} &rarr;</a></li>", history-1, FirstCharToUpper(DateTime.Now.AddDays(history-1).ToString("dddd d MMMM yyyy")));
        }

        public static string FirstCharToUpper(string input)
        {
            return !String.IsNullOrEmpty(input) ? input.First().ToString().ToUpper() + input.Substring(1) : input;
        }
    }
}