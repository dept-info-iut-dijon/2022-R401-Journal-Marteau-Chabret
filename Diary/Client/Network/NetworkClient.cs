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
        /// Représente l'url de base de l'API
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
            RestClient client = new RestClient();

            // Création requête
            RestRequest request = new RestRequest($"{user.Id}");

            // Envoie de la requête
            RestResponse response = await client.ExecuteAsync(request);

            // Lecture de la réponse
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseContent = response.Content;
                d = JsonConvert.DeserializeObject<Diary>(responseContent);
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

        public async Task<Student> GetStudent(string login,string password)
        {
            Student s = null;

            // Configuration de l'endpoint
            RestClient client = new RestClient("https://localhost:7277/diaries/");

            RestRequest request = new RestRequest("login", Method.Post);

            // Ajouter les paramètres à la requête
            request.AddParameter("login", login);
            request.AddParameter("password", password);

            // Envoie de la requête
            RestResponse response = await client.ExecuteAsync(request);


            // Lecture de la réponse
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseContent = response.Content;
                s = JsonConvert.DeserializeObject<Student>(responseContent);
            }

            return s;
        }
    }
}
