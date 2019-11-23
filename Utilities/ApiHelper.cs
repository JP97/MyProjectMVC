using MyProjectMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyProjectMVC.Utilities
{
    public class ApiHelper
    {
        public string GetRequest { get; set; } = "https://localhost:44342/api/teams";

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
    }
}
