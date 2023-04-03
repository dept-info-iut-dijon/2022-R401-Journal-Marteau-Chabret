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
        private int id;
        private string name;
        private int color;

        /// <summary>
        /// Cosntructeur naturelle
        /// </summary>
        public Category()
        {

        }

        /// <summary>
        /// Constructeur de la classe Category
        /// </summary>
        /// <param name="name">nom de la catégorie</param>
        /// <param name="color">couleur de la catégorie</param>
        public Category(int id, string name, int color)
        {
            this.id = id;
            this.name = name;
            this.color = color;
        }

        /// <summary>
        /// ID de la catégorie
        /// </summary>
        public int ID { get => id; set => id = value; }

        /// <summary>
        /// Représente le nom de la catégorie
        /// </summary>
        public string Name { get => name; set => name = value; }
        
        /// <summary>
        /// Représente la couleur de la catégorie
        /// </summary>
        public int Color { get => color; set => color = value; }

        public override bool Equals(object? obj)
        {
            return obj is Category category &&
                   id == category.id &&
                   name == category.name &&
                   color == category.color;
        }

        public override string ToString()
        {
            return this.name + " " + this.color;
        }
    }
}
