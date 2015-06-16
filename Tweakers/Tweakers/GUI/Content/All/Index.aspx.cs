// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Index.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The index.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI.Content.NotLogged
{
    #region

    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The index.
    /// </summary>
    public partial class Index : Page
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
            else
            {
                this.MasterPageFile = "~/GUI/Masterpages/NotLogged.master";
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
        }
    }
}