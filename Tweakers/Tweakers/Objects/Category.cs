using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Category
    {
        public Category(int categoryId, Category parent, string category)
        {
            this.CategoryID = categoryId;
            this.Parent = parent;
            this.CategoryString = category;
        }

        public int CategoryID { get; set; }

        public Category Parent { get; set; }

        public string CategoryString { get; set; }
    }
}
