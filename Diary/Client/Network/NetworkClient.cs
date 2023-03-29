using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    public class NetworkClient : INetworkClientcs
    {
        public void AddEntry(Entry newEntry)
        {
            throw new NotImplementedException();
        }

        public Task<Diary> GetDiary(Student user)
        {
            throw new NotImplementedException();
        }

        public Task<Categories> ReadCategories()
        {
            throw new NotImplementedException();
        }
    }
}
