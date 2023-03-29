using Client.ViewModels;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    /// <summary>
    /// Fake Network qui implémente INetworkClient
    /// </summary>
    public class FakeNetwork : INetworkClient
    {
        public void AddEntry(Entry newEntry)
        {
            throw new NotImplementedException();
        }

        public async Task<Diary> GetDiary(User user)
        {
            Diary diary = new Diary(99, user as Student);
            Entry entry = new Entry();
            entry.IDiary = diary.Id;
            entry.Description = "test du journal";
            entry.Date = DateTime.Today.AddDays(-1);
            entry.Title = "Titre 1";
            entry.Category = new Category("Test", 12632256);
            diary.Add(entry);
            entry = new Entry();
            entry.IDiary = diary.Id;
            entry.Description = "autre chose";
            entry.Date = DateTime.Today;
            entry.Title = "Titre 2";
            entry.Category = new Category("Autre", 0x87CEEB);
            diary.Add(entry);
            return diary;
        }

        public Task<Categories> ReadCategories()
        {
            throw new NotImplementedException();
        }
    }
}
