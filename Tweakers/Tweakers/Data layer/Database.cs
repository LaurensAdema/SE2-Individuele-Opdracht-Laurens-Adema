using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers
{
    abstract public class Database
    {
        private const bool localhost = false;
        protected OracleConnection Con { get; set; }

        protected internal void Connect()
        {
            if (Con == null)
            {
                Con = new OracleConnection();
            }
            if (Con.State == ConnectionState.Closed)
            {
                try
                {
                    this.Con.ConnectionString = localhost ? "User Id=Tweakers;Password=Welkom01;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.107)(PORT=1521))(CONNECT_DATA=(SID=xe)));" : "User Id=dbi324942;Password=FSM6BF1PUf;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=fhictora)));";
                    Con.Open();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        protected internal void Close()
        {
            Con.Close();
        }

        protected internal void Edit(string table, List<string> rowList, List<Tuple<string, string>> valueList, int ID)
        {
            try
            {
                string CommandText = String.Format("UPDATE {0} SET", table);
                if (rowList.Count == valueList.Count)
                {
                    for (int i = 0; i < rowList.Count; i++)
                    {
                        switch (valueList[i].Item1)
                        {
                            case "string":
                                CommandText = String.Format("{0} {1} = '{2}'", CommandText, rowList[i], valueList[i].Item2);
                                if (i < (rowList.Count - 1))
                                {
                                    CommandText += " AND ";
                                }
                                break;
                            case "date":
                                switch (valueList[i].Item2.Length)
                                {
                                    case 19:
                                        CommandText = String.Format("{0} {1} = TO_DATE('{2}', 'dd-MM-yyyy HH:mm:ss')'", CommandText, rowList[i], valueList[i].Item2);
                                        if (i < (rowList.Count - 1))
                                        {
                                            CommandText += " AND ";
                                        }
                                        break;
                                    case 10:
                                        CommandText = String.Format("{0} {1} = TO_DATE('{2}', 'dd-MM-yyyy')'", CommandText, rowList[i], valueList[i].Item2);
                                        if (i < rowList.Count)
                                        {
                                            CommandText += " AND ";
                                        }
                                        break;
                                }
                                break;
                            case "int":
                                CommandText = String.Format("{0} {1} = {2}", CommandText, rowList[i], valueList[i].Item2);
                                if (i < (rowList.Count - 1))
                                {
                                    CommandText += " AND ";
                                }
                                break;
                        }
                    }
                }

                CommandText = String.Format("{0} WHERE ID = {1}", CommandText, ID);
                this.Connect();
                OracleCommand editCommand = new OracleCommand();
                editCommand.Connection = Con;
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

        protected internal void Delete(string table, int ID)
        {
            try
            {
                this.Connect();
                OracleCommand deleteCommand = new OracleCommand("DELETE FROM {0} WHERE ID = :delID", Con);
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

        protected internal void Add(string table, List<string> rowList, List<OracleParameter> parameterList)
        {
            try
            {
                string CommandText = String.Format("INSERT INTO {0} (", table);
                foreach (string row in rowList)
                {
                    CommandText = String.Format(rowList[0] == row ? "{0}{1}" : "{0},{1}", CommandText, row);
                }

                CommandText = String.Format("{0}) VALUES (", CommandText);

                foreach (string row in rowList)
                {
                    CommandText = String.Format(rowList[0] == row ? "{0}:{1}" : "{0},:{1}", CommandText, row);
                }

                CommandText = String.Format("{0})", CommandText);
                this.Connect();
                OracleCommand insertCommand = new OracleCommand(CommandText, Con);
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

        protected internal OracleDataReader Read(string selectQuery, List<OracleParameter> parameters)
        {
            OracleDataReader result = null;
            try
            {
                this.Connect();
                OracleCommand selectCommand = new OracleCommand(selectQuery, Con);
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
