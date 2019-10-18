using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            tokens.Add("796d1f39632c48afa396273a061faadc");
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
                for (int i = 0; i < this.tokens.Count(); i++)
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.Headers.Add("X-Auth-Token", tokens[i]);
                            jsonObject = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(wc.DownloadString(adresse));
                            i = tokens.Count();
                        }
                    }
                    catch{  }
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
                if (objectCompetitions["competitions"][i]["code"].ToString() != "EC" && objectCompetitions["competitions"][i]["code"].ToString() != "WC")
                {
                    competition = new Competition();
                    competition.Id = Convert.ToInt32(objectCompetitions["competitions"][i]["id"]);
                    competition.UnPays = new Pays(Convert.ToInt32(objectCompetitions["competitions"][i]["area"]["id"]), objectCompetitions["competitions"][i]["area"]["name"].ToString());
                    byte[] bytes = Encoding.Default.GetBytes(objectCompetitions["competitions"][i]["name"].ToString());
                    competition.Nom = Encoding.UTF8.GetString(bytes);
                    competition.Code = objectCompetitions["competitions"][i]["code"].ToString();
                    competition.NbSaisonsDisponible = Convert.ToInt32(objectCompetitions["competitions"][i]["numberOfAvailableSeasons"]);
                    competition.Maj = Convert.ToDateTime(objectCompetitions["competitions"][i]["lastUpdated"]);

                    competition.Saisons = CreateSaisons(data, competition);
                    competitions.Add(competition);
                }
            }
            competitions = competitions.OrderBy(x => x.Nom).ToList();
            return competitions;
        }

        /** 
         * <summary> Création d'une liste de saison pour une compétition donnée </summary>
         * <returns> Retourne la liste des saisons de la compétition en paramètre </returns>
         */
        public List<Saison> CreateSaisons(Data data, Competition competition)
        {
            List<Saison> saisons = new List<Saison>();
            Saison saison = new Saison();

            for (int s = DateTime.Today.Year; s >= 2017; s--)
            {

                Newtonsoft.Json.Linq.JObject objectEquipes = GetJsonObject("https://api.football-data.org/v2/competitions/" + competition.Code + "/teams?season=" + s);
                saison = new Saison();
                saison.Id = Convert.ToInt32(objectEquipes["season"]["id"]);
                saison.Debut = Convert.ToDateTime(objectEquipes["season"]["startDate"]);
                saison.Fin = Convert.ToDateTime(objectEquipes["season"]["endDate"]);
                saison.Gagnant = objectEquipes["season"]["winner"].ToString();
                saison.Equipes = CreateEquipes(data, objectEquipes);
                saisons.Add(saison);
            }
            
            return saisons;
        }

        /** 
         * <summary> Création d'une liste d'équipes pour une compétition </summary>
         * <returns> Retourne la liste des équipes dans une compétition </returns>
         */
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
                equipe.Initiale = objectEquipes["teams"][i]["tla"].ToString();
                equipe.Logo = objectEquipes["teams"][i]["crestUrl"].ToString();
                equipe.Stade = objectEquipes["teams"][i]["venue"].ToString();
                equipe.Maj = Convert.ToDateTime(objectEquipes["teams"][i]["lastUpdated"]);
                equipes.Add(equipe);
            }
            equipes = equipes.OrderBy(x => x.Nom).ToList();
            return equipes;
        }
        #endregion
    }
}