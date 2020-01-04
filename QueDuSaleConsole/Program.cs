using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace QueDuSaleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*======================================================================== PARTIE AFFICHAGE +=======================================================================*/
            Data data = new Data();
            try
            {
                Console.WriteLine("DOWNLOAD DATA...");
                data = data._Json.CreateEquipes(data, data.Competitions[9].Saisons[0]);
                data = data._Json.CreateEquipes(data, data.Competitions[9].Saisons[1]);
                data = data._Json.CreateEquipes(data, data.Competitions[9].Saisons[2]);
            }
            catch { Console.WriteLine("Nombre d'appels API trop important, merci de relancer l'app et d'attendre 1 minute"); Console.Read(); Environment.Exit(0); }
            string choix = "";
            while (choix != "0")
            {
                Console.Clear();
                Console.WriteLine(" _____________________________");
                Console.WriteLine("|                             |");
                Console.WriteLine("|     QUEDUSALE PRONOSTICS    |");
                Console.WriteLine("|_____________________________|");
                Console.WriteLine("|                             |");
                Console.WriteLine("|        MENU PRINCIPAL       |");
                Console.WriteLine("|_____________________________|");
                Console.WriteLine("| - 0 : fermer app            |");
                Console.WriteLine("|_____________________________|");
                Console.WriteLine("| - 1 : afficher competitions |");
                Console.WriteLine("|_____________________________|");
                Console.WriteLine(" _____________________________");
                Console.WriteLine("|                             |");
                Console.WriteLine("|          LISTE CHOIX        |");
                Console.WriteLine("|_____________________________|");

                Console.Write("Votre choix : ");
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        AfficherCompetitions(data);
                        break;
                    default:
                        Console.WriteLine("Veuillez saisir une information valide");
                        break;
                }
            }
        }

        #region
        /**
         * <summary> Fonction qui affiche les compétitions </summary>
         */
        static string AfficherCompetitions(Data data)
        {
            Console.Clear();
            string choix = "";
            int comp = 0;
            int sais = 0;
            Console.WriteLine("\n La liste des compétitions :");
            for (int c = 0; c < data.Competitions.Count(); c++)
            {
                Console.WriteLine("\n " + c + " - " + data.Competitions[c].Nom + " - " + data.Competitions[c].UnPays.Nom);
                for (int s = 0; s < data.Competitions[c].Saisons.Count(); s++) Console.Write(" | " + s + ":" + data.Competitions[c].Saisons[s].Debut.Year + "/" + data.Competitions[c].Saisons[s].Fin.Year);
                Console.WriteLine(" |");
            }
            Console.Write("\nChoisir compétition voulu : ");
            choix = Console.ReadLine();
            comp = Convert.ToInt32(choix);
            System.Threading.Thread.Sleep(500);
            Console.Write("Choisir saison voulu : ");
            choix = Console.ReadLine();
            sais = Convert.ToInt32(choix);
            try { choix = AfficherSaison(data, comp, sais); }
            catch { AfficherCompetitions(data); }
            return choix;
        }

        /**
         * <summary> Fonction qui affiche la saison </summary>
         */
        static string AfficherSaison(Data data, int c, int s)
        {
            Console.Clear();
            try
            {
                if (data.Competitions[c].Saisons[s].Equipes.Count() == 0)
                {
                    Console.WriteLine("DOWNLOAD DATA...");
                    data = data._Json.CreateEquipes(data, data.Competitions[c].Saisons[s]);
                    data = data._Json.CreateMatchs(data, data.Competitions[c].Saisons[s]);
                    Console.Clear();
                }
            }
            catch { Console.WriteLine("Nombre d'appels API trop important, merci de relancer l'app et d'attendre 1 minute"); Console.Read(); Environment.Exit(0); }
            string choix = "";
            int nb_c = data.Competitions[c].Nom.Count() + 12;
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|");
            Console.Write(" ");
            for (int i = 0; i < nb_c; i++) Console.Write("_");
            Console.Write("\n|");
            for (int i = 0; i < nb_c; i++) Console.Write(" ");
            Console.WriteLine("|");
            Console.WriteLine("| " + data.Competitions[c].Nom + " " + data.Competitions[c].Saisons[s].Debut.Year + "/" + data.Competitions[c].Saisons[s].Fin.Year + " |");
            Console.Write("|");
            for (int i = 0; i < nb_c; i++) Console.Write("_");
            Console.WriteLine("|");
            Console.WriteLine("Nombre équipes : " + data.Competitions[c].Saisons[s].Equipes.Count());
            Console.WriteLine(" ________________________");
            Console.WriteLine("|                        |");
            Console.WriteLine("|       MENU SAISON      |");
            Console.WriteLine("|________________________|");
            Console.WriteLine("| - 0 : fermer app       |");
            Console.WriteLine("| - 1 : retour / menu    |");
            Console.WriteLine("|________________________|");
            Console.WriteLine("| - 2 : afficher equipes |");
            Console.WriteLine("| - 3 : afficher matchs  |");
            Console.WriteLine("|________________________|");
            Console.Write("Votre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AfficherCompetitions(data);
                    break;
                case "2":
                    AfficherEquipes(data, c, s);
                    break;
                case "3":
                    AfficherMatchs(data, c, s);
                    break;
                default:
                    Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;
        }

        /**
         * <summary> Fonction qui affiche les équipes d'une saison </summary>
         */
        static string AfficherEquipes(Data data, int c, int s)
        {
            Console.Clear();
            string choix = "";
            int nb_c = data.Competitions[c].Nom.Count() + 12;
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|");
            Console.Write(" ");
            for (int i = 0; i < nb_c; i++) Console.Write("_");
            Console.Write("\n|");
            for (int i = 0; i < nb_c; i++) Console.Write(" ");
            Console.WriteLine("|");
            Console.WriteLine("| " + data.Competitions[c].Nom + " " + data.Competitions[c].Saisons[s].Debut.Year + "/" + data.Competitions[c].Saisons[s].Fin.Year + " |");
            Console.Write("|");
            for (int i = 0; i < nb_c; i++) Console.Write("_");
            Console.WriteLine("|");
            Console.WriteLine(" ____________________________");
            Console.WriteLine("|                            |");
            Console.WriteLine("|        MENU EQUIPES        |");
            Console.WriteLine("|____________________________|");
            Console.WriteLine("| - 0 : fermer app           |");
            Console.WriteLine("| - 1 : retour sur la saison |");
            Console.WriteLine("| - 2 : menu principal       |");
            Console.WriteLine("|____________________________|");
            for (int e = 3; e < data.Competitions[c].Saisons[s].Equipes.Count() + 3; e++) Console.WriteLine(" " + e + " - " + data.Competitions[c].Saisons[s].Equipes[e - 3].Nom);
            Console.Write("\nVotre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AfficherSaison(data, c, s);
                    break;
                case "2":
                    AfficherCompetitions(data);
                    break;
                default:
                    try { AfficherEquipe(choix, data, c, s); }
                    catch { AfficherEquipes(data, c, s); }
                    break;
            }
            return choix;
        }

        /**
        * <summary> Fonction qui affiche une équipe </summary>
        */
        static string AfficherEquipe(string choix, Data data, int c, int s)
        {
            Console.Clear();
            int e = Convert.ToInt32(choix) - 3;
            data = data._Json.CreateMatchs(data, data.Competitions[c].Saisons[s], data.Competitions[c].Saisons[s].Equipes[e]);
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|\n");
            Console.WriteLine(" Vous avez selectionné l'équipe suivante : " + data.Competitions[c].Saisons[s].Equipes[e].Nom);
            Console.WriteLine(" ________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|          MENU EQUIPES         |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("| - 0 : fermer app              |");
            Console.WriteLine("| - 1 : retour aux equipes      |");
            Console.WriteLine("| - 2 : menu principal          |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine(" Logo : " + data.Competitions[c].Saisons[s].Equipes[e].Logo);
            Console.WriteLine(" Nom du stade : " + data.Competitions[c].Saisons[s].Equipes[e].Stade);
            Console.WriteLine(" Matchs finis : ");
            List<Match> matchs = new List<Match>();
            for (int m = 0; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count(); m++)
            {
                matchs.Add(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m]);
            }
            IEnumerable<Match> ms = matchs.OrderBy(x => x.DateEtHeure);
            data.Competitions[c].Saisons[s].Equipes[e].Matchs = ms.ToList();
            int i = 3;
            foreach (Match m in ms)
            {
                Equipe e1 = data.Equipes.Where(x => x.Id == m.IdEquipes[0]).ToList()[0];
                Equipe e2 = data.Equipes.Where(x => x.Id == m.IdEquipes[1]).ToList()[0];

                if (m.DateEtHeure < DateTime.Today)
                {
                    Console.WriteLine(" " + i + " - " + m.DateEtHeure.ToShortDateString() + " : " + e1.Nom + " - " + e2.Nom + " (" + m.ScoreFT[0] + "|" + m.ScoreFT[1] + ")");
                    i++;
                }
            }
            Console.WriteLine("\n Matchs en prevision : ");
            foreach (Match m in ms)
            {
                Equipe e1 = data.Equipes.Where(x => x.Id == m.IdEquipes[0]).ToList()[0];
                Equipe e2 = data.Equipes.Where(x => x.Id == m.IdEquipes[1]).ToList()[0];
                if (m.DateEtHeure > DateTime.Today)
                {
                    Console.WriteLine(" " + i + " - " + m.DateEtHeure.ToShortDateString() + " : " + e1.Nom + " - " + e2.Nom);
                    i++;
                }
            }
            Console.Write("\n Votre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AfficherEquipes(data, c, s);
                    break;
                case "2":
                    AfficherCompetitions(data);
                    break;
                default:
                    try { AfficherMatch(choix, data, c, s, data.Competitions[c].Saisons[s].Equipes[e].Matchs[Convert.ToInt32(choix) - 3]); }
                    catch { AfficherEquipe(Convert.ToString(e + 3), data, c, s); }
                    break;
            }
            return choix;
        }

        /**
         * <summary> Fonction qui affiche les matchs d'une saison </summary>
         */
        static string AfficherMatchs(Data data, int c, int s)
        {
            Console.Clear();
            string choix = "";
            int nb_c = data.Competitions[c].Nom.Count() + 12;
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|");
            Console.Write(" ");
            for (int i = 0; i < nb_c; i++) Console.Write("_");
            Console.Write("\n|");
            for (int i = 0; i < nb_c; i++) Console.Write(" ");
            Console.WriteLine("|");
            Console.WriteLine("| " + data.Competitions[c].Nom + " " + data.Competitions[c].Saisons[s].Debut.Year + "/" + data.Competitions[c].Saisons[s].Fin.Year + " |");
            Console.Write("|");
            for (int i = 0; i < nb_c; i++) Console.Write("_");
            Console.WriteLine("|");
            Console.WriteLine(" ____________________________");
            Console.WriteLine("|                            |");
            Console.WriteLine("|         MENU MATCHS        |");
            Console.WriteLine("|____________________________|");
            Console.WriteLine("| - 0 : fermer app           |");
            Console.WriteLine("| - 1 : retour sur la saison |");
            Console.WriteLine("| - 2 : menu principal       |");
            Console.WriteLine("|____________________________|");
            List<Match> matchs = new List<Match>();
            for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count(); e++)
            {
                for (int m = 0; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count(); m++)
                {
                    if (!matchs.Contains(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m])) matchs.Add(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m]);
                }
            }
            int j = 3;
            IEnumerable<Match> ms = matchs.OrderBy(x => x.DateEtHeure);
            matchs = ms.ToList();
            foreach (Match m in ms)
            {
                Equipe e1 = data.Competitions[c].Saisons[s].Equipes.Where(x => x.Id == m.IdEquipes[0]).ToList()[0];
                Equipe e2 = data.Competitions[c].Saisons[s].Equipes.Where(x => x.Id == m.IdEquipes[1]).ToList()[0];
                Console.Write(" " + j + " - ");
                if (m.DateEtHeure > DateTime.Today) Console.WriteLine(m.DateEtHeure.ToShortDateString() + " : " + e1.Nom + " - " + e2.Nom + " (en prevision)");
                else Console.WriteLine(m.DateEtHeure.ToShortDateString() + " : " + e1.Nom + " - " + e2.Nom + " (" + m.ScoreFT[0] + "|" + m.ScoreFT[1] + ")");
                j++;
            }
            Console.Write("\nVotre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AfficherSaison(data, c, s);
                    break;
                case "2":
                    AfficherCompetitions(data);
                    break;
                default:
                    try { AfficherMatch(data, c, s, matchs[Convert.ToInt32(choix) - 3]); }
                    catch { AfficherMatchs(data, c, s); }
                    break;
            }
            return choix;
        }

        /**
        * <summary> Fonction qui affiche un match selon la liste des matchs </summary>
        */
        static string AfficherMatch(string choix, Data data, int c, int s, Match m)
        {
            Console.Clear();
            Equipe e1 = data.Equipes.Where(x => x.Id == m.IdEquipes[0]).ToList()[0];
            Equipe e2 = data.Equipes.Where(x => x.Id == m.IdEquipes[1]).ToList()[0];
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|\n");
            Console.WriteLine(" ________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|          MENU MATCH           |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("| - 0 : fermer app              |");
            Console.WriteLine("| - 1 : retour sur l'equipe     |");
            Console.WriteLine("| - 2 : menu principal          |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("\n | " + m.DateEtHeure.ToShortDateString() + " |");
            Console.WriteLine(" | J" + m.Journee + " |");
            Console.WriteLine(" " + e1.Nom + " - " + e2.Nom);
            if (m.DateEtHeure < DateTime.Today) Console.WriteLine(" " + m.ScoreFT[0] + "(" + m.ScoreMT[0] + ")" + " - " + m.ScoreFT[1] + "(" + m.ScoreMT[1] + ")");

            List<List<List<int>>> Buts = RecuperationsButs(data, c, s, m);
            Console.WriteLine("Nombre de buts marqué au total à domicile, mi-temps : " + Buts[0][0][0]);
            Console.WriteLine("Nombre de buts marqué au total à domicile, fin de match : " + Buts[0][0][1]);
            Console.WriteLine("Nombre de buts marqué au total à l'extérieur, mi-temps : " + Buts[0][1][0]);
            Console.WriteLine("Nombre de buts marqué au total à l'extérieur, fin de match : " + Buts[0][1][1]);

            Console.Write("\n Votre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AfficherEquipe(choix, data, c, s);
                    break;
                case "2":
                    AfficherCompetitions(data);
                    break;
                default:
                    Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;
        }

        /**
        * <summary> Fonction qui affiche un match selon une équipe </summary>
        */
        static string AfficherMatch(Data data, int c, int s, Match match)
        {
            Console.Clear();
            Equipe e1 = data.Equipes.Where(x => x.Id == match.IdEquipes[0]).ToList()[0];
            Equipe e2 = data.Equipes.Where(x => x.Id == match.IdEquipes[1]).ToList()[0];
            string choix = "";
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|\n");
            Console.WriteLine(" ________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|          MENU MATCH           |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("| - 0 : fermer app              |");
            Console.WriteLine("| - 1 : retour aux matchs       |");
            Console.WriteLine("| - 2 : menu principal          |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("\n | " + match.DateEtHeure.ToShortDateString() + " |");
            Console.WriteLine(" | J" + match.Journee + " |");
            Console.WriteLine(" " + e1.Nom + " - " + e2.Nom);
            if (match.DateEtHeure < DateTime.Today) Console.WriteLine(" " + match.ScoreFT[0] + "(" + match.ScoreMT[0] + ")" + " - " + match.ScoreFT[1] + "(" + match.ScoreMT[1] + ")");

            List<List<List<int>>> Buts = RecuperationsButs(data, c, s, match);
            Console.WriteLine("Nombre de buts marqué au total à domicile, mi-temps : " + Buts[0][0][0]);
            Console.WriteLine("Nombre de buts marqué au total à domicile, fin de match : " + Buts[0][0][1]);
            Console.WriteLine("Nombre de buts marqué au total à l'extérieur, mi-temps : " + Buts[0][1][0]);
            Console.WriteLine("Nombre de buts marqué au total à l'extérieur, fin de match : " + Buts[0][1][1]);

            Console.Write("\n Votre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AfficherMatchs(data, c, s);
                    break;
                case "2":
                    AfficherCompetitions(data);
                    break;
                default:
                    Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;
        }

        /*============================================================================ PARTIE CALCUL ============================================================================*/

        /**
        * <summary> Fonction qui récupère les nombres de buts de la saison </summary>
        **/
        static List<List<List<int>>> RecuperationsButs(Data data, int c, int s, Match match)
        {
            List<List<List<int>>> Buts = new List<List<List<int>>>
            {
                new List<List<int>>
                {
                    new List<int>{0, 0},
                    new List<int>{0, 0},
                },
            };
            for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count(); e++)
            {
                for (int m = 0; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count(); m++)
                {
                    {
                        Buts[0][0][0] = Buts[0][0][0] + data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].ScoreMT[0]; // Nombre de buts marqué au total à domicile, mi-temps
                        Buts[0][0][1] = Buts[0][0][1] + data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].ScoreFT[0]; // Nombre de buts marqué au total à domicile, fin de match
                        Buts[0][1][0] = Buts[0][1][0] + data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].ScoreMT[1]; // Nombre de buts marqué au total à l'extérieur, mi-temps
                        Buts[0][1][1] = Buts[0][1][1] + data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].ScoreFT[1]; // Nombre de buts marqué au total à l'extérieur, fin de match
                    }
                }
            }
            return Buts;
        }

        /* 
          int MoyenneButMarqueEquipeDomicile, MoyenneButMarqueEquipeExterieure
          LoiPoisson = (MoyenneButMarqueEquipeDomicile^ButSouhaite x Exp
         */
        

        #endregion
    }
}