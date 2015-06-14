using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class Reaction
    {
        public Reaction(int reactionId, Account account, Reaction parent, DateTime date, string reactionString)
        {
            this.ReactionID = reactionId;
            this.Account = account;
            this.Parent = parent;
            this.Date = date;
            this.ReactionString = reactionString;
        }

        public Reaction(int reactionId, Account account, DateTime date, string reactionString)
        {
            this.ReactionID = reactionId;
            this.Account = account;
            this.Date = date;
            this.ReactionString = reactionString;
        }

        public int ReactionID { get; set; }

        public Account Account { get; set; }

        public Reaction Parent { get; set; }

        public DateTime Date { get; set; }

        public string ReactionString { get; set; }
    }
}
