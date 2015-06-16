// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The register.
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
    /// The register.
    /// </summary>
    public partial class Register : Page
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
        /// The btn register_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                if (this.tbPassword.Text == this.tbPasswordConfimation.Text)
                {
                    if (Administration.AdministrationProp.SearchAccount(this.tbEmail.Text, "email", 1) == null)
                    {
                        if (Administration.AdministrationProp.SearchAccount(this.tbUsername.Text, "username", 1) == null)
                        {
                            Administration.AdministrationProp.Register(
                                new Account(-1, this.tbUsername.Text, this.tbEmail.Text, 0, 0, new DateTime(), string.Empty, '0'), 
                                this.tbPassword.Text);
                            string encTicket = Administration.AdministrationProp.Login(
                                this.tbEmail.Text, 
                                this.tbPassword.Text);
                            if (encTicket != null)
                            {
                                this.Response.Cookies.Add(
                                    new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                                HttpCookie authCookie =
                                    HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                                this.Response.Redirect(
                                    FormsAuthentication.GetRedirectUrl(authTicket.Name, authTicket.IsPersistent));
                            }
                            else
                            {
                                this.errorMessage.InnerText = "De ingevoerde gegevens zijn onjuist.";
                            }
                        }
                        else
                        {
                            this.errorMessage.InnerText = "De ingevoerde gebruikersnaam is al in gebruik.";
                        }
                    }
                    else
                    {
                        this.errorMessage.InnerText = "Het ingevoerde emailadres is al in gebruik.";
                    }
                }
                else
                {
                    this.errorMessage.InnerText = "De ingevoerde wachtwoorden komen niet overeen.";
                }
            }
        }
    }
}