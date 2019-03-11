using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_API.Classes
{
    class Connection
    {
        /// <summary>
        /// Faz a conexão com a API.
        /// </summary>
        /// <param name="title">Nome do Anime a ser pesquisado</param>
        /// <returns></returns>
        public static async Task Api(string title)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://kitsu.io/api/edge/anime/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));

                    Anime anime = new Anime();

                    HttpResponseMessage response = await client.GetAsync("?page[limit]=1&filter[text]=" + title);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;

                        var result = JsonConvert.DeserializeObject<Data>(json).data;

                        foreach (var dictionary in result)
                        {
                            foreach (var obj in dictionary){
                                switch (obj.Key)
                                {
                                    case "id":
                                        anime.id = obj.Value.ToString();
                                        break;
                                    case "type":
                                        anime.type = obj.Value.ToString();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        Console.WriteLine("ID: " + anime.id);
                        Console.WriteLine("Type: " + anime.type);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
