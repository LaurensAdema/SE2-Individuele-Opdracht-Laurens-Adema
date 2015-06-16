// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database_Reaction.cs" company="">
//   
// </copyright>
// <summary>
//   The database_ reaction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Oracle.ManagedDataAccess.Client;

    #endregion

    /// <summary>
    /// The database_ reaction.
    /// </summary>
    public class Database_Reaction : Database
    {
        /// <summary>
        /// The add reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddReaction(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The edit reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditReaction(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove reaction.
        /// </summary>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void RemoveReaction(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get reaction.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Reaction"/>.
        /// </returns>
        public Reaction GetReaction(int ID)
        {
            Reaction reaction = null;

            string reactionQuery = "SELECT * FROM REACTIE WHERE reactieID = :reactionID";
            List<OracleParameter> reactionParameters = new List<OracleParameter>();
            reactionParameters.Add(new OracleParameter(":reactionID", ID));

            OracleDataReader getReaction = this.Read(reactionQuery, reactionParameters);
            if (getReaction != null)
            {
                if (getReaction.HasRows)
                {
                    while (getReaction.Read())
                    {
                        int reactionID = Convert.ToInt32(getReaction["reactieID"]);
                        int userID = Convert.ToInt32(getReaction["gebruikerID"]);
                        int parentID = 0;
                        int.TryParse(getReaction["parentID"].ToString(), out parentID);
                        DateTime date = Convert.ToDateTime(getReaction["datum"]);
                        string comment = Convert.ToString(getReaction["reactie"]);

                        Reaction parent = null;
                        if (parentID > 0)
                        {
                            Database_Reaction dbReaction = new Database_Reaction();
                            parent = dbReaction.GetReaction(parentID);
                        }

                        reaction = new Reaction(
                            reactionID, 
                            Administration.AdministrationProp.GetAccount(userID), 
                            parent, 
                            date, 
                            comment);
                    }
                }

                getReaction.Close();
            }

            this.Close();

            return reaction;
        }

        /// <summary>
        /// The get all reactions.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Reaction> GetAllReactions(int ID)
        {
            List<Reaction> allReactions = new List<Reaction>();

            string reactionQuery = "SELECT * FROM REACTIE WHERE artikelID = :articleID ORDER BY datum ASC";
            List<OracleParameter> reactionParameters = new List<OracleParameter>();
            reactionParameters.Add(new OracleParameter(":articleID", ID));

            OracleDataReader getAllReactions = this.Read(reactionQuery, reactionParameters);
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
                        int.TryParse(getAllReactions["parentID"].ToString(), out parentID);
                        DateTime date = Convert.ToDateTime(getAllReactions["datum"]);
                        string comment = Convert.ToString(getAllReactions["reactie"]);

                        Reaction parent = null;
                        if (parentID > 0)
                        {
                            foreach (
                                Reaction allReaction in
                                    allReactions.Where(allReaction => allReaction.ReactionID == parentID))
                            {
                                parent = allReaction;
                            }

                            if (parent == null)
                            {
                                Database_Reaction dbReaction = new Database_Reaction();
                                parent = dbReaction.GetReaction(parentID);
                            }
                        }

                        reaction = new Reaction(
                            reactionID, 
                            Administration.AdministrationProp.GetAccount(userID), 
                            parent, 
                            date, 
                            comment);

                        allReactions.Add(reaction);
                    }
                }

                getAllReactions.Close();
            }

            this.Close();

            return allReactions;
        }

        /// <summary>
        /// The add score.
        /// </summary>
        /// <param name="acccount">
        /// The acccount.
        /// </param>
        /// <param name="score">
        /// The score.
        /// </param>
        /// <param name="reaction">
        /// The reaction.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void AddScore(Account acccount, int score, Reaction reaction)
        {
            throw new NotImplementedException();
        }
    }
}