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
            get => color;
            set => color = value;
        }

        private string name;
        /// <summary>
        /// Nom de la catégorie
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

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
                   EqualityComparer<Category>.Default.Equals(this.model, model.model) &&
                   EqualityComparer<Brush>.Default.Equals(color, model.color) &&
                   name == model.name;
        }
    }
}
