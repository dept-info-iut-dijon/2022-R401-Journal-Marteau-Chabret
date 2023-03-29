using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    /// <summary>
    /// INetwork client
    /// </summary>
    public interface INetworkClient
    {
        /// <summary>
        /// Récupère le journal
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<Diary> GetDiary(User user);

        /// <summary>
        /// Lis les catégories
        /// </summary>
        /// <returns> Liste de catégories </returns>
        public Task<Categories> ReadCategories();

        /// <summary>
        /// Ajoute une entrée
        /// </summary>
        /// <param name="newEntry"></param>
        public void AddEntry(Entry newEntry);
    }
}
