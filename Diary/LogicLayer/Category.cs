using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Catégorie 
    /// </summary>
    public class Category
    {
        private string name;
        private int color;

        /// <summary>
        /// Constructeur de la classe Category
        /// </summary>
        /// <param name="name">nom de la catégorie</param>
        /// <param name="color">couleur de la catégorie</param>
        public Category(string name, int color)
        {
            this.name = name;
            this.color = color;
        }
        /// <summary>
        /// Représente le nom de la catégorie
        /// </summary>
        public string Name { get => name; set => name = value; }
        
        /// <summary>
        /// Représente la couleur de la catégorie
        /// </summary>
        public int Color { get => color; set => color = value; }
    }
}
