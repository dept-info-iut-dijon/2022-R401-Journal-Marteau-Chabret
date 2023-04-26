using LogicLayer;
using System.Data.Common;

namespace Diary.Data
{
    /// <summary>
    /// Gère l'utilisateur en base de donnée
    /// </summary>
    public class UserDao
    {
        // Database sur laquelle on agit
        private Database database;

        /// <summary>
        /// Constructreur de la classe
        /// </summary>
        /// <param name="database"> Database </param>
        public UserDao(Database database)
        {
            this.database = database;
        }

        public Student GetStudent(string login, string password)
        {
            Student ?student = null;

            this.database.Connection.Open();
            // Création de la requête
            DbCommand command = this.database.Connection.CreateCommand();
            command.CommandText = "select * from user where login=@login and password=@password";

            // Param 1 : Login
            DbParameter param = command.CreateParameter();
            param.DbType = System.Data.DbType.String;
            param.ParameterName = "@login";
            param.Value = login;
            command.Parameters.Add(param);

            // Param 2 : Password
            DbParameter param2 = command.CreateParameter();
            param.DbType = System.Data.DbType.String;
            param.ParameterName = "@password";
            param2.Value = password;
            command.Parameters.Add(param2);

            // Execution de la requête
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                student.Id = Convert.ToInt32(reader["id"]);
                student.Login = reader["login"].ToString(); ;
                student.Password = reader["password"].ToString(); ;
                student.Name = reader["name"].ToString(); ;
                student.Role = (UserRoles)Convert.ToInt32(reader["role"]);
            }

            return student;
        }
    }
}
