// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database_Categories.cs" company="">
//   
// </copyright>
// <summary>
//   The database_ categories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;

    using Oracle.ManagedDataAccess.Client;

    #endregion

    /// <summary>
    /// The database_ categories.
    /// </summary>
    public class Database_Categories : Database
    {
        /// <summary>
        /// The add category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The edit category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get category.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Category"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Category GetCategory(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all categories.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Category> GetAllCategories(int ID)
        {
            List<Category> allCategories = new List<Category>();

            string categoryQuery =
                "SELECT C.* FROM CATEGORIE C, CATEGORIEINARTIKEL CIA, ARTIKEL A WHERE A.artikelID = :articleID AND CIA.artikelID = A.artikelID AND CIA.categorieID = C.categorieID";
            List<OracleParameter> categoryParameters = new List<OracleParameter>();
            categoryParameters.Add(new OracleParameter(":articleID", ID));

            OracleDataReader getAllCategories = this.Read(categoryQuery, categoryParameters);
            if (getAllCategories != null)
            {
                if (getAllCategories.HasRows)
                {
                    while (getAllCategories.Read())
                    {
                        Category category;

                        int categoryID = Convert.ToInt32(getAllCategories["categorieID"]);
                        string categoryString = Convert.ToString(getAllCategories["categorie"]);

                        category = new Category(categoryID, null, categoryString);

                        allCategories.Add(category);
                    }
                }

                getAllCategories.Close();
            }

            this.Close();

            return allCategories;
        }
    }
}