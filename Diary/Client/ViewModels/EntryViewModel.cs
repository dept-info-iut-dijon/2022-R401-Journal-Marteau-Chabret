using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Client.ViewModels
{
    /// <summary>
    /// Entrée vue model
    /// </summary>
    public class EntryViewModel : BaseVM
    {
        private Entry entry;
        private DateTime date;
        private string title;
        private string desc;
        private Brush categoryColor;
        private CategoryViewModel category;

        /// <summary>
        /// Date de l'entrée
        /// </summary>
        public DateTime Date { get => date; set => date = value; }

        /// <summary>
        /// Titre de l'entrée
        /// </summary>
        public string Title { get => title; set => title = value; }

        /// <summary>
        /// Description de l'entrée
        /// </summary>
        public string Desc { get => desc; set => desc = value; }

        /// <summary>
        /// Catégorie de couleur de l'entrée
        /// </summary>
        public Brush CategoryColor { get => categoryColor; set => categoryColor = value; }

        /// <summary>
        /// Catégorie Vue Model
        /// </summary>
        public CategoryViewModel Category { get => category; set => category = value; }
      

        /// <summary>
        /// Constructeur naturelle
        /// </summary>
        /// <param name="entry"> entrée </param>
        public EntryViewModel(Entry entry)
        {
            this.entry = entry;
        }

    }
}
