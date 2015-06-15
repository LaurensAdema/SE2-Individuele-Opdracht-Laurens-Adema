using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Content.NotLogged
{
    public partial class News : System.Web.UI.Page
    {
        private StringBuilder reactionBuilder = new StringBuilder();

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
            int id = -1;
            Int32.TryParse(Request.QueryString["id"], out id);
            if (id != -1)
            {
                LoadArticle(id);
            }
        }

        protected void LoadArticle(int ID)
        {
            Article article = Administration.AdministrationProp.GetArticle(ID);
            if (article != null)
            {
                titleArticle.InnerHtml = String.Format("<h1>{0}</h1>", article.Title);
                if (article.Editor is Editor)
                {
                    Editor editor = article.Editor as Editor;
                    authorArticle.InnerHtml = String.Format("<p class=\"lead\">door <a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a></p>", article.Editor.UserID, editor.FullName);
                }
                else if (article.Editor is Admin)
                {
                    Admin editor = article.Editor as Admin;
                    authorArticle.InnerHtml = String.Format("<p class=\"lead\">door <a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a></p>", article.Editor.UserID, editor.FullName);
                }
                dateArticle.InnerHtml = String.Format("<p><span class=\"glyphicon glyphicon-time\"></span> {0}</p>",
                    FirstCharToUpper(article.Date.ToLongDateString() + " om " + article.Date.ToLongTimeString()));
                contentArticle.InnerHtml = String.Format("{0}", article.Content);

                LoadReactions(article.Reactions);
                commentsArticle.InnerHtml = reactionBuilder.ToString();
            }
        }

        protected void LoadReactions(List<Reaction> reactions)
        {
            foreach (Reaction reaction in reactions)
            {
                LoadReaction(reaction);
                reactionBuilder.Append(String.Format("</div></div>"));
            }
        }

        protected void LoadReaction(Reaction reaction)
        {
            if (reaction.Parent != null)
            {
                LoadReaction(reaction.Parent);
                reactionBuilder.Append(String.Format("<!-- Nested Comment --><div class=\"media\"><a class=\"pull-left\" href=\"GUI/Content/All/User.aspx?id={0}\"><img class=\"media-object\" src=\"http://placehold.it/64x64\" alt=\"\"></a><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a><small>{2}</small></h4>{3}</div></div><!-- End Nested Comment -->", reaction.Account.UserID, reaction.Account.Username, reaction.Date.ToString("d MMMM yyyy om HH:mm"), reaction.ReactionString));
            }
            else
            {
                reactionBuilder.Append(String.Format("<div class=\"media\"><a class=\"pull-left\" href=\"GUI/Content/All/User.aspx?id={0}\"><img class=\"media-object\" src=\"http://placehold.it/64x64\" alt=\"\"></a><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a><small>{2}</small></h4>{3}", reaction.Account.UserID, reaction.Account.Username, reaction.Date.ToString("d MMMM yyyy om HH:mm"), reaction.ReactionString));
            }
        }

        public static string FirstCharToUpper(string input)
        {
            return !String.IsNullOrEmpty(input) ? input.First().ToString().ToUpper() + input.Substring(1) : input;
        }
    }
}