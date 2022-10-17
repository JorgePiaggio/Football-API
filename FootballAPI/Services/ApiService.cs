using FootballAPI.Data;
using FootballAPI.Models;
using FootballAPI.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FootballAPI.Services
{
    public class ApiService
    {
        private static string url = "http://api.football-data.org/v4/";
        private static string token = "";
        private HttpClient client;
        private FootballDbContext db = new FootballDbContext();

        public ApiService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Competition> FetchCompetitions()
        {
            CompetitionResponse competitions;
            var response = client.GetAsync(url + "competitions?areas=2072").Result;
            response.EnsureSuccessStatusCode();
            competitions = response.Content.ReadAsAsync<CompetitionResponse>().Result;

            return competitions.Competitions.ToList();
        }

        public List<Team> FetchTeams()
        {
            TeamResponse teams;
            var competition = db.Competitions.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
            var fullUrl = url + "competitions/" + competition.Id + "/teams";
            var response = client.GetAsync(fullUrl).Result;
            response.EnsureSuccessStatusCode();
            teams = response.Content.ReadAsAsync<TeamResponse>().Result;

            return teams.Teams.ToList();
        }

    }
}