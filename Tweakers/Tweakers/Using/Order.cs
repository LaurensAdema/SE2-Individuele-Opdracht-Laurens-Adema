using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Using
{
    static public class SortOrder
    {
        static public List<Reaction> OrderReactionsB(List<Reaction> reactions)
        {
            List<Reaction> sortedReactions = new List<Reaction>();

            for (int i = 0; i < reactions.Count; i++)
            {
                if (reactions[i].Parent == null)
                {
                    sortedReactions.Add(reactions[i]);
                    reactions.Remove(reactions[i]);
                }
            }
            while (reactions.Count > 0)
            {
                for (int i = 0; i < reactions.Count; i++)
                {
                    if (reactions[i].Parent != null)
                    {
                        sortedReactions.Insert(sortedReactions.IndexOf(reactions[i].Parent)+1, reactions[i]);
                        reactions.Remove(reactions[i]);
                    }
                }
            }

            return sortedReactions;
        }

        static public List<Reaction> OrderReactions(List<Reaction> reactions)
        {
            List<Reaction> sortedReactions = new List<Reaction>();

            for (int i = 0; i < reactions.Count; i++)
            {
                if (reactions[i].Parent == null)
                {
                    sortedReactions.Add(reactions[i]);
                    reactions.Remove(reactions[i]);
                }
            }
            while (reactions.Count > 0)
            {
                for (int i = 0; i < reactions.Count; i++)
                {
                    if (reactions[i].Parent != null)
                    {
                        sortedReactions.Insert(sortedReactions.IndexOf(reactions[i].Parent), reactions[i]);
                        reactions.Remove(reactions[i]);
                    }
                }
            }

            return sortedReactions;
        }
    }
}