
// file:	ConnexionSql.cs
//
// summary:	Implements the connexion SQL class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Sql;

namespace ConsoleApplication1
{
    /// <summary>   A connexion sql. </summary>
    ///
    /// <remarks>   Clément Legrand, 27/03/2018. </remarks>

    class ConnexionSql
    {
        /// <summary>   The connexion. </summary>
        private MySqlConnection connexion;
        /// <summary>   The command. </summary>
        private MySqlCommand cmd;
        /// <summary>   The reader. </summary>
        private MySqlDataReader reader;
        /// <summary>   The server. </summary>
        private string server;
        /// <summary>   The database. </summary>
        private string database;
        /// <summary>   The UID. </summary>
        private string uid;
        /// <summary>   The password. </summary>
        private string password;
        /// <summary>   True to fin curseur. </summary>
        private Boolean finCurseur;

        /// <summary>   constructeur. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>

        public ConnexionSql()
        {
            Initialize();
        }

        /// <summary>   méthode appelée par le constructeur. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>

        private void Initialize()
        {
            server = "https://gsbwebservice.000webhostapp.com";
            database = "gsb_frais";
            uid = "id5409589_admin";
            password = "Motdepasse0";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connexion = new MySqlConnection(connectionString);
        }

        /// <summary>   ouverture de la connexion. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public bool OpenConnection()
        {
            try
            {
                connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return true;
        }

        /// <summary>   fermeture de la connexion. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public bool CloseConnection()
        {
            connexion.Close();
            return true;
        }

        /// <summary>   méthode d'exécution d'une requête update. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <param name="query">    . </param>

        public void ReqUpdate(string query)
        {
            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, connexion);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        /// <summary>   méthode d'exécution d'une requête insert. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <param name="query">    . </param>

        public void ReqInsert(string query)
        {
            cmd = new MySqlCommand(query, connexion);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        /// <summary>   méthode d'exécution d'une requête delete. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <param name="query">    . </param>
        ///
        /// ### <param name="Query">    . </param>

        public void ReqDelete(string query)
        {
            cmd = new MySqlCommand(query, connexion);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        /// <summary>   méthode d'exécution d'une requête select. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <param name="query">    . </param>

        public void ReqSelect(string query)
        {
            cmd = new MySqlCommand(query, this.connexion);
            this.reader = cmd.ExecuteReader();
            finCurseur = false;
            while (!finCurseur)
            {
                try
                {

                    Console.WriteLine(String.Format("{0} {1}", reader[0], reader[1]));
                    ConsoleKeyInfo cki = Console.ReadKey();
                    this.suivant();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

        /// <summary>   méthode de passage à la ligne suivante du curseur. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>

        public void suivant()
        {
            if (!this.finCurseur)
            {
                finCurseur = !reader.Read();
            }
        }

        /// <summary>   test de la fin du curseur. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        public Boolean fin()
        {
            return finCurseur;
        }

        /// <summary>   récupération d'un champ. </summary>
        ///
        /// <remarks>   Clément Legrand, 27/03/2018. </remarks>
        ///
        /// <param name="nomChamp"> . </param>
        ///
        /// <returns>   An Object. </returns>

        public Object Champ(string nomChamp)
        {
            return this.reader[nomChamp];
        }


    }
}

