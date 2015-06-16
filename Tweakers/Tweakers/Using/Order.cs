// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="">
//   
// </copyright>
// <summary>
//   The sort order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers.Using
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The sort order.
    /// </summary>
    public static class SortOrder
    {
        /// <summary>
        /// The remaining reactions.
        /// </summary>
        private static List<Reaction> remainingReactions;

        /// <summary>
        /// The order reactions.
        /// </summary>
        private static readonly List<Reaction> orderReactions = new List<Reaction>();

        /// <summary>
        /// The order reactions.
        /// </summary>
        /// <param name="reactions">
        /// The reactions.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Reaction> OrderReactions(List<Reaction> reactions)
        {
            remainingReactions = reactions;

            for (int i = 0; i < reactions.Count; i++)
            {
                if (reactions[i].Parent == null)
                {
                    orderReactions.Add(reactions[i]);
                    remainingReactions.Remove(reactions[i]);
                }
            }

            while (remainingReactions.Count > 0)
            {
                foreach (Tuple<Reaction, Reaction, int> combination in FindChildren())
                {
                    orderReactions.Insert(
                        orderReactions.IndexOf(combination.Item1) + combination.Item3, 
                        combination.Item2);
                    remainingReactions.Remove(combination.Item2);
                }
            }

            return orderReactions;
        }

        /// <summary>
        /// The find children.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private static List<Tuple<Reaction, Reaction, int>> FindChildren()
        {
            List<Tuple<Reaction, Reaction, int>> foundReactions = new List<Tuple<Reaction, Reaction, int>>();
            foreach (Reaction remainingReaction in remainingReactions)
            {
                foreach (Reaction parent in orderReactions)
                {
                    if (remainingReaction.Parent.ReactionID == parent.ReactionID)
                    {
                        int place = 1;
                        if (orderReactions[orderReactions.IndexOf(parent) + 1].Parent != null)
                        {
                            if (orderReactions[orderReactions.IndexOf(parent) + 1].Date < remainingReaction.Date
                                && orderReactions[orderReactions.IndexOf(parent) + 1].Parent.ReactionID
                                == remainingReaction.Parent.ReactionID)
                            {
                                place = 2;
                            }
                        }

                        if (foundReactions.Count != 0)
                        {
                            if (foundReactions[foundReactions.Count - 1].Item2.Date >= remainingReaction.Date)
                            {
                                foundReactions.Insert(
                                    foundReactions.Count, 
                                    new Tuple<Reaction, Reaction, int>(parent, remainingReaction, place));
                            }
                        }
                        else
                        {
                            foundReactions.Add(new Tuple<Reaction, Reaction, int>(parent, remainingReaction, place));
                        }

                        break;
                    }
                }
            }

            return foundReactions;
        }

        /// <summary>
        /// The get children.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private static List<Reaction> GetChildren(Reaction parent)
        {
            List<Reaction> foundReactions = new List<Reaction>();
            foreach (Reaction childReaction in remainingReactions)
            {
                if (childReaction.Parent.ReactionID == parent.ReactionID)
                {
                    foundReactions.Add(childReaction);
                }
            }

            foreach (Reaction reactionFound in foundReactions)
            {
                remainingReactions.Remove(reactionFound);
            }

            return foundReactions;
        }
    }
}