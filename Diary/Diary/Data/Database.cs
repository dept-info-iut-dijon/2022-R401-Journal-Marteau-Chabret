using MySql.Data.MySqlClient;

namespace Diary.Data
{
    public class Database
    {
        // Représente la connection au serveur sql
        private MySqlConnection connection;

        /// <summary>
        /// Constructeur de la classe qui initialise la connection au serveur
        /// </summary>
        public Database()
        {
            connection = new MySqlConnection("server=srv-iq-etu;database=diaries;uid=iq2;pwd=iq2");
        }

        /// <summary>
        /// Permet de tester la connection au serveur
        /// </summary>
        /// <returns>si la connexion a marchée</returns>
        public bool TestConnection()
        {
            bool ok = false;
            try
            {
                connection.Open();
                ok = connection.State == System.Data.ConnectionState.Open;
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return ok;
        }
    }
}
