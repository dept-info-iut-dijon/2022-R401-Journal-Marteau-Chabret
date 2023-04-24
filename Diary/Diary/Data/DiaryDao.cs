using LogicLayer;
using System.Data.Common;
using System.Globalization;

namespace Diary.Data
{
    /// <summary>
    /// Liaison avec la base de donnée pour le journal
    /// </summary>
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
            command.CommandText = "Select IDDiary,category.id,category.name,color,entry.date,title,entry.desc from entry inner join diary on entry.IDDiary = diary.ID inner join category on entry.IDCategory = category.ID where IDUser =@id";

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
                entry.IDDiary = Convert.ToInt32(reader["IDDiary"]);
                Category c = new Category(Convert.ToInt16(reader["id"]),reader["name"].ToString(), Convert.ToInt32(reader["color"]));
                entry.Category = c;
                diary.Id = entry.IDDiary;
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

            // Création de la requête 
            DbCommand command = this.database.Connection.CreateCommand();
            command.CommandText = "insert into diaries.entry values(null, @date, @titre, @description, @idCategory, @idDiary);";

            // Paramètre de la requête
            DbParameter paramDate = command.CreateParameter();
            paramDate.DbType = System.Data.DbType.Date;
            paramDate.ParameterName = "@date";
            paramDate.Value = entry.Date;
            command.Parameters.Add(paramDate);

            DbParameter paramTitre = command.CreateParameter();
            paramTitre.DbType = System.Data.DbType.String;
            paramTitre.ParameterName = "@titre";
            paramTitre.Value = entry.Title;
            command.Parameters.Add(paramTitre);

            DbParameter paramDescription = command.CreateParameter();
            paramDescription.DbType = System.Data.DbType.String;
            paramDescription.ParameterName = "@description";
            paramDescription.Value = entry.Description;
            command.Parameters.Add(paramDescription);

            DbParameter paramCategory = command.CreateParameter();
            paramCategory.DbType = System.Data.DbType.Int32;
            paramCategory.ParameterName = "@idCategory";
            paramCategory.Value = entry.Category.ID;
            command.Parameters.Add(paramCategory);

            DbParameter paramDiary = command.CreateParameter();
            paramDiary.DbType = System.Data.DbType.Int32;
            paramDiary.ParameterName = "@idDiary";
            paramDiary.Value = entry.IDDiary;
            command.Parameters.Add(paramDiary);

            // Exécute la requête
            command.ExecuteNonQuery();
        }
    }
}
