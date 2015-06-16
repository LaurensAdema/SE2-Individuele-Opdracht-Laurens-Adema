// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reaction.cs" company="">
//   
// </copyright>
// <summary>
//   The reaction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The reaction.
    /// </summary>
    public class Reaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reaction"/> class.
        /// </summary>
        /// <param name="reactionId">
        /// The reaction id.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="reactionString">
        /// The reaction string.
        /// </param>
        public Reaction(int reactionId, Account account, Reaction parent, DateTime date, string reactionString)
        {
            this.ReactionID = reactionId;
            this.Account = account;
            this.Parent = parent;
            this.Date = date;
            this.ReactionString = reactionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reaction"/> class.
        /// </summary>
        /// <param name="reactionId">
        /// The reaction id.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="reactionString">
        /// The reaction string.
        /// </param>
        public Reaction(int reactionId, Account account, DateTime date, string reactionString)
        {
            this.ReactionID = reactionId;
            this.Account = account;
            this.Date = date;
            this.ReactionString = reactionString;
        }

        /// <summary>
        /// Gets or sets the reaction id.
        /// </summary>
        public int ReactionID { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        public Reaction Parent { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the reaction string.
        /// </summary>
        public string ReactionString { get; set; }
    }
}