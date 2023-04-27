using Client.ViewModels;
using LogicLayer;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    public class NetworkClient : INetworkClient
    {

        /// <summary>
        /// Url de base
        /// </summary>
        private string baseUri = "https://localhost:7277/diaries/";

        public async void AddEntry(Entry newEntry)
        {
            // Configuration de l'endpoint
            HttpClient client = new HttpClient();

            // Envoie de la requête
            HttpResponseMessage response = await client.PostAsJsonAsync<Entry>("https://localhost:7277/diaries/AddEntry", newEntry);
            
        }

        public async Task<Diary> GetDiary(User user)
        {
            Diary d = null;

            // Configuration de l'endpoint
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7277/diaries/");

            // Envoie de la requête
            HttpResponseMessage response = await client.GetAsync($"{user.Id}");

            // Lecture de la réponse
            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync();

                d = JsonConvert.DeserializeObject<Diary>(content);
            }
            
            return d;
        }

        public async Task<Categories> ReadCategories()
        {
            Categories c = null;

            // Configuration de l'endpoint
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7277/diaries/");

            // Envoie de la requête
            HttpResponseMessage response = await client.GetAsync("categories");

            // Lecture de la réponse
            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync();

                c = JsonConvert.DeserializeObject<Categories>(content);
            }

            return c;
        }


        public async Task<Student> GetStudent(string login, string password)
        {

            Hash h = new Hash();

            User u = new User();
            u.Login = login;
            u.Name = "tets";
            u.Password = h.HashStringToSHA256(password);

            Student s = null;

            // Configuration de l'endpoint
            HttpClient client = new HttpClient();

            // Envoie de la requête
            HttpResponseMessage response = await client.PostAsJsonAsync<User>("https://localhost:7277/diaries/login", u);

            // Lecture de la réponse
            if ( response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync();

                s = JsonConvert.DeserializeObject<Student>(content);
            }

            // Vérification de la réponse
            if (s == null)
            {
                throw new Exception("Bad login or mdp");
            }
            if (s.Role != UserRoles.STUDENT)
            {
                throw new Exception("That's not a student");
            }

            return s;
        }
    }
}
