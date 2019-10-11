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

        #region
        /**
         * Constructeur de la classe Json
         */
        public Json()
        {
            tokens = new List<string>(); // initialisation d'une liste de Token
            // ici, on ajoute à la liste toutes les clés de l'API
            tokens.Add("832593ac26474ca08bf040526470f67a");
            tokens.Add("89f54cbe1d4a40afa128132bc25499de");
            tokens.Add("8eaad1b696ca4e5eafbcf2f447a500d7");
            tokens.Add("6e6e9b9dd4d6431e9977ca0ff448ed56");
        }

        /**
         * Destructeur de la classe Json
         */
        ~Json()
        {

        }
        #endregion

        #region Fonctions et Procédures
        /**
         * Renvoi les données JSON sous format string de l'adresse fourni
         */
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
                        catch { }
                    }
                }
                return jsonObject;
            }
            catch (Exception e) { Console.WriteLine("\n" + e); Console.ReadKey(); return new Newtonsoft.Json.Linq.JObject(); }
        }

        /** 
         * Création d'une liste des competitions
         * <returns> Retourne la liste des compétitions </returns>
         */
        public List<Competition> CreateCompetitions(Data data)
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
            competitions = competitions.OrderBy(x => x.Nom).ToList();
            return competitions;
        }

        /** 
         * <summary> Création d'une liste des competitions </summary>
         * <returns> Retourne la liste des compétitions </returns>
         */
        public List<Saison> CreateSaisons(Data data, Competition competition)
        {
            List<Saison> saisons = new List<Saison>();
            Saison saison = new Saison();
            for (int s = DateTime.Today.Year; s >= 2017; s--)
            {
                Newtonsoft.Json.Linq.JObject objectEquipes = GetJsonObject("https://api.football-data.org/v2/competitions/" + competition.Code + "/teams?saison=" + s);
                saison = new Saison();
                saison.Id = Convert.ToInt32(objectEquipes["season"]["id"]);
                saison.Debut = Convert.ToDateTime(objectEquipes["season"]["startDate"]);
                saison.Fin = Convert.ToDateTime(objectEquipes["season"]["endDate"]);
            }
            return saisons;
        }

        // Création d'une liste des équipe
        public List<Equipe> CreateEquipes(Data data, Newtonsoft.Json.Linq.JObject objectEquipes)
        {
            List<Equipe> equipes = new List<Equipe>();
            Equipe equipe = new Equipe();

            
            for (int i = 0; i < Convert.ToInt32(objectEquipes["count"]); i++)
            {
                equipe = new Equipe();
                equipe.Id = Convert.ToInt32(objectEquipes["teams"][i]["id"]);
                byte[] bytes = Encoding.Default.GetBytes(objectEquipes["teams"][i]["name"].ToString());
                equipe.Nom = Encoding.UTF8.GetString(bytes);
                bytes = Encoding.Default.GetBytes(objectEquipes["teams"][i]["shortName"].ToString());
                equipe.NomCourt = Encoding.UTF8.GetString(bytes);
                equipe.Initiale = objectEquipes["competitions"][i]["tla"].ToString();
                equipe.Logo = objectEquipes["competitions"][i]["crestUrl"].ToString();
                equipe.Stade = objectEquipes["competitions"][i]["venue"].ToString();
                equipe.Maj = Convert.ToDateTime(objectEquipes["competitions"][i]["lastUpdated"]);
                equipes.Add(equipe);
            }
            equipes = equipes.OrderBy(x => x.Nom).ToList();
            return equipes;
        }
        #endregion
    }
}