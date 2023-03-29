using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Journal
    /// </summary>
    public class Diary
    {
        private int id;
        private List<Entry> entries;

        /// <summary>
        /// ID du journal
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Liste des entrées du journals
        /// </summary>
        public List<Entry> Entries { get => entries; set => entries = value; }

        /// <summary>
        /// Constructeur naturelle
        /// </summary>
        /// <param name="id">id du journal</param>
        public Diary(int id)
        {
            this.id = id;
            this.entries = new List<Entry>();
        }

        /// <summary>
        /// Ajoute une entrée
        /// </summary>
        /// <param name="entry"></param>
        public void Add(Entry entry)
        {
            entries.Add(entry);
        }
    }
}