using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers
{
    public class Database_Reaction: Database
    {
        public void AddReaction(Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public void EditReaction(Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveReaction(Reaction reaction)
        {
            throw new System.NotImplementedException();
        }

        public Reaction GetReaction(int ID)
        {
            Reaction reaction = null;

            string reactionQuery = "SELECT * FROM REACTIE WHERE reactieID = :reactionID";
            List<OracleParameter> reactionParameters = new List<OracleParameter>();
            reactionParameters.Add(new OracleParameter(":reactionID", ID));

            OracleDataReader getReaction = Read(reactionQuery, reactionParameters);
            if (getReaction != null)
            {
                if (getReaction.HasRows)
                {
                    while (getReaction.Read())
                    {
                        int reactionID = Convert.ToInt32(getReaction["reactieID"]);
                        int userID = Convert.ToInt32(getReaction["gebruikerID"]);
                        int parentID = 0;
                        Int32.TryParse(getReaction["parentID"].ToString(), out parentID);
                        DateTime date = Convert.ToDateTime(getReaction["datum"]);
                        string comment = Convert.ToString(getReaction["reactie"]);

                        Reaction parent = null;
                        if (parentID > 0)
                        {
                            Database_Reaction dbReaction = new Database_Reaction();
                            parent = dbReaction.GetReaction(parentID);
                        }

                        reaction = new Reaction(reactionID, Administration.AdministrationProp.GetAccount(userID), parent, date, comment);
                    }
                }
                getReaction.Close();
            }

            Close();

            return reaction;
        }

        public List<Reaction> GetAllReactions(int ID)
        {
            List<Reaction> allReactions = new List<Reaction>();

            string reactionQuery = "SELECT * FROM REACTIE WHERE artikelID = :articleID ORDER BY datum ASC";
            List<OracleParameter> reactionParameters = new List<OracleParameter>();
            reactionParameters.Add(new OracleParameter(":articleID", ID));

            OracleDataReader getAllReactions = Read(reactionQuery, reactionParameters);
            if (getAllReactions != null)
            {
                if (getAllReactions.HasRows)
                {
                    while (getAllReactions.Read())
                    {
                        Reaction reaction;

                        int reactionID = Convert.ToInt32(getAllReactions["reactieID"]);
                        int userID = Convert.ToInt32(getAllReactions["gebruikerID"]);
                        int parentID = 0;
                        Int32.TryParse(getAllReactions["parentID"].ToString(), out parentID);
                        DateTime date = Convert.ToDateTime(getAllReactions["datum"]);
                        string comment = Convert.ToString(getAllReactions["reactie"]);

                        Reaction parent = null;
                        if (parentID > 0)
                        {
                            foreach (Reaction allReaction in allReactions.Where(allReaction => allReaction.ReactionID == parentID))
                            {
                                parent = allReaction;
                            }
                            if (parent == null)
                            {
                                Database_Reaction dbReaction = new Database_Reaction();
                                parent = dbReaction.GetReaction(parentID);
                            }
                        }

                        reaction = new Reaction(reactionID, Administration.AdministrationProp.GetAccount(userID), parent, date, comment);

                        allReactions.Add(reaction);
                    }
                }
                getAllReactions.Close();
            }

            Close();

            return allReactions;
        }

        public void AddScore(Account acccount, int score, Reaction reaction)
        {
            throw new System.NotImplementedException();
        }
    }
}
