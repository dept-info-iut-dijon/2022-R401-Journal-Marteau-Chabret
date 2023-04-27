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

        }

        public async Task<Diary> GetDiary(User user)
        {
            Diary diary = new Diary(99, user as Student);
            Entry entry = new Entry();
            entry.IDDiary = diary.Id;
            entry.Description = "test du journal";
            entry.Date = DateTime.Today.AddDays(-1);
            entry.Title = "Titre 1";
            entry.Category = new Category(1, "Test", 12632256);
            diary.Add(entry);
            entry = new Entry();
            entry.IDDiary = diary.Id;
            entry.Description = "autre chose";
            entry.Date = DateTime.Today;
            entry.Title = "Titre 2";
            entry.Category = new Category(2, "Autre", 0x87CEEB);
            diary.Add(entry);
            return diary;
        }

        public async Task<Categories> ReadCategories()
        {
            Categories categories = new Categories();
            categories.Add(new Category(1, "Test", 12632256));
            categories.Add(new Category(2, "Autre", 0x87CEEB));
            return categories;
        }



        public async Task<Student> GetStudent(string login, string password)
        {
            Student resStudent = new Student();
            resStudent.Login = login;
            resStudent.Password = password;
            resStudent.Role = UserRoles.STUDENT;
            resStudent.Name = "Florian";
            return resStudent;

        }

    }
}
