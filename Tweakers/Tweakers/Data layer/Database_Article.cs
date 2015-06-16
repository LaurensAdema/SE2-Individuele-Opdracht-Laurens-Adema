// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database_Article.cs" company="">
//   
// </copyright>
// <summary>
//   The database_ article.
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
    /// The database_ article.
    /// </summary>
    public class Database_Article : Database
    {
        /// <summary>
        /// The get article.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Article"/>.
        /// </returns>
        public Article GetArticle(int ID)
        {
            Article article = null;

            if (ID != -1)
            {
                string articleQuery =
                    "SELECT * FROM ARTIKEL A LEFT JOIN A_VIDEO V ON A.artikelID = V.artikelID LEFT JOIN A_SOFTWAREUPDATE S ON A.artikelID = S.artikelID WHERE A.artikelID = :articleID";
                List<OracleParameter> articleParameters = new List<OracleParameter>();
                articleParameters.Add(new OracleParameter(":articleID", ID));

                OracleDataReader getArticle = this.Read(articleQuery, articleParameters);
                if (getArticle != null)
                {
                    if (getArticle.HasRows)
                    {
                        while (getArticle.Read())
                        {
                            int articleID = Convert.ToInt32(getArticle["artikelID"]);
                            int editorID = Convert.ToInt32(getArticle["redacteurID"]);
                            string title = Convert.ToString(getArticle["titel"]);
                            string content = Convert.ToString(getArticle["inhoud"]);
                            DateTime date = Convert.ToDateTime(getArticle["datum"]);
                            int views = Convert.ToInt32(getArticle["aantalViews"]);

                            char type;
                            char.TryParse(getArticle["A_Soort"].ToString(), out type);
                            if (type == 'V')
                            {
                                int videoID = Convert.ToInt32(getArticle["videoID"]);
                                string videoPath = Convert.ToString(getArticle["videoPath"]);
                                article = new Video(
                                    articleID, 
                                    Administration.AdministrationProp.GetAccount(editorID), 
                                    title, 
                                    content, 
                                    date, 
                                    views, 
                                    Administration.AdministrationProp.GetCategory(articleID), 
                                    Administration.AdministrationProp.GetAllReactions(articleID), 
                                    videoID, 
                                    videoPath);
                            }
                            else if (type == 'S')
                            {
                                int updateID = Convert.ToInt32(getArticle["updateID"]);
                                int parentID = -1;
                                int.TryParse(getArticle["updateID"].ToString(), out parentID);
                                string release = Convert.ToString(getArticle["releasestatus"]);
                                string version = Convert.ToString(getArticle["versienummer"]);
                                string download = Convert.ToString(getArticle["download"]);
                                string website = Convert.ToString(getArticle["website"]);
                                string fileSize = Convert.ToString(getArticle["bestandGrootte"]);
                                string license = Convert.ToString(getArticle["licentieType"]);

                                article = new Update(
                                    articleID, 
                                    Administration.AdministrationProp.GetAccount(editorID), 
                                    title, 
                                    content, 
                                    date, 
                                    views, 
                                    Administration.AdministrationProp.GetCategory(articleID), 
                                    Administration.AdministrationProp.GetAllReactions(articleID), 
                                    updateID, 
                                    this.GetArticle(parentID) as Update, 
                                    release, 
                                    version, 
                                    download, 
                                    website, 
                                    fileSize, 
                                    license, 
                                    this.GetOSArticle(updateID));
                            }
                            else
                            {
                                article = new Article(
                                    articleID, 
                                    Administration.AdministrationProp.GetAccount(editorID), 
                                    title, 
                                    content, 
                                    date, 
                                    views, 
                                    Administration.AdministrationProp.GetCategory(articleID), 
                                    Administration.AdministrationProp.GetAllReactions(articleID));
                            }

                            break;
                        }
                    }

                    getArticle.Close();
                }

                this.Close();
            }

            return article;
        }

        /// <summary>
        /// The get os article.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<OS> GetOSArticle(int ID)
        {
            return null;
        }

        /// <summary>
        /// The update article.
        /// </summary>
        /// <param name="article">
        /// The article.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove article.
        /// </summary>
        /// <param name="article">
        /// The article.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void RemoveArticle(Article article)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add article.
        /// </summary>
        /// <param name="article">
        /// The article.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddArticle(Article article)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all articles.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public List<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all news articles.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Article> GetAllNewsArticles(DateTime dateTime)
        {
            List<Article> allNewsArticles = new List<Article>();

            string newsQuery =
                "SELECT * FROM ARTIKEL A LEFT JOIN A_VIDEO V ON A.artikelID = V.artikelID WHERE (A.A_Soort != 'S' OR A.A_Soort IS NULL) AND datum LIKE TO_DATE(:dateTime, 'dd-MM-YYYY')";
            List<OracleParameter> newsParameters = new List<OracleParameter>();
            newsParameters.Add(new OracleParameter(":dateTime", dateTime.ToString("dd-MM-yyyy")));

            OracleDataReader getAllNewsArticles = this.Read(newsQuery, newsParameters);
            if (getAllNewsArticles != null)
            {
                if (getAllNewsArticles.HasRows)
                {
                    while (getAllNewsArticles.Read())
                    {
                        Article article;

                        int articleID = Convert.ToInt32(getAllNewsArticles["artikelID"]);
                        int editorID = Convert.ToInt32(getAllNewsArticles["redacteurID"]);
                        string title = Convert.ToString(getAllNewsArticles["titel"]);
                        string content = Convert.ToString(getAllNewsArticles["inhoud"]);
                        DateTime date = Convert.ToDateTime(getAllNewsArticles["datum"]);
                        int views = Convert.ToInt32(getAllNewsArticles["aantalViews"]);

                        char type;
                        char.TryParse(getAllNewsArticles["A_Soort"].ToString(), out type);
                        if (type == 'V')
                        {
                            int videoID = Convert.ToInt32(getAllNewsArticles["videoID"]);
                            string videoPath = Convert.ToString(getAllNewsArticles["videoPath"]);
                            article = new Video(
                                articleID, 
                                Administration.AdministrationProp.GetAccount(editorID), 
                                title, 
                                content, 
                                date, 
                                views, 
                                Administration.AdministrationProp.GetCategory(articleID), 
                                null, 
                                videoID, 
                                videoPath);
                        }
                        else
                        {
                            article = new Article(
                                articleID, 
                                Administration.AdministrationProp.GetAccount(editorID), 
                                title, 
                                content, 
                                date, 
                                views, 
                                Administration.AdministrationProp.GetCategory(articleID), 
                                null);
                        }

                        allNewsArticles.Add(article);
                    }
                }

                getAllNewsArticles.Close();
            }

            this.Close();

            return allNewsArticles;
        }

        /// <summary>
        /// The own articles.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public List<Article> OwnArticles(Account account)
        {
            throw new NotImplementedException();
        }
    }
}