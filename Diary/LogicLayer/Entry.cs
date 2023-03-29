using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Entry
    {
        // Représente la catégorie de l'entry
        private Category category;

        private DateTime date;
        private string title;
        private string description;
        private int IDiary;

        /// <summary>
        /// Représente la date de l'entry
        /// </summary>
        public DateTime Date { get => date; set => date = value; }
        
        /// <summary>
        /// Représente le titre de l'entry
        /// </summary>
        public string Title { get => title; set => title = value; }
       
        /// <summary>
        /// Représente la description de l'entry
        /// </summary>
        public string Description { get => description; set => description = value; }
        
        /// <summary>
        /// Représente le int de l'entry
        /// </summary>
        public int IDiary1 { get => IDiary; set => IDiary = value; }
    }
}
