using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers
{
    public class Database_Accounts: Database
    {
        public Account GetAccount(int ID)
        {
            Account account = null;

            string accountQuery = "SELECT G.*, A.adminID, A.volledigeNaam as volledigeNaamAdmin, R.* FROM GEBRUIKER G LEFT JOIN G_ADMIN A ON A.gebruikerID = G.gebruikerID LEFT JOIN G_REDACTEUR R ON R.gebruikerID = G.gebruikerID WHERE G.gebruikerID = :ID";
            List<OracleParameter> accountParameters = new List<OracleParameter>();
            accountParameters.Add(new OracleParameter(":ID", ID));

            OracleDataReader getAccount = Read(accountQuery, accountParameters);
            if (getAccount != null)
            {
                if (getAccount.HasRows)
                {
                    while (getAccount.Read())
                    {
                        string userName = Convert.ToString(getAccount["gebruikersNaam"]);
                        string email = Convert.ToString(getAccount["email"]);
                        int tweakotine = 0;
                        Int32.TryParse(getAccount["tweakotine"].ToString(), out tweakotine);
                        int karma = 0;
                        Int32.TryParse(getAccount["karma"].ToString(), out karma);
                        DateTime birthDate;
                        DateTime.TryParse(getAccount["geboorteDatum"].ToString(), out birthDate);
                        string city = Convert.ToString(getAccount["woonplaats"]);
                        char gender;
                        Char.TryParse(getAccount["geslacht"].ToString(), out gender);
                        char type;
                        Char.TryParse(getAccount["G_type"].ToString(), out type);

                        switch (type)
                        {
                            case 'A':
                                int adminID = Convert.ToInt32(getAccount["adminID"]);
                                string fullNameAdmin = Convert.ToString(getAccount["volledigeNaamAdmin"]);
                                account = new Admin(ID, userName, email, tweakotine, karma, birthDate, city, gender,
                                    adminID, fullNameAdmin);
                                break;
                            case 'R':
                                int editorID = Convert.ToInt32(getAccount["redacteurID"]);
                                string fullName = Convert.ToString(getAccount["volledigeNaam"]);
                                string description = Convert.ToString(getAccount["beschrijving"]);
                                string writesAbout = Convert.ToString(getAccount["schrijftOver"]);
                                DateTime authorSince = Convert.ToDateTime(getAccount["auteurSinds"]);
                                account = new Editor(ID, userName, email, tweakotine, karma, birthDate, city, gender,
                                    editorID, fullName, description, writesAbout, authorSince);
                                break;
                            default:
                                account = new Account(ID, userName, email, tweakotine, karma, birthDate, city, gender);
                                break;
                        }

                        break;
                    }
                }
                getAccount.Close();
            }

            Close();

            return account;
        }

        public Account SearchAccount(string query, string searchType, byte exact)
        {
            Account account = null;
            string accountQuery = "SELECT G.*, A.adminID, A.volledigeNaam as volledigeNaamAdmin, R.* FROM GEBRUIKER G LEFT JOIN G_ADMIN A ON A.gebruikerID = G.gebruikerID LEFT JOIN G_REDACTEUR R ON R.gebruikerID = G.gebruikerID WHERE "; ;
            switch (searchType)
            {
                case"email":
                    accountQuery += "UPPER(G.email) ";
                    break;
                case"username":
                    accountQuery += "UPPER(G.gebruikersNaam) ";
                    break;
            }
            switch (exact)
            {
                case 0:
                    accountQuery += "LIKE UPPER(:QUERY)";
                    break;
                case 1:
                    accountQuery += "= UPPER(:QUERY)";
                    break;
            }

            List<OracleParameter> accountParameters = new List<OracleParameter>();
            accountParameters.Add(new OracleParameter(":QUERY", query));

            OracleDataReader getAccount = Read(accountQuery, accountParameters);
            if (getAccount.HasRows)
            {
                while (getAccount.Read())
                {
                    int ID = Convert.ToInt32(getAccount["gebruikerID"]);
                    string userName = Convert.ToString(getAccount["gebruikersNaam"]);
                    string email = Convert.ToString(getAccount["email"]);
                    int tweakotine = 0;
                    Int32.TryParse(getAccount["tweakotine"].ToString(), out tweakotine);
                    int karma = 0;
                    Int32.TryParse(getAccount["karma"].ToString(), out karma);
                    DateTime birthDate = Convert.ToDateTime(getAccount["geboorteDatum"]);
                    string city = Convert.ToString(getAccount["woonplaats"]);
                    char gender = Convert.ToChar(getAccount["geslacht"]);

                    char type = Convert.ToChar(getAccount["G_type"]);
                    switch (type)
                    {
                        case 'A':
                            int adminID = Convert.ToInt32(getAccount["adminID"]);
                            string fullNameAdmin = Convert.ToString(getAccount["volledigeNaamAdmin"]);
                            account = new Admin(ID, userName, email, tweakotine, karma, birthDate, city, gender, adminID, fullNameAdmin);
                            break;
                        case 'R':
                            int editorID = Convert.ToInt32(getAccount["redacteurID"]);
                            string fullName = Convert.ToString(getAccount["volledigeNaam"]);
                            string description = Convert.ToString(getAccount["beschrijving"]);
                            string writesAbout = Convert.ToString(getAccount["schrijftOver"]);
                            DateTime authorSince = Convert.ToDateTime(getAccount["auteurSinds"]);
                            account = new Editor(ID, userName, email, tweakotine, karma, birthDate, city, gender, editorID, fullName, description, writesAbout, authorSince);
                            break;
                        default:
                            account = new Account(ID, userName, email, tweakotine, karma, birthDate, city, gender);
                            break;
                    }

                    break;
                }
            }
            getAccount.Close();

            Close();

            return account;
        }

        public List<Account> GetAllAccounts()
        {
            throw new System.NotImplementedException();
        }

        public void EditAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void AddAccount(Account account, string password)
        {
            List<string> accountRowList = new List<string>();
            List<OracleParameter> accountParamaterList = new List<OracleParameter>();

            accountRowList.Add("gebruikersNaam"); accountRowList.Add("wachtwoord"); accountRowList.Add("email");

            accountParamaterList.Add(new OracleParameter("gebruikersNaam", account.Username));
            accountParamaterList.Add(new OracleParameter("wachtwoord", password));
            accountParamaterList.Add(new OracleParameter("email", account.Email));
            if (account is Admin)
            {
                accountRowList.Add("G_Type");
                accountParamaterList.Add(new OracleParameter("G_Type", "A"));
            } else if (account is Editor)
            {
                accountRowList.Add("G_Type");
                accountParamaterList.Add(new OracleParameter("G_Type", "R"));
            }

            Add("GEBRUIKER", accountRowList, accountParamaterList);
        }

        public void EditPassword(Account account, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public Account CheckCredentials(string email, string password)
        {
            Account account = null;

            string encryptQuery = "SELECT gebruikerID, wachtwoord FROM GEBRUIKER WHERE email = :EMAIL";
            List<OracleParameter> encryptParameters = new List<OracleParameter>();
            encryptParameters.Add(new OracleParameter(":EMAIL", email));

            int ID = -1;
            string passwordEncrypted = null;

            OracleDataReader getEncryptedAccount = Read(encryptQuery, encryptParameters);
            if (getEncryptedAccount != null)
            {
                if (getEncryptedAccount.HasRows)
                {
                    while (getEncryptedAccount.Read())
                    {
                        ID = Convert.ToInt32(getEncryptedAccount["gebruikerID"]);
                        passwordEncrypted = Convert.ToString(getEncryptedAccount["wachtwoord"]);
                        break;
                    }
                    if (Encrypt.ValidatePassword(password, passwordEncrypted))
                    {
                        account = GetAccount(ID);
                    }
                }
                getEncryptedAccount.Close();
            }
            
            Close();

            return account;
        }
    }
}
