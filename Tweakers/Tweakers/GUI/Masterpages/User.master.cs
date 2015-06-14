using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Masterpages
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            Account account = Administration.AdministrationProp.GetAccount(Convert.ToInt32(authTicket.Name));

            if (account.GetType().ToString() != "Tweakers.Account")
            {
                Response.Redirect("/GUI/Content/All/Index.aspx");
            }
            lblUser.InnerText = account.Username;
        }
    }
}