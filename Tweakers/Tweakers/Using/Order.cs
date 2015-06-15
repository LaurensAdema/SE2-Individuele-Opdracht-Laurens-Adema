using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Using
{
    static public class SortOrder
    {
        private static List<Reaction> remainingReactions;
        private static List<Reaction> orderReactions = new List<Reaction>(); 

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
                foreach (Tuple<Reaction, Reaction> combination in FindChildren())
                {
                    orderReactions.Insert(orderReactions.IndexOf(combination.Item1)+1, combination.Item2);
                    remainingReactions.Remove(combination.Item2);
                }
            }

            return orderReactions;
        }


        static private List<Tuple<Reaction,Reaction>> FindChildren()
        {
            List<Tuple<Reaction, Reaction>> foundReactions = new List<Tuple<Reaction, Reaction>>();
            foreach (Reaction remainingReaction in remainingReactions)
            {
                foreach (Reaction parent in orderReactions)
                {
                    if (remainingReaction.Parent.ReactionID == parent.ReactionID)
                    {
                        foundReactions.Add(new Tuple<Reaction, Reaction>(parent, remainingReaction));
                        break;
                    }
                }
            }
            return foundReactions;
        }

        static private List<Reaction> GetChildren(Reaction parent)
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