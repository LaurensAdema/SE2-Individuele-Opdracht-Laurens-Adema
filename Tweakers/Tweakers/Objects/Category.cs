// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="">
//   
// </copyright>
// <summary>
//   The category.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    /// <summary>
    /// The category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        public Category(int categoryId, Category parent, string category)
        {
            this.CategoryID = categoryId;
            this.Parent = parent;
            this.CategoryString = category;
        }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        public Category Parent { get; set; }

        /// <summary>
        /// Gets or sets the category string.
        /// </summary>
        public string CategoryString { get; set; }
    }
}