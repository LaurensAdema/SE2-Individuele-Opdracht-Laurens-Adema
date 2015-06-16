// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logout.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The logout.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.GUI.Content.All
{
    #region

    using System;
    using System.Web.Security;
    using System.Web.UI;

    #endregion

    /// <summary>
    /// The logout.
    /// </summary>
    public partial class Logout : Page
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
            FormsAuthentication.SignOut();
            this.Response.Redirect(
                this.Request.UrlReferrer != null ? this.Request.UrlReferrer.ToString() : "../NotLogged/Index.aspx");
        }
    }
}