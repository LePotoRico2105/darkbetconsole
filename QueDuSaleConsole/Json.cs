using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Json
    {
        List<string> tokens;

        public Json()
        {
            tokens = new List<string>();
            tokens.Add("832593ac26474ca08bf040526470f67a");
            tokens.Add("89f54cbe1d4a40afa128132bc25499de");
            tokens.Add("8eaad1b696ca4e5eafbcf2f447a500d7");
            tokens.Add("6e6e9b9dd4d6431e9977ca0ff448ed56");
        }

        ~Json()
        {

        }

        // Renvoi les données JSON sous format string de l'adresse fourni
        protected Newtonsoft.Json.Linq.JObject GetJsonObject(string adresse)
        {
            try
            {
                Newtonsoft.Json.Linq.JObject jsonObject = new Newtonsoft.Json.Linq.JObject();

                using (var webClient = new System.Net.WebClient())
                {
                    for (int i = 0; i < this.tokens.Count(); i++)
                    { 
                        try
                        {
                            webClient.Headers.Add("X-Auth-Token", this.tokens[i]);
                            jsonObject = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(webClient.DownloadString(adresse));
                        }
                        catch{}
                    }
                }
                return jsonObject;
            }
            catch (Exception e){ Console.WriteLine("\n" + e); Console.ReadKey(); return new Newtonsoft.Json.Linq.JObject(); }
        }

        // Renvoi 
        public List<Competition> CreateCompetitions()
        {
            List<Competition> competitions = new List<Competition>();
            Competition competition = new Competition();
            Newtonsoft.Json.Linq.JObject objectCompetitions = GetJsonObject("https://api.football-data.org/v2/competitions?plan=TIER_ONE");
            for (int i = 0; i < Convert.ToInt32(objectCompetitions["count"]); i++)
            {
                competition = new Competition();
                competition.Id = Convert.ToInt32(objectCompetitions["competitions"][i]["id"]);
                competition.UnPays = new Pays(Convert.ToInt32(objectCompetitions["competitions"][i]["area"]["id"]), objectCompetitions["competitions"][i]["area"]["name"].ToString());
                competition.SaisonActuelle = new Saison(Convert.ToInt32(objectCompetitions["competitions"][i]["currentSeason"]["id"]), Convert.ToDateTime(objectCompetitions["competitions"][i]["currentSeason"]["startDate"]), Convert.ToDateTime(objectCompetitions["competitions"][i]["currentSeason"]["endDate"]));
                byte[] bytes = Encoding.Default.GetBytes(objectCompetitions["competitions"][i]["name"].ToString());
                competition.Nom = Encoding.UTF8.GetString(bytes);
                competition.Code = objectCompetitions["competitions"][i]["code"].ToString();
                competition.NbSaisonsDisponible = Convert.ToInt32(objectCompetitions["competitions"][i]["numberOfAvailableSeasons"]);
                competition.Maj = Convert.ToDateTime(objectCompetitions["competitions"][i]["lastUpdated"]);
                competitions.Add(competition);
            }
            return competitions;
        }
    }
}
