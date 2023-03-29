using LogicLayer;

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
        public Diary Read(User user)
        {

        }

        /// <summary>
        /// Permet d'ajouter un utilisateur et son journal dans la bdd
        /// </summary>
        /// <param name="entry">entrée à ajouter</param>
        public void AddEntry(Entry entry)
        {

        }
    }
}
