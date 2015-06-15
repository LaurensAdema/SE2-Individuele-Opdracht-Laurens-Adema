using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    using System.Linq;

    using Oracle.ManagedDataAccess.Client;

    public class Database_Categories: Database
    {
        public void AddCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void EditCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategory(int ID)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAllCategories(int ID)
        {
            List<Category> allCategories = new List<Category>();

            string categoryQuery = "SELECT C.* FROM CATEGORIE C, CATEGORIEINARTIKEL CIA, ARTIKEL A WHERE A.artikelID = :articleID AND CIA.artikelID = A.artikelID AND CIA.categorieID = C.categorieID";
            List<OracleParameter> categoryParameters = new List<OracleParameter>();
            categoryParameters.Add(new OracleParameter(":articleID", ID));

            OracleDataReader getAllCategories = Read(categoryQuery, categoryParameters);
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

            Close();

            return allCategories;
        }
    }
}
