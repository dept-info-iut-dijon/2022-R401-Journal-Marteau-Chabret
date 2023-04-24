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
        private CategoryViewModel category;

        /// <summary>
        /// Date de l'entrée
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set
            {
                this.entry.Date = value;
                date = value;
                NotifyPropertyChanged("Date");
            }
        }

        /// <summary>
        /// Titre de l'entrée
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                this.entry.Title = value;
                title = value;
                NotifyPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Description de l'entrée
        /// </summary>
        public string Desc
        {
            get { return desc; }
            set
            {
                this.entry.Description = value;
                desc = value;
            }
        }

        /// <summary>
        /// Catégorie de couleur de l'entrée
        /// </summary>
        public Brush CategoryColor 
        { 
            get 
            {
                Brush brush = new SolidColorBrush(Colors.Transparent);
                if (this.entry.Category != null)
                {
                    byte r = (byte)((this.entry.Category.Color & 0xFF0000) >> 16);
                    byte g = (byte)((this.entry.Category.Color & 0x00FF00) >> 8);
                    byte b = (byte)(this.entry.Category.Color & 0x0000FF);
                    System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(255, r, g, b);
                     brush = new SolidColorBrush(color);
                }
                
                return brush; 
            }
        
        }

        /// <summary>
        /// Catégorie Vue Model
        /// </summary>
        public CategoryViewModel Category 
        { 
            get => category;
            set 
            {
                category = value;
                this.entry.Category = category.Model;
                NotifyPropertyChanged("CategoryColor");
            }
        }

        public Entry Entry { get => entry; set => entry = value; }


        /// <summary>
        /// Constructeur naturelle
        /// </summary>
        /// <param name="entry"> entrée </param>
        public EntryViewModel(Entry entry)
        {
            this.entry = entry;
            this.date = this.entry.Date;
            this.title = this.entry.Title;
            this.desc = this.entry.Description;
            this.category = new CategoryViewModel(this.entry.Category);
        }

        public override string ToString()
        {
            return this.entry.ToString();
        }

    }
}
