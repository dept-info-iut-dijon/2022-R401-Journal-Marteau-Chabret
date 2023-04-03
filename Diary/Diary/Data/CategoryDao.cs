using LogicLayer;
using System.Data.Common;

namespace Diary.Data
{
    /// <summary>
    /// Liaison avec la base de donnée pour la partie catégories
    /// </summary>
    public class CategoryDao
    {
        private Database database;

        /// <summary>
        /// Constructeur naturelle de la classe
        /// </summary>
        /// <param name="database"> base de donnée </param>
        public CategoryDao(Database database)
        {
            this.database = database;
        }

        /// <summary>
        /// Récupère toutes les catégories
        /// </summary>
        /// <returns> une liste des catégories </returns>
        public Categories GetAllCategories()
        {
            Categories categories = new Categories();
            List<Category> categoriesList = new List<Category>();

            // Ouverture de la bdd
            this.database.Connection.Open();

            // Création de la requête
            DbCommand command = this.database.Connection.CreateCommand();
            command.CommandText = "Select * from diaries.category";

            // Execution de la requête
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            { 
                int id = Convert.ToInt32(reader["id"].ToString());
                string name = reader["name"].ToString();
                int color = Convert.ToInt32(reader["color"].ToString());
                categoriesList.Add(new Category(id, name, color));
            }
            categories.ListCategories = categoriesList;
            return categories;

        }
    }
}
