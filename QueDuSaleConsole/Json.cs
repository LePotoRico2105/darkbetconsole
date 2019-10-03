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

        Json()
        {
            tokens = new List<string>();
            tokens.Add("832593ac26474ca08bf040526470f67a");
            tokens.Add("89f54cbe1d4a40afa128132bc25499de");
            tokens.Add("8eaad1b696ca4e5eafbcf2f447a500d7");
            tokens.Add("6e6e9b9dd4d6431e9977ca0ff448ed56");
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
        protected void CreateCompetitions()
        {
            Competition competition = new Competition();
            Newtonsoft.Json.Linq.JObject objectCompetitions = this.GetJsonObject("https://api.football-data.org/v2/competitions?plan=TIER_ONE");
            for (int i = 0; i < Convert.ToInt32(objectCompetitions["count"]); i++)
            {
                competition.Id = Convert.ToInt32(objectCompetitions["id"]);
                

            }
        }
    }
}
