using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Content.NotLogged
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (tbPassword.Text == tbPasswordConfimation.Text)
                {
                    if (Administration.AdministrationProp.SearchAccount(tbEmail.Text, "email", 1) == null)
                    {
                        if (Administration.AdministrationProp.SearchAccount(tbUsername.Text, "username", 1) == null)
                        {
                            Administration.AdministrationProp.Register(new Account(-1, tbUsername.Text, tbEmail.Text, 0, 0, new DateTime(), "", '0'), tbPassword.Text);
                            string encTicket = Administration.AdministrationProp.Login(tbEmail.Text, tbPassword.Text);
                            if (encTicket != null)
                            {
                                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                                Response.Redirect(FormsAuthentication.GetRedirectUrl(authTicket.Name, authTicket.IsPersistent));
                            }
                            else
                            {
                                errorMessage.InnerText = "De ingevoerde gegevens zijn onjuist.";
                            }
                        }
                        else
                        {
                            errorMessage.InnerText = "De ingevoerde gebruikersnaam is al in gebruik.";
                        }
                    }
                    else
                    {
                        errorMessage.InnerText = "Het ingevoerde emailadres is al in gebruik.";
                    }
                }
                else
                {
                    errorMessage.InnerText = "De ingevoerde wachtwoorden komen niet overeen.";
                }
            }
        }
    }
}