// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.master.cs" company="">
//   
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI.Masterpages
{
    #region

    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The user.
    /// </summary>
    public partial class User : MasterPage
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
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            Account account = Administration.AdministrationProp.GetAccount(Convert.ToInt32(authTicket.Name));

            if (account.GetType().ToString() != "Tweakers.Account")
            {
                this.Response.Redirect("/GUI/Content/All/Index.aspx");
            }

            this.lblUser.InnerText = account.Username;
        }
    }
}