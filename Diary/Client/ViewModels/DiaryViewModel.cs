using LogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    /// <summary>
    /// Journal vue model
    /// </summary>
    public class DiaryViewModel : BaseVM
    {
        
        private EntryViewModel current;
        private Diary model;
        private ObservableCollection<EntryViewModel> items;
        private List<CategoryViewModel> categories;

        /// <summary>
        /// Journal 
        /// </summary>
        public Diary Model
        {
            get => model;
            set => model = value;
        }

        /// <summary>
        /// Liste d'items
        /// </summary>
        public ObservableCollection<EntryViewModel> Items
        {
            get => items;
            set => items = value;   
        }

        /// <summary>
        /// Liste des catégories
        /// </summary>
        public List<CategoryViewModel> Categories
        {
            get => categories;
            set => categories = value;  
        }
       

        /// <summary>
        /// Constructeur naturelle
        /// </summary>
        /// <param name="user"> Utilisateur qui se connecte </param>
        /// <param name="network"> Network </param>
        public DiaryViewModel(Diary model)
        {

            this.model = model;

            Items = new ObservableCollection<EntryViewModel>();
            foreach(Entry e in model.Entries)
            {
                Items.Add(new EntryViewModel(e));
            }
        }

        /// <summary>
        /// Créer une entrée
        /// </summary>
        public void CreateEntry()
        {

        }

        /// <summary>
        /// lis les catégories
        /// </summary>
        public void ReadCategories()
        {

        }

        /// <summary>
        /// Ajoute une entrée
        /// </summary>
        public void AddEntry()
        {

        }

        /// <summary>
        /// Sauvegarde une entrée
        /// </summary>
        public void SaveEntry()
        {

        }
    }
}
