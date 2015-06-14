using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Editor: Account
    {
        public Editor(int userId, string username, string email, int tweakotine, int karma, DateTime birthdate, string city, char gender, int editorId, string fullName, string description, string writesOver, DateTime authorSince)
            : base(userId, username, email, tweakotine, karma, birthdate, city, gender)
        {
            this.EditorID = editorId;
            this.FullName = fullName;
            this.Description = description;
            this.WritesOver = writesOver;
            this.AuthorSince = authorSince;
        }

        public int EditorID { get; set; }

        public string FullName { get; set; }

        public string Description { get; set; }

        public string WritesOver { get; set; }

        public DateTime AuthorSince { get; set; }
    }
}
