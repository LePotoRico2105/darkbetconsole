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
        #region Variables
        List<string> tokens;
        #endregion

        #region Constructeur/Destructeur
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
         * Renvoi les données JSON sous format string de l'adresse fournie
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
                    catch{ }
                }

                return jsonObject;
            }
            catch (Exception e) { Console.WriteLine("\n" + e); Console.ReadKey(); return new Newtonsoft.Json.Linq.JObject(); }
        }

        /** 
         * Création d'une liste des compétitions
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
            Newtonsoft.Json.Linq.JObject objectSaison = GetJsonObject("https://api.football-data.org/v2/competitions/" + competition.Code);
            //Newtonsoft.Json.Linq.JObject objectMatchs = GetJsonObject("https://api.football-data.org/v2/competitions/" + competition.Code + "/matches?season=" + s);
            for (int i = 0; i < 3; i++)
            {
                saison = new Saison();
                saisons.Add(saison);
                saison.Id = Convert.ToInt32(objectSaison["seasons"][i]["id"]);
                saison.IdCompetition = competition.Id;
                saison.Debut = Convert.ToDateTime(objectSaison["seasons"][i]["startDate"]);
                saison.Fin = Convert.ToDateTime(objectSaison["seasons"][i]["endDate"]);
                saison.Gagnant = objectSaison["seasons"][i]["winner"].ToString();
                //CreateEquipes(data, objectEquipes, saison);
                //saison.Matchs = CreateMatchs(data, objectMatchs, saison);
                saisons[saisons.Count()-1] = saison;
            }


            return saisons;
        }

        /** 
         * <summary> Création d'une liste d'équipes pour une compétition </summary>
         * <returns> Retourne la liste des équipes dans une compétition </returns>
         */
        public void CreateEquipes(Data data, Newtonsoft.Json.Linq.JObject objectEquipes, Saison saison)
        {
            Equipe equipe = new Equipe();
            for (int i = 0; i < Convert.ToInt32(objectEquipes["count"]); i++)
            {

                equipe = new Equipe();
                try {
                    equipe = data.Competitions.Where(x => x.Id == saison.IdCompetition).ToList()[0].Saisons.Where(x => x.Id == saison.Id).ToList()[0].Equipes.Where(x => x.Id == Convert.ToInt32(objectEquipes["teams"][i]["id"])).ToList()[0];
                }
                catch
                {
                    equipe.Id = Convert.ToInt32(objectEquipes["teams"][i]["id"]);
                    equipe.IdCompetition = saison.IdCompetition;
                    equipe.IdSaison = saison.Id;
                    byte[] bytes = Encoding.Default.GetBytes(objectEquipes["teams"][i]["name"].ToString());
                    equipe.Nom = Encoding.UTF8.GetString(bytes);
                    bytes = Encoding.Default.GetBytes(objectEquipes["teams"][i]["shortName"].ToString());
                    equipe.NomCourt = Encoding.UTF8.GetString(bytes);
                    equipe.Initiale = objectEquipes["teams"][i]["tla"].ToString();
                    equipe.Logo = objectEquipes["teams"][i]["crestUrl"].ToString();
                    bytes = Encoding.Default.GetBytes(objectEquipes["teams"][i]["venue"].ToString());
                    equipe.Stade = Encoding.UTF8.GetString(bytes);
                    equipe.Maj = Convert.ToDateTime(objectEquipes["teams"][i]["lastUpdated"]);
                    Console.WriteLine(data.Competitions.Where(x => x.Id == saison.IdCompetition).ToList()[0]);
                    //.Saisons.Where(x => x.Id == saison.Id).ToList()[0].Equipes.Add(equipe);
                }
            }
        }
        
        /** 
         * <summary> Création d'une liste de matchs pour une compétition </summary>
         * <returns> Retourne la liste des matchs dans une compétition </returns>
         */
       /* public List<Match> CreateMatchs(Data data, Newtonsoft.Json.Linq.JObject objectMatchs, Saison saison)
        {
            List<Match> matchs = new List<Match>();
            Match match = new Match();
            for (int i = 0; i < Convert.ToInt32(objectMatchs["count"]); i++)
            {
                try
                {
                    match = new Match();
                    match.Id = Convert.ToInt32(objectMatchs["matches"][i]["id"]);
                    match.LaSaison = saison;
                    match.Journee = Convert.ToInt32(objectMatchs["matches"][i]["matchday"]);
                    match.Maj = Convert.ToDateTime(objectMatchs["matches"][i]["lastUpdated"]);
                    int scoreFTh = 0;
                    int scoreFTa = 0;
                    int scoreMTh = 0;
                    int scoreMTa = 0;
                    int scoreETh = 0;
                    int scoreETa = 0;
                    int scorePh = 0;
                    int scorePa = 0;
                    try { scoreFTh = Convert.ToInt32(objectMatchs["matches"][i]["score"]["fullTime"]["homeTeam"]); } catch { scoreFTh = 0; }
                    try { scoreFTa = Convert.ToInt32(objectMatchs["matches"][i]["score"]["fullTime"]["awayTeam"]); } catch { scoreFTa = 0; }
                    try { scoreMTh = Convert.ToInt32(objectMatchs["matches"][i]["score"]["halfTime"]["homeTeam"]); } catch { scoreMTh = 0; }
                    try { scoreMTa = Convert.ToInt32(objectMatchs["matches"][i]["score"]["halfTime"]["awayTeam"]); } catch { scoreMTa = 0; }
                    try { scoreETh = Convert.ToInt32(objectMatchs["matches"][i]["score"]["extraTime"]["homeTeam"]); } catch { scoreETh = 0; }
                    try { scoreETa = Convert.ToInt32(objectMatchs["matches"][i]["score"]["extraTime"]["awayTeam"]); } catch { scoreETa = 0; }
                    try { scorePh = Convert.ToInt32(objectMatchs["matches"][i]["score"]["penalties"]["homeTeam"]); } catch { scorePh = 0; }
                    try { scorePa = Convert.ToInt32(objectMatchs["matches"][i]["score"]["penalties"]["awayTeam"]); } catch { scorePa = 0; }
                    match.ScoreFT.Add(scoreFTh);
                    match.ScoreFT.Add(scoreFTa);
                    match.ScoreMT.Add(scoreMTh);
                    match.ScoreMT.Add(scoreMTa);
                    match.ScoreProlongation.Add(scoreETh);
                    match.ScoreProlongation.Add(scoreETa);
                    match.ScorePenalty.Add(scorePh);
                    match.ScorePenalty.Add(scorePa);

                    for (int s = 0; s < data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Count(); s++)
                    {
                        try
                        {
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][0] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][0] + match.ScoreMT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][1] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][1] + match.ScoreFT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][2] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][2] + match.ScoreProlongation[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][3] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][3] + match.ScorePenalty[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][0] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][0] + match.ScoreMT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][1] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][1] + match.ScoreFT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][2] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][2] + match.ScoreProlongation[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][3] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][3] + match.ScorePenalty[0];


                        }
                        catch
                        {
                            
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][0] = match.ScoreMT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][1] = match.ScoreFT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][2] = match.ScoreProlongation[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].ButsSaisons[s][0][3] = match.ScorePenalty[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][0] = match.ScoreMT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][1] = match.ScoreFT[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][2] = match.ScoreProlongation[0];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][0][3] = match.ScorePenalty[0];
                        }
                    }

                    for (int s = 0; s < data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].Saisons.Count(); s++)
                    {
                        try
                        {
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][0] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][0] + match.ScoreMT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][1] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][1] + match.ScoreFT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][2] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][2] + match.ScoreProlongation[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][3] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][3] + match.ScorePenalty[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][0] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][0] + match.ScoreMT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][1] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][1] + match.ScoreFT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][2] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][2] + match.ScoreProlongation[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][3] = data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][3] + match.ScorePenalty[1];
                        }
                        catch
                        {
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][0] = match.ScoreMT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][1] = match.ScoreFT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][2] = match.ScoreProlongation[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0].ButsSaisons[s][1][3] = match.ScorePenalty[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][0] = match.ScoreMT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][1] = match.ScoreFT[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][2] = match.ScoreProlongation[1];
                            data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0].Saisons.Where(x => x.Id == Convert.ToInt32(saison.Id)).ToList()[0].ButsSaisons[s][1][3] = match.ScorePenalty[1];
                        }
                    }
                    match.Equipes.Add(data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["homeTeam"]["id"])).ToList()[0]);
                    match.Equipes.Add(data.Equipes.Where(x => x.Id == Convert.ToInt32(objectMatchs["matches"][i]["awayTeam"]["id"])).ToList()[0]);
                    matchs.Add(match);
                }catch{ }
            }
            return matchs;
        }*/
        #endregion
    }
}