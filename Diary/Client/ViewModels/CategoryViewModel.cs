using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;

namespace Client.ViewModels
{
    /// <summary>
    /// Catégorie vue model
    /// </summary>
    public class CategoryViewModel : BaseVM
    {
        private Category model;

        private Brush color;
        /// <summary>
        /// Couleure de la catégorie
        /// </summary>
        public Brush Color
        {
            get
            {
                byte r = (byte)((this.model.Color & 0xFF0000) >> 16);
                byte g = (byte)((this.model.Color & 0x00FF00) >> 8);
                byte b = (byte)(this.model.Color & 0x0000FF);
                System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(255, r, g, b);
                Brush brush = new SolidColorBrush(color);
                return brush;
            }
            set => color = value;
        }

        private string name;
        /// <summary>
        /// Nom de la catégorie
        /// </summary>
        public string Name
        {
            get => model.Name;
            set => name = value;
        }

        /// <summary>
        /// Constructeur du vue modele Catégorie
        /// </summary>
        /// <param name="model">Catégorie servant de base</param>
        public CategoryViewModel(Category model)
        {
            this.model = model;
        }

        public override string ToString()
        {
            return model.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is CategoryViewModel model &&
                   this.model.Equals(model.model); 
        }
    }
}
