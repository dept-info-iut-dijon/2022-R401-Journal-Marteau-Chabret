using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Liste des catégories
    /// </summary>
    public class Categories
    {

        private List<Category> categories = new List<Category>();

        /// <summary>
        /// Représente les différentes catégories
        /// </summary>
        public List<Category> ListCategories { get => categories; set => categories = value; }
    
    
        /// <summary>
        /// Permet d'ajouter une catégorie à la liste
        /// </summary>
        /// <param name="c">nouvelle catégorie</param>
        public void Add(Category c)
        {
            categories.Add(c);
        }
    }
}
