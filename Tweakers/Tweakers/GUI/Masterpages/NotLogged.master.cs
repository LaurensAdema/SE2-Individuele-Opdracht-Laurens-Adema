using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI.Masterpages
{
    public partial class NotLogged : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string thisURL = this.Page.GetType().Name.ToString();
            switch (thisURL)
            {
                case "gui_content_notlogged_login_aspx":
                    loginButton.Attributes.Add("class", "active");
                    break;
                case "gui_content_notlogged_register_aspx":
                    registerButton.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}