// --------------------------------------------------------------------------------------------------------------------
// <copyright file="News.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The news.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI.Content.NotLogged
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The news.
    /// </summary>
    public partial class News : Page
    {
        /// <summary>
        /// The reaction builder.
        /// </summary>
        private readonly StringBuilder reactionBuilder = new StringBuilder();

        /// <summary>
        /// The reactions article.
        /// </summary>
        private List<Reaction> reactionsArticle;

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
            int id = -1;
            int.TryParse(this.Request.QueryString["id"], out id);
            if (id != -1)
            {
                this.LoadArticle(id);
            }
        }

        /// <summary>
        /// The load article.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        protected void LoadArticle(int ID)
        {
            Article article = Administration.AdministrationProp.GetArticle(ID);
            if (article != null)
            {
                this.titleArticle.InnerHtml = string.Format("<h1>{0}</h1>", article.Title);
                if (article.Editor is Editor)
                {
                    Editor editor = article.Editor as Editor;
                    this.authorArticle.InnerHtml =
                        string.Format(
                            "<p class=\"lead\">door <a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a></p>", 
                            article.Editor.UserID, 
                            editor.FullName);
                }
                else if (article.Editor is Admin)
                {
                    Admin editor = article.Editor as Admin;
                    this.authorArticle.InnerHtml =
                        string.Format(
                            "<p class=\"lead\">door <a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a></p>", 
                            article.Editor.UserID, 
                            editor.FullName);
                }

                this.dateArticle.InnerHtml = string.Format(
                    "<p><span class=\"glyphicon glyphicon-time\"></span> {0}</p>", 
                    this.FirstCharToUpper(article.Date.ToLongDateString() + " om " + article.Date.ToLongTimeString()));
                this.contentArticle.InnerHtml = string.Format("{0}", article.Content);

                this.LoadReactions(article.Reactions);
                this.commentsArticle.InnerHtml = this.reactionBuilder.ToString();

                this.categoryArticle.InnerHtml = this.LoadCategories(ID);
            }
        }

        /// <summary>
        /// The load reactions.
        /// </summary>
        /// <param name="reactions">
        /// The reactions.
        /// </param>
        protected void LoadReactions(List<Reaction> reactions)
        {
            this.reactionsArticle = reactions;
            while (this.reactionsArticle.Count > 0)
            {
                Reaction thisReaction = this.reactionsArticle[0];
                this.LoadReaction(thisReaction);
                this.reactionBuilder.Append("</div></div>");
                this.reactionsArticle.Remove(thisReaction);
            }
        }

        /// <summary>
        /// The load reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        protected void LoadReaction(Reaction reaction)
        {
            if (reaction.Parent != null)
            {
                this.LoadReaction(reaction.Parent);
                this.reactionBuilder.Append(
                    string.Format(
                        "<!-- Nested Comment --><div class=\"media\"><a class=\"pull-left\" href=\"GUI/Content/All/User.aspx?id={0}\"><img class=\"media-object\" src=\"http://placehold.it/64x64\" alt=\"\"></a><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a><small>{2}</small></h4>{3}</div></div><!-- End Nested Comment -->", 
                        reaction.Account.UserID, 
                        reaction.Account.Username, 
                        reaction.Date.ToString("d MMMM yyyy om HH:mm"), 
                        reaction.ReactionString));
                this.reactionsArticle.Remove(reaction);
            }
            else
            {
                this.reactionBuilder.Append(
                    string.Format(
                        "<div class=\"media\"><a class=\"pull-left\" href=\"GUI/Content/All/User.aspx?id={0}\"><img class=\"media-object\" src=\"http://placehold.it/64x64\" alt=\"\"></a><div class=\"media-body\"><h4 class=\"media-heading\"><a href=\"GUI/Content/All/User.aspx?id={0}\">{1}</a><small>{2}</small></h4>{3}", 
                        reaction.Account.UserID, 
                        reaction.Account.Username, 
                        reaction.Date.ToString("d MMMM yyyy om HH:mm"), 
                        reaction.ReactionString));
                this.reactionsArticle.Remove(reaction);
            }
        }

        /// <summary>
        /// The load categories.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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
                        string.Format(
                            "<li><a href=\"/GUI/Content/All/Category.aspx?id={0}\">{1}</a></li>", 
                            categories[i].CategoryID, 
                            categories[i].CategoryString));
                }

                categoryHTML.Append("</ul></div><div class=\"col-lg-6\"><ul class=\"list-unstyled\">");
                for (int i = leftRowCount; i < categories.Count; i++)
                {
                    categoryHTML.Append(
                        string.Format(
                            "<li><a href=\"/GUI/Content/All/Category.aspx?id={0}\">{1}</a></li>", 
                            categories[i].CategoryID, 
                            categories[i].CategoryString));
                }

                categoryHTML.Append("</ul></div>");
            }

            return categoryHTML.ToString();
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
        public string FirstCharToUpper(string input)
        {
            return !string.IsNullOrEmpty(input) ? input.First().ToString().ToUpper() + input.Substring(1) : input;
        }

        /// <summary>
        /// The btn submit reaction_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void btnSubmitReaction_OnClick(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (this.Page.IsValid)
                {
                    this.errorMessage.InnerText = "De ingevoerde gegevens zijn onjuist.";
                }
            }
            else
            {
                this.errorMessage.InnerText = "U moet ingelogd zijn om een reactie te plaatsen.";
            }
        }
    }
}