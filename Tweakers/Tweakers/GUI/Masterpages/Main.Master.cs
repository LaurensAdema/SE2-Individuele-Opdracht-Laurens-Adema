// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.Master.cs" company="">
//   
// </copyright>
// <summary>
//   The main.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI
{
    #region

    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The main.
    /// </summary>
    public partial class Main : MasterPage
    {
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
            string thisURL = this.Page.GetType().Name;
            switch (thisURL)
            {
                case "gui_content_all_news_aspx":
                    this.newsButton.Attributes.Add("class", "active");
                    break;
                case "gui_content_all_newsoverview_aspx":
                    this.newsButton.Attributes.Add("class", "active");
                    break;
            }
        }

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
            else
            {
                this.MasterPageFile = "~/GUI/Masterpages/NotLogged.master";
            }
        }
    }
}