using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Content.NotLogged
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btLogin_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string encTicket = Administration.AdministrationProp.Login(tbEmail.Text, tbPassword.Text);
                if (encTicket != null)
                {
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    Response.Redirect(FormsAuthentication.GetRedirectUrl(authTicket.Name , authTicket.IsPersistent));
                }
                else
                {
                    errorMessage.InnerText = "De ingevoerde gegevens zijn onjuist.";
                }
            }
        }
    }
}