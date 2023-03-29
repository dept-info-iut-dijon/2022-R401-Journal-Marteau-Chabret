using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public interface INetworkClientcs
    {
        public Task<Diary> GetDiary(Student user);

        public Task<Categories> ReadCategories();

        public void AddEntry(Entry newEntry);
    }
}
