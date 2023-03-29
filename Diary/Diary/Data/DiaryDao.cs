using LogicLayer;
using System.Data.Common;

namespace Diary.Data
{
    public class DiaryDao
    {
        // Représente la bdd du journal
        private Database database;

        /// <summary>
        /// Constructeur de la classe DiaryDao
        /// </summary>
        /// <param name="db">database à initialiser</param>
        public DiaryDao(Database db)
        {
            database = db;
        }

        /// <summary>
        /// Permet de récupérer le journal d'un utilisateur
        /// </summary>
        /// <param name="user">utilisateur souhaité</param>
        /// <returns>son journal</returns>
        public LogicLayer.Diary Read(User user)
        {
            LogicLayer.Diary diary = new LogicLayer.Diary(0);

            // Ouverture de la bdd
            this.database.Connection.Open();

            // Création de la requête
            DbCommand command = this.database.Connection.CreateCommand();
            command.CommandText = "Select IDDiary,category.name,color,entry.date,title,entry.desc from entry natural join diary inner join category on entry.IDCategory = category.ID where IDUser =@id";

            DbParameter param = command.CreateParameter();
            param.DbType = System.Data.DbType.Int32;
            param.ParameterName = "@id";
            param.Value = user.Id;
            command.Parameters.Add(param);

            // Execution de la requête
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Entry entry = new Entry();
                entry.Description = reader["desc"].ToString();
                entry.Title = reader["title"].ToString();
                entry.Date = Convert.ToDateTime(reader["date"]);
                entry.IDiary1 = Convert.ToInt32(reader["IDDiary"]);
                diary.Id = entry.IDiary1;
                diary.Add(entry);
            }


            return diary;
        }
        /// <summary>
        /// Permet d'ajouter un utilisateur et son journal dans la bdd
        /// </summary>
        /// <param name="entry">entrée à ajouter</param>
        public void AddEntry(Entry entry)
        {
            // Ouverture de la bdd
            this.database.Connection.Open();

            // Recuperation Categorie ID

                // Création de la requête
                DbCommand command = this.database.Connection.CreateCommand();
                command.CommandText = $"Select ID from category where name = @nom AND color = @color)";

                // Réglage des parametres
                DbParameter paramNom = command.CreateParameter();
                paramNom.DbType = System.Data.DbType.String;
                paramNom.ParameterName = "@nom";
                paramNom.Value = entry.Category.Name;
                DbParameter paramColor = command.CreateParameter();
                paramColor.DbType = System.Data.DbType.Int32;
                paramColor.ParameterName = "@color";
                paramColor.Value = entry.Category.Color;

                command.Parameters.Add(paramColor);
                command.Parameters.Add(paramNom);

                // Execution de la requête
                DbDataReader reader = command.ExecuteReader();

                int idCateg = 0;
                while (reader.Read())
                {
                    idCateg = Convert.ToInt32(reader["id"]);
                }

            /// Ajout entry

            // Création de la requête
            DbCommand command2 = this.database.Connection.CreateCommand();
                command2.CommandText = $"Insert into entry values('NULL','{entry.Date}','{entry.Title}','{entry.Description}','{idCateg}')";

                // Execution de la requête
                command2.ExecuteNonQuery();
        }
    }
}
