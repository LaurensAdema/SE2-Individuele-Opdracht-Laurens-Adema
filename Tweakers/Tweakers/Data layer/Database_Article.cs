using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Database_Article: Database
    {
        public Article GetArticle(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void AddArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public Article GetAllArticles()
        {
            throw new System.NotImplementedException();
        }

        public List<Article> OwnArticles(Account account)
        {
            throw new System.NotImplementedException();
        }
    }
}
