using Client.ViewModels;
using LogicLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    public class NetworkClient : INetworkClient
    {
        public async void AddEntry(Entry newEntry)
        {
            // Configuration de l'endpoint
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7277/diaries");

            // Envoie de la requête
            await client.PostAsync("", new StringContent(JsonConvert.SerializeObject(newEntry)));
        }

        public async Task<Diary> GetDiary(User user)
        {
            Diary d = null;

            // Configuration de l'endpoint
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7277/diaries");

            // Envoie de la requête
            HttpResponseMessage response = await client.GetAsync($"/{user.Id}");

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
            client.BaseAddress = new Uri("https://localhost:7277/diaries");

            // Envoie de la requête
            HttpResponseMessage response = await client.GetAsync($"/categories");

            // Lecture de la réponse
            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync();

                c = JsonConvert.DeserializeObject<Categories>(content);
            }

            return c;
        }
    }
}
