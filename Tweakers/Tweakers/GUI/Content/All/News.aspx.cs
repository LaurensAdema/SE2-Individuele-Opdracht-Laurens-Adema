using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Content.NotLogged
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}