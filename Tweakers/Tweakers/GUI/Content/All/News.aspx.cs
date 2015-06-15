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
        private List<Reaction> reactionsArticle; 

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

                categoryArticle.InnerHtml = LoadCategories(ID);
            }
        }

        protected void LoadReactions(List<Reaction> reactions)
        {
            reactionsArticle = reactions;
            while (reactionsArticle.Count > 0)
            {
                Reaction thisReaction = reactionsArticle[0];
                LoadReaction(thisReaction);
                reactionBuilder.Append(String.Format("</div></div>"));
                reactionsArticle.Remove(thisReaction);
            }
            
        }

        protected void LoadReaction(Reaction reaction)
        {
            if (reaction.Parent != null)
            {
                LoadReaction(reaction.Parent);
                reactionBuilder.Append(String.Format("<!-- Nested Comment --><div class=\"media\"><a class=\"pull-left\" href=\"GUI/Content/All/User.aspx?id={0}\"><img class=\"media-object\" src=\"http://placehold.it/64x64\" alt=\"\"></a><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a><small>{2}</small></h4>{3}</div></div><!-- End Nested Comment -->", reaction.Account.UserID, reaction.Account.Username, reaction.Date.ToString("d MMMM yyyy om HH:mm"), reaction.ReactionString));
                reactionsArticle.Remove(reaction);
            }
            else
            {
                reactionBuilder.Append(String.Format("<div class=\"media\"><a class=\"pull-left\" href=\"GUI/Content/All/User.aspx?id={0}\"><img class=\"media-object\" src=\"http://placehold.it/64x64\" alt=\"\"></a><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a><small>{2}</small></h4>{3}", reaction.Account.UserID, reaction.Account.Username, reaction.Date.ToString("d MMMM yyyy om HH:mm"), reaction.ReactionString));
                reactionsArticle.Remove(reaction);
            }
        }

        protected string LoadCategories(int ID)
        {
            List<Category> categories = Administration.AdministrationProp.GetAllCategories(ID);
            StringBuilder categoryHTML = new StringBuilder();

            if (categories != null)
            {
                int leftRowCount = Convert.ToInt32(Math.Ceiling((double)categories.Count) / 2);

                categoryHTML.Append("<div class=\"row\"><div class=\"col-lg-6\"><ul class=\"list-unstyled\">");

                for (int i = 0; i < leftRowCount; i++)
                {
                    categoryHTML.Append(
                        String.Format(
                            "<li><a href=\"/GUI/Content/All/Category.aspx?id={0}\">{1}</a></li>",
                            categories[i].CategoryID,
                            categories[i].CategoryString));
                }
                categoryHTML.Append("</ul></div><div class=\"col-lg-6\"><ul class=\"list-unstyled\">");
                for (int i = leftRowCount; i < categories.Count; i++)
                {
                    categoryHTML.Append(
                        String.Format(
                            "<li><a href=\"/GUI/Content/All/Category.aspx?id={0}\">{1}</a></li>",
                            categories[i].CategoryID,
                            categories[i].CategoryString));
                }
                categoryHTML.Append("</ul></div>");
            }
            

            return categoryHTML.ToString();
        }

        public string FirstCharToUpper(string input)
        {
            return !String.IsNullOrEmpty(input) ? input.First().ToString().ToUpper() + input.Substring(1) : input;
        }

        public void btnSubmitReaction_OnClick(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (Page.IsValid)
                {
                    errorMessage.InnerText = "De ingevoerde gegevens zijn onjuist.";
                }
            }
            else
            {
                errorMessage.InnerText = "U moet ingelogd zijn om een reactie te plaatsen.";
            }
        }
    }
}