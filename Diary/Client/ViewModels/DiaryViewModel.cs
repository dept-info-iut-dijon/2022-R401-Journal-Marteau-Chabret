using LogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private ObservableCollection<CategoryViewModel> categories;
        private INetworkClient networkClient;

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
        public ObservableCollection<CategoryViewModel> Categories
        {
            get => categories;
            set => categories = value;  
        }

        /// <summary>
        /// Entry selectionnée
        /// </summary>
        public EntryViewModel CurrentEntry 
        { 
            get => current;
            set { 
                current = value;
                NotifyPropertyChanged("Visible");
                NotifyPropertyChanged("CurrentEntry");

            } 
        }

        /// <summary>
        /// Renvoie si la modification du journal est visible ou pas
        /// </summary>
        public Visibility Visible
        {
            get
            {
                Visibility visibility = Visibility.Hidden;
                if (current != null)
                {
                    visibility = Visibility.Visible;
                    
                }
                return visibility;
            }
        }

        /// <summary>
        /// Constructeur naturelle
        /// </summary>
        /// <param name="user"> Utilisateur qui se connecte </param>
        /// <param name="network"> Network </param>
        public DiaryViewModel(Diary d, Categories cat,INetworkClient net)
        {
            this.networkClient = net;
            this.model =  d;

            Items = new ObservableCollection<EntryViewModel>();
            foreach(Entry e in model.Entries)
            {
                Items.Add(new EntryViewModel(e));
            }

            Categories = new ObservableCollection<CategoryViewModel>();
            foreach (Category c in cat.ListCategories)
            {
                Categories.Add(new CategoryViewModel(c));
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
            Entry e = new Entry();
            e.IDDiary = this.Model.Id;
            this.model.Add(e);

            // Modification Vue
            EntryViewModel entryVM = new EntryViewModel(e);
            this.Items.Add(entryVM);
            this.CurrentEntry = entryVM;

        }

        /// <summary>
        /// Sauvegarde une entrée
        /// </summary>
        public void SaveEntry()
        {
            networkClient.AddEntry(this.CurrentEntry.Entry);
            this.CurrentEntry = null;
        }
    }
}
