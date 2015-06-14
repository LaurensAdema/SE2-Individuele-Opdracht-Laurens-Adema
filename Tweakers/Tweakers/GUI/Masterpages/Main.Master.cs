using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tweakers.GUI
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string thisURL = this.Page.GetType().Name.ToString();
            switch (thisURL)
            {
                case "gui_content_all_news_aspx":
                    newsButton.Attributes.Add("class", "active");
                    break;
                case "gui_content_all_newsoverview_aspx":
                    newsButton.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}