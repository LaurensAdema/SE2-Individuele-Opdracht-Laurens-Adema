using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Update: Article
    {
        public Update(int articleId, Account editor, string title, string content, DateTime date, int views, List<Category> categories, List<Reaction> reactions, int updateId, Update parent, string release, string version, string download, string website, string fileSize, string license, List<OS> os)
            : base(articleId, editor, title, content, date, views, categories, reactions)
        {
            this.UpdateID = updateId;
            this.Parent = parent;
            this.Release = release;
            this.Version = version;
            this.Download = download;
            this.Website = website;
            this.FileSize = fileSize;
            this.License = license;
            this.OS = os;
        }

        public int UpdateID { get; set; }

        public Update Parent { get; set; }

        public string Version { get; set; }

        public string Release { get; set; }

        public string Download { get; set; }

        public string Website { get; set; }

        public string FileSize { get; set; }

        public string License { get; set; }

        public List<OS> OS { get; set; }
    }
}
