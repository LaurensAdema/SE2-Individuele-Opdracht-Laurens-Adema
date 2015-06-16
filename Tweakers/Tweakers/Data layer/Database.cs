// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database.cs" company="">
//   
// </copyright>
// <summary>
//   The database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data;

    using Oracle.ManagedDataAccess.Client;

    #endregion

    /// <summary>
    /// The database.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        /// The localhost.
        /// </summary>
        private const bool localhost = true;

        /// <summary>
        /// Gets or sets the con.
        /// </summary>
        protected OracleConnection Con { get; set; }

        /// <summary>
        /// The connect.
        /// </summary>
        protected internal void Connect()
        {
            if (this.Con == null)
            {
                this.Con = new OracleConnection();
            }

            if (this.Con.State == ConnectionState.Closed)
            {
                try
                {
                    this.Con.ConnectionString = localhost
                                                    ? "User Id=Tweakers;Password=Welkom01;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=ACER-Laurens)(PORT=1521))(CONNECT_DATA=(SID=xe)));"
                                                    : "User Id=dbi324942;Password=FSM6BF1PUf;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=fhictora)));";
                    this.Con.Open();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// The close.
        /// </summary>
        protected internal void Close()
        {
            this.Con.Close();
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        /// <param name="rowList">
        /// The row list.
        /// </param>
        /// <param name="valueList">
        /// The value list.
        /// </param>
        /// <param name="ID">
        /// The id.
        /// </param>
        protected internal void Edit(string table, List<string> rowList, List<Tuple<string, string>> valueList, int ID)
        {
            try
            {
                string CommandText = string.Format("UPDATE {0} SET", table);
                if (rowList.Count == valueList.Count)
                {
                    for (int i = 0; i < rowList.Count; i++)
                    {
                        switch (valueList[i].Item1)
                        {
                            case "string":
                                CommandText = string.Format(
                                    "{0} {1} = '{2}'", 
                                    CommandText, 
                                    rowList[i], 
                                    valueList[i].Item2);
                                if (i < (rowList.Count - 1))
                                {
                                    CommandText += " AND ";
                                }

                                break;
                            case "date":
                                switch (valueList[i].Item2.Length)
                                {
                                    case 19:
                                        CommandText = string.Format(
                                            "{0} {1} = TO_DATE('{2}', 'dd-MM-yyyy HH:mm:ss')'", 
                                            CommandText, 
                                            rowList[i], 
                                            valueList[i].Item2);
                                        if (i < (rowList.Count - 1))
                                        {
                                            CommandText += " AND ";
                                        }

                                        break;
                                    case 10:
                                        CommandText = string.Format(
                                            "{0} {1} = TO_DATE('{2}', 'dd-MM-yyyy')'", 
                                            CommandText, 
                                            rowList[i], 
                                            valueList[i].Item2);
                                        if (i < rowList.Count)
                                        {
                                            CommandText += " AND ";
                                        }

                                        break;
                                }

                                break;
                            case "int":
                                CommandText = string.Format(
                                    "{0} {1} = {2}", 
                                    CommandText, 
                                    rowList[i], 
                                    valueList[i].Item2);
                                if (i < (rowList.Count - 1))
                                {
                                    CommandText += " AND ";
                                }

                                break;
                        }
                    }
                }

                CommandText = string.Format("{0} WHERE ID = {1}", CommandText, ID);
                this.Connect();
                OracleCommand editCommand = new OracleCommand();
                editCommand.Connection = this.Con;
                editCommand.CommandText = CommandText;
                editCommand.CommandType = CommandType.Text;
                editCommand.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        /// <param name="ID">
        /// The id.
        /// </param>
        protected internal void Delete(string table, int ID)
        {
            try
            {
                this.Connect();
                OracleCommand deleteCommand = new OracleCommand("DELETE FROM {0} WHERE ID = :delID", this.Con);
                deleteCommand.Parameters.Add(":delID", ID);
                deleteCommand.CommandType = CommandType.Text;
                deleteCommand.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        /// <param name="rowList">
        /// The row list.
        /// </param>
        /// <param name="parameterList">
        /// The parameter list.
        /// </param>
        protected internal void Add(string table, List<string> rowList, List<OracleParameter> parameterList)
        {
            try
            {
                string CommandText = string.Format("INSERT INTO {0} (", table);
                foreach (string row in rowList)
                {
                    CommandText = string.Format(rowList[0] == row ? "{0}{1}" : "{0},{1}", CommandText, row);
                }

                CommandText = string.Format("{0}) VALUES (", CommandText);

                foreach (string row in rowList)
                {
                    CommandText = string.Format(rowList[0] == row ? "{0}:{1}" : "{0},:{1}", CommandText, row);
                }

                CommandText = string.Format("{0})", CommandText);
                this.Connect();
                OracleCommand insertCommand = new OracleCommand(CommandText, this.Con);
                foreach (OracleParameter parameter in parameterList)
                {
                    insertCommand.Parameters.Add(parameter);
                }

                insertCommand.CommandType = CommandType.Text;
                insertCommand.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// The read.
        /// </summary>
        /// <param name="selectQuery">
        /// The select query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="OracleDataReader"/>.
        /// </returns>
        protected internal OracleDataReader Read(string selectQuery, List<OracleParameter> parameters)
        {
            OracleDataReader result = null;
            try
            {
                this.Connect();
                OracleCommand selectCommand = new OracleCommand(selectQuery, this.Con);
                foreach (OracleParameter parameter in parameters)
                {
                    selectCommand.Parameters.Add(parameter);
                }

                selectCommand.CommandType = CommandType.Text;
                result = selectCommand.ExecuteReader();
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}