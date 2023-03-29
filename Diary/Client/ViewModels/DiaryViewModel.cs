using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class DiaryViewModel : BaseVM
    {
        #region Association
        private EntryViewModel current;
        private Diary model;
        private List<EntryViewModel> items;
        private List<CategoryViewModel> categories;
        private User userConnectd;
        private INetworkClient network;

        /// <summary>
        /// Liste d'items
        /// </summary>
        public List<EntryViewModel> Items
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
        #endregion

        /// <summary>
        /// Constructeur naturelle
        /// </summary>
        /// <param name="user"> Utilisateur qui se connecte </param>
        /// <param name="network"> Network </param>
        public DiaryViewModel(User user, INetworkClient network)
        {
            this.userConnectd = user;
            this.network = network;
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
