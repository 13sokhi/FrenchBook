using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace FrenchBookApp
{
    internal class Translator
    {
        static readonly HttpClient client = new HttpClient(); // HttpClient instance is intended to be created only once and used all the time
        static string url = "http://127.0.0.1:5000/translate";

        public static async Task<string> Translate(string text, string sourceLanguage, string targetLanguage)
        {
            try
            {
                var requestObject = new
                {
                    q = text,
                    source = sourceLanguage,
                    target = targetLanguage
                }; // the object for the request body
                string contentJson = JsonSerializer.Serialize(requestObject); // request object transformed into JSON string

                HttpContent httpContent = new StringContent(contentJson, Encoding.UTF8, "application/json"); // PostAsync method needs HttpContent as its 2nd parameter

                HttpResponseMessage response = await client.PostAsync(url, httpContent);

                var responseString = await response.Content.ReadAsStringAsync(); // responseString is string form of the returned JSON

                //  following is code to extract the actual translation as reponseJson is in format of : {"translatedText":"bienvenue"}
                using JsonDocument doc = JsonDocument.Parse(responseString);
                string translatedText = doc.RootElement.GetProperty("translatedText").GetString();
                return translatedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured!" + ex.Message);
                return "";
            }
        }
    }
}
