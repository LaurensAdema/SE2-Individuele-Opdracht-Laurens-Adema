using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Using
{
    static public class SortOrder
    {
        static public List<Reaction> OrderReactionsA(List<Reaction> reactions)
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
                    int children = 0;

                    if (reactions[i].Parent != null)
                    {
                        int index = -1;

                        for (int j = 0; j < sortedReactions.Count; j++)
                        {
                            if (sortedReactions[j].ReactionID == reactions[i].Parent.ReactionID)
                            {
                                index = j+1;
                                break;
                            }
                        }
                        
                        if (index >= 0)
                        {
                            sortedReactions.Insert(index+children, reactions[i]);
                            reactions.Remove(reactions[i]);
                            children++;
                        }
                    }
                }
            }

            return sortedReactions;
        }

        static public List<Reaction> OrderReactions(List<Reaction> reactions)
        {
            return OrderReactionsB(reactions);
        }
    }
}