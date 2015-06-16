// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Administration.cs" company="">
//   
// </copyright>
// <summary>
//   The administration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Web.Security;

    using Tweakers.Using;

    #endregion

    /// <summary>
    /// The administration.
    /// </summary>
    public class Administration
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private static Administration administration;

        /// <summary>
        /// The db accounts.
        /// </summary>
        private readonly Database_Accounts dbAccounts = new Database_Accounts();

        /// <summary>
        /// The db article.
        /// </summary>
        private readonly Database_Article dbArticle = new Database_Article();

        /// <summary>
        /// The db categories.
        /// </summary>
        private readonly Database_Categories dbCategories = new Database_Categories();

        /// <summary>
        /// The db reaction.
        /// </summary>
        private readonly Database_Reaction dbReaction = new Database_Reaction();

        /// <summary>
        /// The account.
        /// </summary>
        private Account account;

        /// <summary>
        /// The db os.
        /// </summary>
        private Database_OS dbOs = new Database_OS();

        /// <summary>
        /// Gets the administration prop.
        /// </summary>
        public static Administration AdministrationProp
        {
            get
            {
                if (administration == null)
                {
                    administration = new Administration();
                }

                return administration;
            }
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Login(string username, string password)
        {
            Account account = this.dbAccounts.CheckCredentials(username, password);
            string encTicket = null;

            if (account != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, 
                    account.UserID.ToString(), 
                    DateTime.Now, 
                    DateTime.Now.AddMinutes(30), 
                    false, 
                    account.GetType().ToString(), 
                    FormsAuthentication.FormsCookiePath);
                encTicket = FormsAuthentication.Encrypt(ticket);
            }

            return encTicket;
        }

        /// <summary>
        /// The edit password.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditPassword()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public void Register(Account account, string password)
        {
            this.dbAccounts.AddAccount(account, Encrypt.CreateHash(password));
        }

        /// <summary>
        /// The add account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddAccount(Account account, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all accounts.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public List<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The edit account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditAccount(Account account)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get account.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>.
        /// </returns>
        public Account GetAccount(int ID)
        {
            return this.dbAccounts.GetAccount(ID);
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
            return this.dbArticle.GetAllNewsArticles(dateTime);
        }

        /// <summary>
        /// The remove article.
        /// </summary>
        /// <param name="article">
        /// The article.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void RemoveArticle(string article)
        {
            throw new NotImplementedException();
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
            return this.dbArticle.GetArticle(ID);
        }

        /// <summary>
        /// The add os.
        /// </summary>
        /// <param name="OS">
        /// The os.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddOS(OS OS)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete os.
        /// </summary>
        /// <param name="OS">
        /// The os.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DeleteOS(OS OS)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The edit os.
        /// </summary>
        /// <param name="OS">
        /// The os.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditOS(OS OS)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get os.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="OS"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public OS GetOS(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddReaction(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add score.
        /// </summary>
        /// <param name="score">
        /// The score.
        /// </param>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddScore(int score, Reaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The edit reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditReaction(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all reactions.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Reaction> GetAllReactions(int ID)
        {
            List<Reaction> reactions = SortOrder.OrderReactions(this.dbReaction.GetAllReactions(ID));
            return reactions;
        }

        /// <summary>
        /// The get reaction.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Reaction"/>.
        /// </returns>
        public Reaction GetReaction(int ID)
        {
            return this.dbReaction.GetReaction(ID);
        }

        /// <summary>
        /// The remove reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void RemoveReaction(Reaction reaction)
        {
            throw new NotImplementedException();
        }

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
            return this.dbCategories.GetAllCategories(ID);
        }

        /// <summary>
        /// The get category.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Category> GetCategory(int ID)
        {
            return null;
        }

        /// <summary>
        /// The upload video.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void UploadVideo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The own articles.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public List<Article> OwnArticles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The search account.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="exact">
        /// The exact.
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>.
        /// </returns>
        public Account SearchAccount(string query, string type, byte exact)
        {
            return this.dbAccounts.SearchAccount(query, type, exact);
        }
    }
}