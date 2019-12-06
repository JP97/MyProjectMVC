using MyProjectMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyProjectMVC.Utilities
{
    public class ApiHelper
    {
        public string GetRequest { get; set; } = "https://localhost:44342/api/teams";
        public string Post { get; set; } = "https://localhost:44342/api/teams";

        public List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            string json = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetRequest);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                json = reader.ReadToEnd();
            }

            teams = JsonConvert.DeserializeObject<List<Team>>(json);
            return teams;
        }

        public string PostTeamData(Team team)
        {
            //laver det opject du vil poste til en json fil som er en string
            string payLoad = JsonConvert.SerializeObject(team);
            //URI som er linket til api
            Uri uri = new Uri(Post);

            //laver et httpcontext som indeholder dit payload, måden den skal encode det og media type.
            HttpContent content = new StringContent(payLoad, System.Text.Encoding.UTF8, "application/json");

            //kald af metoden der poster som får både uri og content som parameter og 
            //som får statuscode tilbage som string
            var response = UpLoadUserDataPost(uri, content);

            return response.ToString();
        }

        private async Task<string> UpLoadUserDataPost(Uri uri, HttpContent content)
        {
            string response = string.Empty;

            using (HttpClient c = new HttpClient())
            {
                HttpResponseMessage result = await c.PostAsync(uri, content);

                //check if statuscode is successfull, hvis ja bliver det gemt i response
                //hvis ikke er den bare tom, kan så tjekkes i controlleren med et try catch
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }

            return response;
        }
    }
}
