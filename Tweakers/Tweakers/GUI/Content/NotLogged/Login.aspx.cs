// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The login.
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
    /// The login.
    /// </summary>
    public partial class Login : Page
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
        }

        /// <summary>
        /// The bt login_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btLogin_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                string encTicket = Administration.AdministrationProp.Login(this.tbEmail.Text, this.tbPassword.Text);
                if (encTicket != null)
                {
                    this.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    this.Response.Redirect(FormsAuthentication.GetRedirectUrl(authTicket.Name, authTicket.IsPersistent));
                }
                else
                {
                    this.errorMessage.InnerText = "De ingevoerde gegevens zijn onjuist.";
                }
            }
        }
    }
}