using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Security;

namespace Tweakers
{
    public class Administration
    {
        private Account account;
        private Database_Accounts dbAccounts = new Database_Accounts();
        private Database_Article dbArticle = new Database_Article();
        private Database_Categories dbCategories = new Database_Categories();
        private Database_OS dbOs = new Database_OS();
        private Database_Reaction dbrReaction = new Database_Reaction();

        private static Administration administration;

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

        public string Login(string username, string password)
        {
            Account account = dbAccounts.CheckCredentials(username, password);
            string encTicket = null;

            if (account != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, account.UserID.ToString(),
                    DateTime.Now, DateTime.Now.AddMinutes(30), false, account.GetType().ToString(),
                    FormsAuthentication.FormsCookiePath);
                encTicket = FormsAuthentication.Encrypt(ticket);
            }

            return encTicket;
        }

        public void EditPassword()
        {
            throw new System.NotImplementedException();
        }

        public void Register(Account account, string password)
        {
            dbAccounts.AddAccount(account, Encrypt.CreateHash(password));
        }

        public void AddAccount(Account account, string password)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public List<Account> GetAllAccounts()
        {
            throw new System.NotImplementedException();
        }

        public void EditAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccount(int ID)
        {
            return dbAccounts.GetAccount(ID);
        }

        public void AddArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public List<Article> GetAllArticles()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveArticle(string article)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public Article GetArticle(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void AddOS(OS OS)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOS(OS OS)
        {
            throw new System.NotImplementedException();
        }

        public void EditOS(OS OS)
        {
            throw new System.NotImplementedException();
        }

        public OS GetOS(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void AddReaction(Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public void AddScore(int score, Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public void EditReaction(Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public List<Reaction> GetAllReactions(Article article)
        {
            throw new System.NotImplementedException();
        }

        public Reaction GetReaction(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveReaction(Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public void AddCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void EditCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetCategory(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void UploadVideo()
        {
            throw new System.NotImplementedException();
        }

        public List<Article> OwnArticles()
        {
            throw new System.NotImplementedException();
        }

        public Account SearchAccount(string query, string type, byte exact)
        {
            return dbAccounts.SearchAccount(query, type, exact);
        }
    }
}
