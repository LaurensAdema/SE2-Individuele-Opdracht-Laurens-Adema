// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotLogged.master.cs" company="">
//   
// </copyright>
// <summary>
//   The not logged.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI.Masterpages
{
    #region

    using System;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The not logged.
    /// </summary>
    public partial class NotLogged : MasterPage
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
            string thisURL = this.Page.GetType().Name;
            switch (thisURL)
            {
                case "gui_content_notlogged_login_aspx":
                    this.loginButton.Attributes.Add("class", "active");
                    break;
                case "gui_content_notlogged_register_aspx":
                    this.registerButton.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}