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
            Console.Clear();
            /*======================================================================== PARTIE AFFICHAGE +=======================================================================*/
            Data data = new Data();
            try
            {
                Console.WriteLine("DOWNLOAD DATA...");
                data = data._Json.CreateEquipes(data, data.Competitions[9].Saisons[0]);
                data = data._Json.CreateEquipes(data, data.Competitions[9].Saisons[1]);
            }
            catch { Console.WriteLine("Nombre d'appels API trop important, merci de relancer l'app et d'attendre 1 minute"); Console.Read(); Environment.Exit(0); }
            string choix = "";
            while (choix != "0")
            {
                Console.Clear();
                Console.WriteLine(" _____________________________________");
                Console.WriteLine("|                                     |");
                Console.WriteLine("|         QUEDUSALE PRONOSTICS        |");
                Console.WriteLine("|_____________________________________|");
                Console.WriteLine("|                                     |");
                Console.WriteLine("|            MENU PRINCIPAL           |");
                Console.WriteLine("|_____________________________________|");
                Console.WriteLine("| - 0 : fermer app                    |");
                Console.WriteLine("|_____________________________________|");
                Console.WriteLine("| - 1 : afficher competitions         |");
                Console.WriteLine("| - 2 : afficher meilleurs pronostics |");
                Console.WriteLine("|_____________________________________|");
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
                        AfficherMeilleursPronos(data, args);
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
                Console.WriteLine("DOWNLOAD DATA...");
                if (data.Competitions[c].Saisons[s].Equipes.Count() == 0)
                {
                        data = data._Json.CreateEquipes(data, data.Competitions[c].Saisons[s]);
                }
                data = data._Json.CreateMatchs(data, data.Competitions[c].Saisons[s]);
                Console.Clear();
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
                if (!matchs.Contains(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m])) matchs.Add(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m]);
            }
            IEnumerable<Match> ms = matchs.OrderBy(x => x.DateEtHeure);
            data.Competitions[c].Saisons[s].Equipes[e].Matchs = ms.ToList();
            int i = 3;
            foreach (Match m in ms)
            {
                if (m.DateEtHeure < DateTime.Today)
                {
                    Console.WriteLine(" " + i + " - " + m.DateEtHeure.ToShortDateString() + " : " + m.NomEquipes[0] + " - " + m.NomEquipes[1] + " (" + m.ScoreFT[0] + "|" + m.ScoreFT[1] + ")");
                    i++;
                }
            }
            Console.WriteLine("\n Matchs en prevision : ");
            foreach (Match m in ms)
            {
                if (m.DateEtHeure > DateTime.Today)
                {
                    Console.WriteLine(" " + i + " - " + m.DateEtHeure.ToShortDateString() + " : " + m.NomEquipes[0] + " - " + m.NomEquipes[1]);
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
                    try {  AfficherMatch(choix, data, c, s, data.Competitions[c].Saisons[s].Equipes[e].Matchs[Convert.ToInt32(choix) - 3], ChargerCotes(data, c, s, data.Competitions[c].Saisons[s].Equipes[e].Matchs[Convert.ToInt32(choix) - 3])); }
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
                    try { AfficherMatch(data, c, s, matchs[Convert.ToInt32(choix) - 3], ChargerCotes(data, c, s, matchs[Convert.ToInt32(choix) - 3])); }
                    catch { AfficherMatchs(data, c, s); }
                    break;
            }
            return choix;
        }

        /**
        * <summary> Fonction qui affiche un match selon la liste des matchs </summary>
        */
        static string AfficherMatch(string choix, Data data, int c, int s, Match match, List<List<double>> cotes)
        {
            Console.Clear();
            Equipe e1 = data.Equipes.Where(x => x.Id == match.IdEquipes[0]).ToList()[0];
            Equipe e2 = data.Equipes.Where(x => x.Id == match.IdEquipes[1]).ToList()[0];
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
            Console.WriteLine("\n | " + match.DateEtHeure.ToShortDateString() + " |");
            Console.WriteLine(" | J" + match.Journee + " |");
            Console.WriteLine(" " + e1.Nom + " - " + e2.Nom);
            if (match.DateEtHeure < DateTime.Today) Console.WriteLine(" " + match.ScoreFT[0] + "(" + match.ScoreMT[0] + ")" + " - " + match.ScoreFT[1] + "(" + match.ScoreMT[1] + ")");

            Double matchsSaisons = 0;
            Double matchsSaisonsE1 = 0;
            Double matchsSaisonsE2 = 0;
            for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count(); e++)
            {
                for (int m = 0; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count(); m++)
                {
                    if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].IdSaison == match.IdSaison)
                    {
                        if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].DateEtHeure < DateTime.Today)
                        {
                            matchsSaisons++;
                            if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].IdEquipes[0] == e1.Id) { matchsSaisonsE1++; }
                            if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].IdEquipes[1] == e2.Id) { matchsSaisonsE2++; }
                        }
                    }
                }
            }
            matchsSaisons = matchsSaisons / 2;
            matchsSaisonsE1 = matchsSaisonsE1 / 2;
            matchsSaisonsE2 = matchsSaisonsE2 / 2;
            List<List<List<List<int>>>> Buts = RecuperationButs(data, c, s, match);
            double ES1MT = ((Buts[1][0][0][0] / matchsSaisonsE1) / (Buts[0][0][0][0] / matchsSaisons)) * ((Buts[2][1][1][0] / matchsSaisonsE2) / (Buts[0][1][1][0] / matchsSaisons)) * (Buts[0][0][0][0] / matchsSaisons);
            double ES1FT = ((Buts[1][0][0][1] / matchsSaisonsE1) / (Buts[0][0][0][1] / matchsSaisons)) * ((Buts[2][1][1][1] / matchsSaisonsE2) / (Buts[0][1][1][1] / matchsSaisons)) * (Buts[0][0][0][1] / matchsSaisons);
            double ES2MT = ((Buts[2][0][1][0] / matchsSaisonsE2) / (Buts[0][0][1][0] / matchsSaisons)) * ((Buts[1][1][0][0] / matchsSaisonsE1) / (Buts[0][1][0][0] / matchsSaisons)) * (Buts[0][0][1][0] / matchsSaisons);
            double ES2FT = ((Buts[2][0][1][1] / matchsSaisonsE2) / (Buts[0][0][1][1] / matchsSaisons)) * ((Buts[1][1][0][1] / matchsSaisonsE1) / (Buts[0][1][0][1] / matchsSaisons)) * (Buts[0][0][1][1] / matchsSaisons);
            /*Console.WriteLine("\nNombre de buts marqué au total à domicile, mi-temps : " + Buts[0][0][0][0]);
            Console.WriteLine("Nombre de buts marqué au total à domicile, fin de match : " + Buts[0][0][0][1]);
            Console.WriteLine("Nombre de buts concédé au total à domicile, mi-temps : " + Buts[0][1][0][0]);
            Console.WriteLine("Nombre de buts concédé au total à domicile, fin de match : " + Buts[0][1][0][1]);
            Console.WriteLine("\nNombre de buts marqué au total à l'extérieur, mi-temps : " + Buts[0][0][1][0]);
            Console.WriteLine("Nombre de buts marqué au total à l'extérieur, fin de match : " + Buts[0][0][1][1]);
            Console.WriteLine("Nombre de buts concédé au total à l'extérieur, mi-temps : " + Buts[0][1][1][0]);
            Console.WriteLine("Nombre de buts concédé au total à l'extérieur, fin de match : " + Buts[0][1][1][1]);
            Console.WriteLine("\nNombre de buts marqué par l'équipe à domicile, mi-temps : " + Buts[1][0][0][0]);
            Console.WriteLine("Nombre de buts marqué par l'équipe à domicile, fin de match : " + Buts[1][0][0][1]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à domicile, mi-temps : " + Buts[1][1][0][0]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à domicile, fin de match : " + Buts[1][1][0][1]);
            Console.WriteLine("\nNombre de buts marqué par l'équipe à l'extérieur, mi-temps : " + Buts[2][0][1][0]);
            Console.WriteLine("Nombre de buts marqué par l'équipe à l'extérieur, fin de match : " + Buts[2][0][1][1]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à l'extérieur, mi-temps : " + Buts[2][1][1][0]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à l'extérieur, fin de match : " + Buts[2][1][1][1]);
            Console.WriteLine("\n\n -TOTAL- ");
            Console.WriteLine("Moyenne de but marqué à domicile, fin de match : " + Math.Round(Buts[0][0][0][1] / matchsSaisons, 2));
            Console.WriteLine("Moyenne de but concédé à domicile, fin de match : " + Math.Round(Buts[0][1][0][1] / matchsSaisons, 2));
            Console.WriteLine("Moyenne de but marqué à l'exterieur, fin de match : " + Math.Round(Buts[0][0][1][1] / matchsSaisons, 2));
            Console.WriteLine("Moyenne de but concédé à l'exterieur, fin de match : " + Math.Round(Buts[0][1][1][1] / matchsSaisons, 2));
            Console.WriteLine("\n\n -" + e1.Nom + "- ");
            Console.WriteLine("Force d'attaque à domicile, mi-temps : " + Math.Round((Buts[1][0][0][0] / matchsSaisonsE1) / (Buts[0][0][0][0] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à domicile, mi-temps : " + Math.Round((Buts[1][1][0][0] / matchsSaisonsE1) / (Buts[0][1][0][0] / matchsSaisons), 2));
            Console.WriteLine("Force d'attaque à domicile, fin de match : " + Math.Round((Buts[1][0][0][1] / matchsSaisonsE1) / (Buts[0][0][0][1] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à domicile, fin de match : " + Math.Round((Buts[1][1][0][1] / matchsSaisonsE1) / (Buts[0][1][0][1] / matchsSaisons), 2));
            Console.WriteLine("Espérance de but à domicile, mi-temps : " + Math.Round(ES1MT, 2));
            Console.WriteLine("Espérance de but à domicile, fin du match : " + Math.Round(ES1FT, 2));
            Console.WriteLine("\n\n -" + e2.Nom + "- ");
            Console.WriteLine("Force d'attaque à l'exterieur, mi-temps : " + Math.Round((Buts[2][0][1][0] / matchsSaisonsE2) / (Buts[0][0][1][0] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à l'exterieur, mi-temps : " + Math.Round((Buts[2][1][1][0] / matchsSaisonsE2) / (Buts[0][1][1][0] / matchsSaisons), 2));
            Console.WriteLine("Force d'attaque à l'exterieur, fin de match : " + Math.Round((Buts[2][0][1][1] / matchsSaisonsE2) / (Buts[0][0][1][1] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à l'exterieur, fin de match : " + Math.Round((Buts[2][1][1][1] / matchsSaisonsE2) / (Buts[0][1][1][1] / matchsSaisons), 2));
            Console.WriteLine("Espérance de but à l'extérieur, mi-temps : " + Math.Round(ES2MT, 2));
            Console.WriteLine("Espérance de but à l'extérieur, fin du match : " + Math.Round(ES2FT, 2));
            Console.WriteLine("Pourcentage de chance nombre de buts " + e1.Nom + ", mi-temps : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i)) * 100, 1) + "%");
            Console.WriteLine("\nPourcentage de chance nombre de buts " + e1.Nom + ", fin de match : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i)) * 100, 1) + "%");
            Console.WriteLine("\nPourcentage de chance nombre de buts " + e2.Nom + ", mi-temps : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i)) * 100, 1) + "%");
            Console.WriteLine("\nPourcentage de chance nombre de buts " + e2.Nom + ", fin du match : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i)) * 100, 1) + "%");*/


            double V1MT = 0;
            double NMT = 0;
            double V2MT = 0;
            double V1FT = 0;
            double NFT = 0;
            double V2FT = 0;
            double BTTSMT = 0;
            double BTTSFT = 0;
            double V1FTplus2 = 0;
            double V2FTplus2 = 0;
            double V1FTplus3 = 0;
            double V2FTplus3 = 0;
            double V1FTplus4 = 0;
            double V2FTplus4 = 0;
            double V1FTplus5 = 0;
            double V2FTplus5 = 0;
            double V1FTplus2E2 = 0;
            double V2FTplus2E1 = 0;
            double V1FTplus3E2 = 0;
            double V2FTplus3E1 = 0;
            double V1FTplus4E2 = 0;
            double V2FTplus4E1 = 0;
            double V1FTplus5E2 = 0;
            double V2FTplus5E1 = 0;
            double FTplus1 = 0;
            double FTplus2 = 0;
            double FTplus3 = 0;
            double FTplus4 = 0;
            double FTplus5 = 0;
            double FTplus6 = 0;
            double MTplus1 = 0;
            double MTplus2 = 0;
            double MTplus3 = 0;
            double scoreExactMT = 0;
            double scoreExactFT = 0;
            int scoreExactE1MT = 0;
            int scoreExactE2MT = 0;
            int scoreExactE1FT = 0;
            int scoreExactE2FT = 0;

            Console.WriteLine("\n_VICTOIRE_");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V1MT = (((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i))) * (((Math.Pow(ES2MT, j) * Math.Exp(-ES2MT)) / factorial(j))) * 100 + V1MT;
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V2MT = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + V2MT;
            NMT = 100 - V1MT - V2MT;
            Console.WriteLine("\tVainqueur mi-temps : " + Math.Round(V1MT, 1) + "|" + Math.Round(NMT, 1) + "|" + Math.Round(V2MT, 1));
            Console.WriteLine("\tVainqueur double chance mi-temps : " + (100 - Math.Round(V2MT, 1)) + "|" + (100 - Math.Round(NMT, 1)) + "|" + (100 - Math.Round(V1MT, 1)));

            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V1FT = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FT;
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V2FT = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FT;
            NFT = 100 - V1FT - V2FT;
            Console.WriteLine("\tVainqueur final : " + Math.Round(V1FT, 1) + "|" + Math.Round(NFT, 1) + "|" + Math.Round(V2FT, 1));
            Console.WriteLine("\tVainqueur double chance final : " + (100 - Math.Round(V2FT, 1)) + "|" + (100 - Math.Round(NFT, 1)) + "|" + (100 - Math.Round(V1FT, 1)));

            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i != 0 && j != 0) BTTSMT = (((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i))) * (((Math.Pow(ES2MT, j) * Math.Exp(-ES2MT)) / factorial(j))) * 100 + BTTSMT;
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i != 0 && j != 0) BTTSFT = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + BTTSFT;
            Console.WriteLine("\n _LES DEUX EQUIPES MARQUENT_");
            Console.WriteLine("\tBTTS mi-temps : OUI = " + Math.Round(BTTSMT, 1) + " | NON = " + Math.Round(100 - BTTSMT, 1));
            Console.WriteLine("\tBTTS fin de match : OUI = " + Math.Round(BTTSFT, 1) + " | NON = " + Math.Round(100 - BTTSFT, 1));

            Console.WriteLine("\n _VICTOIRE & NOMBRE DE BUTS FULL-TIME_");
            if (V1FT > V2FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 1.5)) V1FTplus2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 1.5 buts dans le match : " + Math.Round(V1FTplus2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 2.5)) V1FTplus3 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus3;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 2.5 buts dans le match : " + Math.Round(V1FTplus3, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 3.5)) V1FTplus4 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus4;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 3.5 buts dans le match : " + Math.Round(V1FTplus4, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 4.5)) V1FTplus5 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus5;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 4.5 buts dans le match : " + Math.Round(V1FTplus5, 1) + "%");
            }
            if (V2FT > V1FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 1.5)) V2FTplus2 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus2;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 1.5 buts dans le match : " + Math.Round(V2FTplus2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 2.5)) V2FTplus3 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus3;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 2.5 buts dans le match : " + Math.Round(V2FTplus3, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 3.5)) V2FTplus4 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus4;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 3.5 buts dans le match : " + Math.Round(V2FTplus4, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 4.5)) V2FTplus5 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus5;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 4.5 buts dans le match : " + Math.Round(V2FTplus5, 1) + "%");
            }

            Console.WriteLine("\n _VICTOIRE & NOMBRE DE BUTS D'ECART FIN DU MATCH_");
            if (V1FT > V2FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 1.5)) V1FTplus2E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus2E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 1 but ou plus dans le match : " + Math.Round(V1FTplus2E2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 2.5)) V1FTplus3E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus3E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 2 buts ou plus dans le match : " + Math.Round(V1FTplus3E2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 3.5)) V1FTplus4E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus4E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 3 buts ou plus dans le match : " + Math.Round(V1FTplus4E2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 4.5)) V1FTplus5E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus5E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 4 buts ou plus dans le match : " + Math.Round(V1FTplus5E2, 1) + "%");
            }
            if (V2FT > V1FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 1.5)) V2FTplus2E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus2E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 1 but ou plus dans le match : " + Math.Round(V2FTplus2E1, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 2.5)) V2FTplus3E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus3E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 2 buts ou plus dans le match : " + Math.Round(V2FTplus3E1, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 3.5)) V2FTplus4E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus4E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 3 buts ou plus dans le match : " + Math.Round(V2FTplus4E1, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 4.5)) V2FTplus5E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus5E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 4 buts ou plus dans le match : " + Math.Round(V2FTplus5E1, 1) + "%");
            }

            Console.WriteLine("\n _NOMBRE DE BUTS_");
            Console.WriteLine("\t _MI-TEMPS_");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 0.5) MTplus1 = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + MTplus1;
            Console.WriteLine("\t\tPlus de 0.5 buts dans la première période : " + Math.Round(MTplus1, 1) + "% \t||\tMoins de 0.5 buts dans la première période : " + Math.Round(100 - MTplus1, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 1.5) MTplus2 = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + MTplus2;
            Console.WriteLine("\t\tPlus de 1.5 buts dans la première période : " + Math.Round(MTplus2, 1) + "% \t||\tMoins de 1.5 buts dans la première période : " + Math.Round(100 - MTplus2, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 2.5) MTplus3 = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + MTplus3;
            Console.WriteLine("\t\tPlus de 2.5 buts dans la première période : " + Math.Round(MTplus3, 1) + "% \t||\tMoins de 2.5 buts dans la première période : " + Math.Round(100 - MTplus3, 1) + "%");
            Console.WriteLine("\t _FIN DU MATCH_");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 0.5) FTplus1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus1;
            Console.WriteLine("\t\tPlus de 0.5 buts dans le match : " + Math.Round(FTplus1, 1) + "% \t\t\t||\tMoins de 0.5 buts dans le match : " + Math.Round(100 - FTplus1, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 1.5) FTplus2 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus2;
            Console.WriteLine("\t\tPlus de 1.5 buts dans le match : " + Math.Round(FTplus2, 1) + "% \t\t\t||\tMoins de 1.5 buts dans le match : " + Math.Round(100 - FTplus2, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 2.5) FTplus3 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus3;
            Console.WriteLine("\t\tPlus de 2.5 buts dans le match : " + Math.Round(FTplus3, 1) + "% \t\t\t||\tMoins de 2.5 buts dans le match : " + Math.Round(100 - FTplus3, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 3.5) FTplus4 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus4;
            Console.WriteLine("\t\tPlus de 3.5 buts dans le match : " + Math.Round(FTplus4, 1) + "% \t\t\t||\tMoins de 3.5 buts dans le match : " + Math.Round(100 - FTplus4, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 4.5) FTplus5 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus5;
            Console.WriteLine("\t\tPlus de 4.5 buts dans le match : " + Math.Round(FTplus5, 1) + "% \t\t\t||\tMoins de 4.5 buts dans le match : " + Math.Round(100 - FTplus5, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 5.5) FTplus6 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus6;
            Console.WriteLine("\t\tPlus de 5.5 buts dans le match : " + Math.Round(FTplus6, 1) + "% \t\t\t||\tMoins de 5.5 buts dans le match : " + Math.Round(100 - FTplus6, 1) + "%");

            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++)
                {
                    double pourcent = (((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i))) * (((Math.Pow(ES2MT, j) * Math.Exp(-ES2MT)) / factorial(j))) * 100;
                    if (pourcent > scoreExactMT)
                    {
                        scoreExactE1MT = i;
                        scoreExactE2MT = j;
                        scoreExactMT = pourcent;
                    }
                }
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++)
                {
                    double pourcent = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100;
                    if (pourcent > scoreExactFT)
                    {
                        scoreExactE1FT = i;
                        scoreExactE2FT = j;
                        scoreExactFT = pourcent;
                    }
                }
            Console.WriteLine("\n _SCORE EXACT_");
            Console.WriteLine("\tScore exact le plus probable à la mi-temps du match : " + scoreExactE1MT + "-" + scoreExactE2MT + " = " + Math.Round(scoreExactMT, 1) + "%");
            Console.WriteLine("\tScore exact le plus probable à la fin du match : " + scoreExactE1FT + "-" + scoreExactE2FT + " = " + Math.Round(scoreExactFT, 1) + "%");
            Console.WriteLine("\n\n  __________________________");
            Console.WriteLine(" |                          |");
            Console.WriteLine(" | LES MEILLEURS PRONOSTICS |");
            Console.WriteLine(" |__________________________|");

            if ((V1FT > 60) && (cotes[0][0] > 1.15) && (cotes[0][0] * V1FT > 95)) Console.WriteLine("Vainqueur final : " + e1.Nom + " (" + cotes[0][0] + ")");
            else if ((100 - V1FT - V2FT > 60) && (cotes[0][1] > 1.15) && (cotes[0][1] * (100 - V1FT - V2FT) > 95)) Console.WriteLine("Vainqueur final : NUL (" + cotes[0][1] + ")");
            else if ((V2FT > 60) && (cotes[0][2] > 1.15) && (cotes[0][2] * V2FT > 95)) Console.WriteLine("Vainqueur final : " + e2.Nom + " (" + cotes[0][2] + ")");
            if ((V1MT > 60) && (cotes[1][0] > 1.15) && (cotes[1][0] * V1MT > 95)) Console.WriteLine("Vainqueur mi-temps : " + e1.Nom + " (" + cotes[1][0] + ")");
            else if ((100 - V1MT - V2MT > 60) && (cotes[1][1] > 1.15) && (cotes[1][1] * (100 - V1MT - V2MT) > 95)) Console.WriteLine("Vainqueur mi-temps : NUL (" + cotes[1][1] + ")");
            else if ((V2MT > 60) && (cotes[1][2] > 1.15) && (cotes[1][2] * V2MT > 95)) Console.WriteLine("Vainqueur mi-temps : " + e2.Nom + " (" + cotes[1][2] + ")");
            if ((FTplus1 > 70) && (cotes[2][0] > 1.15) && (cotes[2][0] * FTplus1 > 95)) Console.WriteLine("Plus de 0.5 buts dans le match : " + "(" + cotes[2][0] + ")");
            else if ((FTplus2 > 65) && (cotes[2][1] > 1.15) && (cotes[2][1] * FTplus2 > 95)) Console.WriteLine("Plus de 1.5 buts dans le match : " + "(" + cotes[2][1] + ")");
            else if ((FTplus3 > 60) && (cotes[2][2] > 1.15) && (cotes[2][2] * FTplus3 > 95)) Console.WriteLine("Plus de 2.5 buts dans le match : " + "(" + cotes[2][2] + ")");
            else if ((FTplus4 > 55) && (cotes[2][3] > 1.15) && (cotes[2][3] * FTplus4 > 95)) Console.WriteLine("Plus de 3.5 buts dans le match : " + "(" + cotes[2][3] + ")");
            if ((100 - FTplus1 > 55) && (cotes[3][0] > 1.15) && (cotes[3][0] * (100 - FTplus1) > 95)) Console.WriteLine("Moins de 0.5 buts dans le match : " + "(" + cotes[3][0] + ")");
            else if ((100 - FTplus2 > 60) && (cotes[3][1] > 1.15) && (cotes[3][1] * (100 - FTplus2) > 95)) Console.WriteLine("Moins de 1.5 buts dans le match : " + "(" + cotes[3][1] + ")");
            else if ((100 - FTplus3 > 65) && (cotes[3][2] > 1.15) && (cotes[3][2] * (100 - FTplus3) > 95)) Console.WriteLine("Moins de 2.5 buts dans le match : " + "(" + cotes[3][2] + ")");
            else if ((100 - FTplus4 > 70) && (cotes[3][3] > 1.15) && (cotes[3][3] * (100 - FTplus4) > 95)) Console.WriteLine("Moins de 3.5 buts dans le match : " + "(" + cotes[3][3] + ")");
            if ((MTplus1 > 70) && (cotes[4][0] > 1.15) && (cotes[4][0] * MTplus1 > 95)) Console.WriteLine("Plus de 0.5 buts à la mi-temps : " + "(" + cotes[4][0] + ")");
            else if ((MTplus2 > 65) && (cotes[4][1] > 1.15) && (cotes[4][1] * MTplus2 > 95)) Console.WriteLine("Plus de 1.5 buts à la mi-temps : " + "(" + cotes[4][1] + ")");
            else if ((MTplus3 > 60) && (cotes[4][2] > 1.15) && (cotes[4][2] * MTplus3 > 95)) Console.WriteLine("Plus de 2.5 buts à la mi-temps : " + "(" + cotes[4][2] + ")");
            if ((100 - MTplus1 > 60) && (cotes[5][0] > 1.15) && (cotes[5][0] * (100 - MTplus1) > 95)) Console.WriteLine("Moins de 0.5 buts à la mi-temps : " + "(" + cotes[5][0] + ")");
            else if ((100 - MTplus2 > 65) && (cotes[5][1] > 1.15) && (cotes[5][1] * (100 - MTplus2) > 95)) Console.WriteLine("Moins de 1.5 buts à la mi-temps : " + "(" + cotes[5][1] + ")");
            else if ((100 - MTplus3 > 70) && (cotes[5][2] > 1.15) && (cotes[5][2] * (100 - MTplus3) > 95)) Console.WriteLine("Moins de 2.5 buts à la mi-temps : " + "(" + cotes[5][2] + ")");
            if ((100 - Math.Round(V2FT, 1) > 75) && (cotes[6][0] > 1.15) && (cotes[6][0] * (100 - Math.Round(V2FT, 1)) > 95)) Console.WriteLine("Vainqueur double chance final : " + e1.Nom + " ou nul (" + cotes[6][0] + ")");
            else if ((100 - Math.Round(NFT, 1) > 75) && (cotes[6][1] > 1.15) && (cotes[6][1] * (100 - Math.Round(NFT, 1)) > 95)) Console.WriteLine("Vainqueur double chance final : " + e1.Nom + " ou " + e2.Nom + " (" + cotes[6][1] + ")");
            else if ((100 - Math.Round(V1FT, 1) > 75) && (cotes[6][2] > 1.15) && (cotes[6][2] * (100 - Math.Round(V1FT, 1)) > 95)) Console.WriteLine("Vainqueur double chance final : " + e2.Nom + " ou nul (" + cotes[6][2] + ")");
            if ((100 - Math.Round(V2MT, 1) > 75) && (cotes[7][0] > 1.15) && (cotes[7][0] * (100 - Math.Round(V2MT, 1)) > 95)) Console.WriteLine("Vainqueur double chance à la mi-temps : " + e1.Nom + " ou nul (" + cotes[7][0] + ")");
            else if ((100 - Math.Round(NMT, 1) > 75) && (cotes[7][1] > 1.15) && (cotes[7][1] * (100 - Math.Round(NMT, 1)) > 95)) Console.WriteLine("Vainqueur double chance à la mi-temps : " + e1.Nom + " ou " + e2.Nom + " (" + cotes[7][1] + ")");
            else if ((100 - Math.Round(V1MT, 1) > 75) && (cotes[7][2] > 1.15) && (cotes[7][2] * (100 - Math.Round(V1MT, 1)) > 95)) Console.WriteLine("Vainqueur double chance à la mi-temps : " + e2.Nom + " ou nul (" + cotes[7][2] + ")");
            if ((BTTSFT > 60) && (cotes[8][0] > 1.15) && (cotes[8][0] * BTTSFT > 95)) Console.WriteLine("BTTS Oui : " + "(" + cotes[8][0] + ")");
            else if ((100 - BTTSFT > 60) && (cotes[8][1] > 1.15) && (cotes[8][1] * (100 - BTTSFT) > 95)) Console.WriteLine("BTTS Non : " + "(" + cotes[8][1] + ")");

            Console.Write("\n\nVotre choix : ");
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
        static string AfficherMatch(Data data, int c, int s, Match match, List<List<double>> cotes)
        {
            Console.Clear();
            string choix = "";
            Equipe e1 = data.Equipes.Where(x => x.Id == match.IdEquipes[0]).ToList()[0];
            Equipe e2 = data.Equipes.Where(x => x.Id == match.IdEquipes[1]).ToList()[0];
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
            Console.WriteLine("\n | " + match.DateEtHeure.ToShortDateString() + " |");
            Console.WriteLine(" | J" + match.Journee + " |");
            Console.WriteLine(" " + e1.Nom + " - " + e2.Nom);
            if (match.DateEtHeure < DateTime.Today) Console.WriteLine(" " + match.ScoreFT[0] + "(" + match.ScoreMT[0] + ")" + " - " + match.ScoreFT[1] + "(" + match.ScoreMT[1] + ")");

            Double matchsSaisons = 0;
            Double matchsSaisonsE1 = 0;
            Double matchsSaisonsE2 = 0;
            for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count(); e++)
            {
                for (int m = 0; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count(); m++)
                {
                    if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].IdSaison == match.IdSaison)
                    {
                        if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].DateEtHeure < DateTime.Today)
                        {
                            matchsSaisons++;
                            if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].IdEquipes[0] == e1.Id) { matchsSaisonsE1++; }
                            if (data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].IdEquipes[1] == e2.Id) { matchsSaisonsE2++; }
                        }
                    }
                }
            }
            matchsSaisons = matchsSaisons / 2;
            matchsSaisonsE1 = matchsSaisonsE1 / 2;
            matchsSaisonsE2 = matchsSaisonsE2 / 2;
            List<List<List<List<int>>>> Buts = RecuperationButs(data, c, s, match);
            double ES1MT = ((Buts[1][0][0][0] / matchsSaisonsE1) / (Buts[0][0][0][0] / matchsSaisons)) * ((Buts[2][1][1][0] / matchsSaisonsE2) / (Buts[0][1][1][0] / matchsSaisons)) * (Buts[0][0][0][0] / matchsSaisons);
            double ES1FT = ((Buts[1][0][0][1] / matchsSaisonsE1) / (Buts[0][0][0][1] / matchsSaisons)) * ((Buts[2][1][1][1] / matchsSaisonsE2) / (Buts[0][1][1][1] / matchsSaisons)) * (Buts[0][0][0][1] / matchsSaisons);
            double ES2MT = ((Buts[2][0][1][0] / matchsSaisonsE2) / (Buts[0][0][1][0] / matchsSaisons)) * ((Buts[1][1][0][0] / matchsSaisonsE1) / (Buts[0][1][0][0] / matchsSaisons)) * (Buts[0][0][1][0] / matchsSaisons);
            double ES2FT = ((Buts[2][0][1][1] / matchsSaisonsE2) / (Buts[0][0][1][1] / matchsSaisons)) * ((Buts[1][1][0][1] / matchsSaisonsE1) / (Buts[0][1][0][1] / matchsSaisons)) * (Buts[0][0][1][1] / matchsSaisons);
            /*Console.WriteLine("\nNombre de buts marqué au total à domicile, mi-temps : " + Buts[0][0][0][0]);
            Console.WriteLine("Nombre de buts marqué au total à domicile, fin de match : " + Buts[0][0][0][1]);
            Console.WriteLine("Nombre de buts concédé au total à domicile, mi-temps : " + Buts[0][1][0][0]);
            Console.WriteLine("Nombre de buts concédé au total à domicile, fin de match : " + Buts[0][1][0][1]);
            Console.WriteLine("\nNombre de buts marqué au total à l'extérieur, mi-temps : " + Buts[0][0][1][0]);
            Console.WriteLine("Nombre de buts marqué au total à l'extérieur, fin de match : " + Buts[0][0][1][1]);
            Console.WriteLine("Nombre de buts concédé au total à l'extérieur, mi-temps : " + Buts[0][1][1][0]);
            Console.WriteLine("Nombre de buts concédé au total à l'extérieur, fin de match : " + Buts[0][1][1][1]);
            Console.WriteLine("\nNombre de buts marqué par l'équipe à domicile, mi-temps : " + Buts[1][0][0][0]);
            Console.WriteLine("Nombre de buts marqué par l'équipe à domicile, fin de match : " + Buts[1][0][0][1]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à domicile, mi-temps : " + Buts[1][1][0][0]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à domicile, fin de match : " + Buts[1][1][0][1]);
            Console.WriteLine("\nNombre de buts marqué par l'équipe à l'extérieur, mi-temps : " + Buts[2][0][1][0]);
            Console.WriteLine("Nombre de buts marqué par l'équipe à l'extérieur, fin de match : " + Buts[2][0][1][1]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à l'extérieur, mi-temps : " + Buts[2][1][1][0]);
            Console.WriteLine("Nombre de buts concédé par l'équipe à l'extérieur, fin de match : " + Buts[2][1][1][1]);
            Console.WriteLine("\n\n -TOTAL- ");
            Console.WriteLine("Moyenne de but marqué à domicile, fin de match : " + Math.Round(Buts[0][0][0][1] / matchsSaisons, 2));
            Console.WriteLine("Moyenne de but concédé à domicile, fin de match : " + Math.Round(Buts[0][1][0][1] / matchsSaisons, 2));
            Console.WriteLine("Moyenne de but marqué à l'exterieur, fin de match : " + Math.Round(Buts[0][0][1][1] / matchsSaisons, 2));
            Console.WriteLine("Moyenne de but concédé à l'exterieur, fin de match : " + Math.Round(Buts[0][1][1][1] / matchsSaisons, 2));
            Console.WriteLine("\n\n -" + e1.Nom + "- ");
            Console.WriteLine("Force d'attaque à domicile, mi-temps : " + Math.Round((Buts[1][0][0][0] / matchsSaisonsE1) / (Buts[0][0][0][0] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à domicile, mi-temps : " + Math.Round((Buts[1][1][0][0] / matchsSaisonsE1) / (Buts[0][1][0][0] / matchsSaisons), 2));
            Console.WriteLine("Force d'attaque à domicile, fin de match : " + Math.Round((Buts[1][0][0][1] / matchsSaisonsE1) / (Buts[0][0][0][1] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à domicile, fin de match : " + Math.Round((Buts[1][1][0][1] / matchsSaisonsE1) / (Buts[0][1][0][1] / matchsSaisons), 2));
            Console.WriteLine("Espérance de but à domicile, mi-temps : " + Math.Round(ES1MT, 2));
            Console.WriteLine("Espérance de but à domicile, fin du match : " + Math.Round(ES1FT, 2));
            Console.WriteLine("\n\n -" + e2.Nom + "- ");
            Console.WriteLine("Force d'attaque à l'exterieur, mi-temps : " + Math.Round((Buts[2][0][1][0] / matchsSaisonsE2) / (Buts[0][0][1][0] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à l'exterieur, mi-temps : " + Math.Round((Buts[2][1][1][0] / matchsSaisonsE2) / (Buts[0][1][1][0] / matchsSaisons), 2));
            Console.WriteLine("Force d'attaque à l'exterieur, fin de match : " + Math.Round((Buts[2][0][1][1] / matchsSaisonsE2) / (Buts[0][0][1][1] / matchsSaisons), 2));
            Console.WriteLine("Potentiel de défense à l'exterieur, fin de match : " + Math.Round((Buts[2][1][1][1] / matchsSaisonsE2) / (Buts[0][1][1][1] / matchsSaisons), 2));
            Console.WriteLine("Espérance de but à l'extérieur, mi-temps : " + Math.Round(ES2MT, 2));
            Console.WriteLine("Espérance de but à l'extérieur, fin du match : " + Math.Round(ES2FT, 2));
            Console.WriteLine("Pourcentage de chance nombre de buts " + e1.Nom + ", mi-temps : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i)) * 100, 1) + "%");
            Console.WriteLine("\nPourcentage de chance nombre de buts " + e1.Nom + ", fin de match : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i)) * 100, 1) + "%");
            Console.WriteLine("\nPourcentage de chance nombre de buts " + e2.Nom + ", mi-temps : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i)) * 100, 1) + "%");
            Console.WriteLine("\nPourcentage de chance nombre de buts " + e2.Nom + ", fin du match : ");
            for (int i = 0; i <= 9; i++) Console.Write(" " + i + " = " + Math.Round(((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i)) * 100, 1) + "%");*/
            

            double V1MT = 0;
            double NMT = 0;
            double V2MT = 0;
            double V1FT = 0;
            double NFT = 0;
            double V2FT = 0;
            double BTTSMT = 0;
            double BTTSFT = 0;
            double V1FTplus2 = 0;
            double V2FTplus2 = 0;
            double V1FTplus3 = 0;
            double V2FTplus3 = 0;
            double V1FTplus4 = 0;
            double V2FTplus4 = 0;
            double V1FTplus5 = 0;
            double V2FTplus5 = 0;
            double V1FTplus2E2 = 0;
            double V2FTplus2E1 = 0;
            double V1FTplus3E2 = 0;
            double V2FTplus3E1 = 0;
            double V1FTplus4E2 = 0;
            double V2FTplus4E1 = 0;
            double V1FTplus5E2 = 0;
            double V2FTplus5E1 = 0;
            double FTplus1 = 0;
            double FTplus2 = 0;
            double FTplus3 = 0;
            double FTplus4 = 0;
            double FTplus5 = 0;
            double FTplus6 = 0;
            double MTplus1 = 0;
            double MTplus2 = 0;
            double MTplus3 = 0;
            double scoreExactMT = 0;
            double scoreExactFT = 0;
            int scoreExactE1MT = 0;
            int scoreExactE2MT = 0;
            int scoreExactE1FT = 0;
            int scoreExactE2FT = 0;

            Console.WriteLine("\n_VICTOIRE_");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V1MT = (((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i))) * (((Math.Pow(ES2MT, j) * Math.Exp(-ES2MT)) / factorial(j))) * 100 + V1MT;
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V2MT = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + V2MT;
            NMT = 100 - V1MT - V2MT;
            Console.WriteLine("\tVainqueur mi-temps : " + Math.Round(V1MT, 1) + "|" + Math.Round(NMT, 1) + "|" + Math.Round(V2MT, 1));
            Console.WriteLine("\tVainqueur double chance mi-temps : " + (100 - Math.Round(V2MT, 1)) + "|" + (100 - Math.Round(NMT, 1)) + "|" + (100 - Math.Round(V1MT, 1)));

            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V1FT = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FT;
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i > j) V2FT = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FT;
            NFT = 100 - V1FT - V2FT;
            Console.WriteLine("\tVainqueur final : " + Math.Round(V1FT, 1) + "|" + Math.Round(NFT, 1) + "|" + Math.Round(V2FT, 1));
            Console.WriteLine("\tVainqueur double chance final : " + (100 - Math.Round(V2FT, 1)) + "|" + (100 - Math.Round(NFT, 1)) + "|" + (100 - Math.Round(V1FT, 1)));

            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i != 0 && j != 0) BTTSMT = (((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i))) * (((Math.Pow(ES2MT, j) * Math.Exp(-ES2MT)) / factorial(j))) * 100 + BTTSMT;
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i != 0 && j != 0) BTTSFT = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + BTTSFT;
            Console.WriteLine("\n _LES DEUX EQUIPES MARQUENT_");
            Console.WriteLine("\tBTTS mi-temps : OUI = " + Math.Round(BTTSMT, 1) + " | NON = " + Math.Round(100 - BTTSMT, 1));
            Console.WriteLine("\tBTTS fin de match : OUI = " + Math.Round(BTTSFT, 1) + " | NON = " + Math.Round(100 - BTTSFT, 1));

            Console.WriteLine("\n _VICTOIRE & NOMBRE DE BUTS FULL-TIME_");
            if (V1FT > V2FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 1.5)) V1FTplus2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 1.5 buts dans le match : " + Math.Round(V1FTplus2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 2.5)) V1FTplus3 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus3;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 2.5 buts dans le match : " + Math.Round(V1FTplus3, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 3.5)) V1FTplus4 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus4;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 3.5 buts dans le match : " + Math.Round(V1FTplus4, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 4.5)) V1FTplus5 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus5;
                Console.WriteLine("\t" + e1.Nom + " vainqueur & plus de 4.5 buts dans le match : " + Math.Round(V1FTplus5, 1) + "%");
            }
            if (V2FT > V1FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 1.5)) V2FTplus2 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus2;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 1.5 buts dans le match : " + Math.Round(V2FTplus2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 2.5)) V2FTplus3 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus3;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 2.5 buts dans le match : " + Math.Round(V2FTplus3, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 3.5)) V2FTplus4 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus4;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 3.5 buts dans le match : " + Math.Round(V2FTplus4, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 4.5)) V2FTplus5 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus5;
                Console.WriteLine("\t" + e2.Nom + " vainqueur & plus de 4.5 buts dans le match : " + Math.Round(V2FTplus5, 1) + "%");
            }

            Console.WriteLine("\n _VICTOIRE & NOMBRE DE BUTS D'ECART FIN DU MATCH_");
            if (V1FT > V2FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 1.5)) V1FTplus2E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus2E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 1 but ou plus dans le match : " + Math.Round(V1FTplus2E2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 2.5)) V1FTplus3E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus3E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 2 buts ou plus dans le match : " + Math.Round(V1FTplus3E2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 3.5)) V1FTplus4E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus4E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 3 buts ou plus dans le match : " + Math.Round(V1FTplus4E2, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i > j + 4.5)) V1FTplus5E2 = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100 + V1FTplus5E2;
                Console.WriteLine("\t" + e1.Nom + " vainqueur de 4 buts ou plus dans le match : " + Math.Round(V1FTplus5E2, 1) + "%");
            }
            if (V2FT > V1FT)
            {
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 1.5)) V2FTplus2E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus2E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 1 but ou plus dans le match : " + Math.Round(V2FTplus2E1, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 2.5)) V2FTplus3E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus3E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 2 buts ou plus dans le match : " + Math.Round(V2FTplus3E1, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 3.5)) V2FTplus4E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus4E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 3 buts ou plus dans le match : " + Math.Round(V2FTplus4E1, 1) + "%");
                for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if ((i > j) && (i + j > 4.5)) V2FTplus5E1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + V2FTplus5E1;
                Console.WriteLine("\t" + e2.Nom + " vainqueur de 4 buts ou plus dans le match : " + Math.Round(V2FTplus5E1, 1) + "%");
            }

            Console.WriteLine("\n _NOMBRE DE BUTS_");
            Console.WriteLine("\t _MI-TEMPS_");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 0.5) MTplus1 = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + MTplus1;
            Console.WriteLine("\t\tPlus de 0.5 buts dans la première période : " + Math.Round(MTplus1, 1) + "% \t||\tMoins de 0.5 buts dans la première période : " + Math.Round(100 - MTplus1, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 1.5) MTplus2 = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + MTplus2;
            Console.WriteLine("\t\tPlus de 1.5 buts dans la première période : " + Math.Round(MTplus2, 1) + "% \t||\tMoins de 1.5 buts dans la première période : " + Math.Round(100 - MTplus2, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 2.5) MTplus3 = (((Math.Pow(ES2MT, i) * Math.Exp(-ES2MT)) / factorial(i))) * (((Math.Pow(ES1MT, j) * Math.Exp(-ES1MT)) / factorial(j))) * 100 + MTplus3;
            Console.WriteLine("\t\tPlus de 2.5 buts dans la première période : " + Math.Round(MTplus3, 1) + "% \t||\tMoins de 2.5 buts dans la première période : " + Math.Round(100 - MTplus3, 1) + "%");
            Console.WriteLine("\t _FIN DU MATCH_");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 0.5) FTplus1 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus1;
            Console.WriteLine("\t\tPlus de 0.5 buts dans le match : " + Math.Round(FTplus1, 1) + "% \t\t\t||\tMoins de 0.5 buts dans le match : " + Math.Round(100 - FTplus1, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 1.5) FTplus2 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus2;
            Console.WriteLine("\t\tPlus de 1.5 buts dans le match : " + Math.Round(FTplus2, 1) + "% \t\t\t||\tMoins de 1.5 buts dans le match : " + Math.Round(100 - FTplus2, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 2.5) FTplus3 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus3;
            Console.WriteLine("\t\tPlus de 2.5 buts dans le match : " + Math.Round(FTplus3, 1) + "% \t\t\t||\tMoins de 2.5 buts dans le match : " + Math.Round(100 - FTplus3, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 3.5) FTplus4 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus4;
            Console.WriteLine("\t\tPlus de 3.5 buts dans le match : " + Math.Round(FTplus4, 1) + "% \t\t\t||\tMoins de 3.5 buts dans le match : " + Math.Round(100 - FTplus4, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 4.5) FTplus5 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus5;
            Console.WriteLine("\t\tPlus de 4.5 buts dans le match : " + Math.Round(FTplus5, 1) + "% \t\t\t||\tMoins de 4.5 buts dans le match : " + Math.Round(100 - FTplus5, 1) + "%");
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++) if (i + j > 5.5) FTplus6 = (((Math.Pow(ES2FT, i) * Math.Exp(-ES2FT)) / factorial(i))) * (((Math.Pow(ES1FT, j) * Math.Exp(-ES1FT)) / factorial(j))) * 100 + FTplus6;
            Console.WriteLine("\t\tPlus de 5.5 buts dans le match : " + Math.Round(FTplus6, 1) + "% \t\t\t||\tMoins de 5.5 buts dans le match : " + Math.Round(100 - FTplus6, 1) + "%");

            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++)
                {
                    double pourcent = (((Math.Pow(ES1MT, i) * Math.Exp(-ES1MT)) / factorial(i))) * (((Math.Pow(ES2MT, j) * Math.Exp(-ES2MT)) / factorial(j))) * 100;
                    if (pourcent > scoreExactMT)
                    {
                        scoreExactE1MT = i;
                        scoreExactE2MT = j;
                        scoreExactMT = pourcent;
                    }
                }
            for (int i = 0; i <= 9; i++) for (int j = 0; j <= 9; j++)
                {
                    double pourcent = (((Math.Pow(ES1FT, i) * Math.Exp(-ES1FT)) / factorial(i))) * (((Math.Pow(ES2FT, j) * Math.Exp(-ES2FT)) / factorial(j))) * 100;
                    if (pourcent > scoreExactFT)
                    {
                        scoreExactE1FT = i;
                        scoreExactE2FT = j;
                        scoreExactFT = pourcent;
                    }
                }
            Console.WriteLine("\n _SCORE EXACT_");
            Console.WriteLine("\tScore exact le plus probable à la mi-temps du match : " + scoreExactE1MT + "-" + scoreExactE2MT + " = " + Math.Round(scoreExactMT, 1) + "%");
            Console.WriteLine("\tScore exact le plus probable à la fin du match : " + scoreExactE1FT + "-" + scoreExactE2FT + " = " + Math.Round(scoreExactFT, 1) + "%");
            Console.WriteLine("\n\n  __________________________");
            Console.WriteLine(" |                          |");
            Console.WriteLine(" | LES MEILLEURS PRONOSTICS |");
            Console.WriteLine(" |__________________________|");

            if ((V1FT > 60) && (cotes[0][0] > 1.15) && (cotes[0][0] * V1FT > 95)) Console.WriteLine("Vainqueur final : " + e1.Nom + " (" + cotes[0][0] + ")");
            else if ((100 - V1FT - V2FT > 60) && (cotes[0][1] > 1.15) && (cotes[0][1] * (100 - V1FT - V2FT) > 95)) Console.WriteLine("Vainqueur final : NUL (" + cotes[0][1] + ")");
            else if ((V2FT > 60) && (cotes[0][2] > 1.15) && (cotes[0][2] * V2FT > 95)) Console.WriteLine("Vainqueur final : " + e2.Nom + " (" + cotes[0][2] + ")");
            if ((V1MT > 60) && (cotes[1][0] > 1.15) && (cotes[1][0] * V1MT > 95)) Console.WriteLine("Vainqueur mi-temps : " + e1.Nom + " (" + cotes[1][0] + ")");
            else if ((100 - V1MT - V2MT > 60) && (cotes[1][1] > 1.15) && (cotes[1][1] * (100 - V1MT - V2MT) > 95)) Console.WriteLine("Vainqueur mi-temps : NUL (" + cotes[1][1] + ")");
            else if ((V2MT > 60) && (cotes[1][2] > 1.15) && (cotes[1][2] * V2MT > 95)) Console.WriteLine("Vainqueur mi-temps : " + e2.Nom + " (" + cotes[1][2] + ")");
            if ((FTplus1 > 70) && (cotes[2][0] > 1.15) && (cotes[2][0] * FTplus1 > 95)) Console.WriteLine("Plus de 0.5 buts dans le match : " + "(" + cotes[2][0] + ")");
            else if ((FTplus2 > 65) && (cotes[2][1] > 1.15) && (cotes[2][1] * FTplus2 > 95)) Console.WriteLine("Plus de 1.5 buts dans le match : " + "(" + cotes[2][1] + ")");
            else if ((FTplus3 > 60) && (cotes[2][2] > 1.15) && (cotes[2][2] * FTplus3 > 95)) Console.WriteLine("Plus de 2.5 buts dans le match : " + "(" + cotes[2][2] + ")");
            else if ((FTplus4 > 55) && (cotes[2][3] > 1.15) && (cotes[2][3] * FTplus4 > 95)) Console.WriteLine("Plus de 3.5 buts dans le match : " + "(" + cotes[2][3] + ")");
            if ((100 - FTplus1 > 55) && (cotes[3][0] > 1.15) && (cotes[3][0] * (100 - FTplus1) > 95)) Console.WriteLine("Moins de 0.5 buts dans le match : " + "(" + cotes[3][0] + ")");
            else if ((100 - FTplus2 > 60) && (cotes[3][1] > 1.15) && (cotes[3][1] * (100 - FTplus2) > 95)) Console.WriteLine("Moins de 1.5 buts dans le match : " + "(" + cotes[3][1] + ")");
            else if ((100 - FTplus3 > 65) && (cotes[3][2] > 1.15) && (cotes[3][2] * (100 - FTplus3) > 95)) Console.WriteLine("Moins de 2.5 buts dans le match : " + "(" + cotes[3][2] + ")");
            else if ((100 - FTplus4 > 70) && (cotes[3][3] > 1.15) && (cotes[3][3] * (100 - FTplus4) > 95)) Console.WriteLine("Moins de 3.5 buts dans le match : " + "(" + cotes[3][3] + ")");
            if ((MTplus1 > 70) && (cotes[4][0] > 1.15) && (cotes[4][0] * MTplus1 > 95)) Console.WriteLine("Plus de 0.5 buts à la mi-temps : " + "(" + cotes[4][0] + ")");
            else if ((MTplus2 > 65) && (cotes[4][1] > 1.15) && (cotes[4][1] * MTplus2 > 95)) Console.WriteLine("Plus de 1.5 buts à la mi-temps : " + "(" + cotes[4][1] + ")");
            else if ((MTplus3 > 60) && (cotes[4][2] > 1.15) && (cotes[4][2] * MTplus3 > 95)) Console.WriteLine("Plus de 2.5 buts à la mi-temps : " + "(" + cotes[4][2] + ")");
            if ((100 - MTplus1 > 60) && (cotes[5][0] > 1.15) && (cotes[5][0] * (100 - MTplus1) > 95)) Console.WriteLine("Moins de 0.5 buts à la mi-temps : " + "(" + cotes[5][0] + ")");
            else if ((100 - MTplus2 > 65) && (cotes[5][1] > 1.15) && (cotes[5][1] * (100 - MTplus2) > 95)) Console.WriteLine("Moins de 1.5 buts à la mi-temps : " + "(" + cotes[5][1] + ")");
            else if ((100 - MTplus3 > 70) && (cotes[5][2] > 1.15) && (cotes[5][2] * (100 - MTplus3) > 95)) Console.WriteLine("Moins de 2.5 buts à la mi-temps : " + "(" + cotes[5][2] + ")");
            if ((100 - Math.Round(V2FT, 1) > 75) && (cotes[6][0] > 1.15) && (cotes[6][0] * (100 - Math.Round(V2FT, 1)) > 95)) Console.WriteLine("Vainqueur double chance final : " + e1.Nom + " ou nul (" + cotes[6][0] + ")");
            else if ((100 - Math.Round(NFT, 1) > 75) && (cotes[6][1] > 1.15) && (cotes[6][1] * (100 - Math.Round(NFT, 1)) > 95)) Console.WriteLine("Vainqueur double chance final : " + e1.Nom + " ou " + e2.Nom + " (" + cotes[6][1] + ")");
            else if ((100 - Math.Round(V1FT, 1) > 75) && (cotes[6][2] > 1.15) && (cotes[6][2] * (100 - Math.Round(V1FT, 1)) > 95)) Console.WriteLine("Vainqueur double chance final : " + e2.Nom + " ou nul (" + cotes[6][2] + ")");
            if ((100 - Math.Round(V2MT, 1) > 75) && (cotes[7][0] > 1.15) && (cotes[7][0] * (100 - Math.Round(V2MT, 1)) > 95)) Console.WriteLine("Vainqueur double chance à la mi-temps : " + e1.Nom + " ou nul (" + cotes[7][0] + ")");
            else if ((100 - Math.Round(NMT, 1) > 75) && (cotes[7][1] > 1.15) && (cotes[7][1] * (100 - Math.Round(NMT, 1)) > 95)) Console.WriteLine("Vainqueur double chance à la mi-temps : " + e1.Nom + " ou " + e2.Nom + " (" + cotes[7][1] + ")");
            else if ((100 - Math.Round(V1MT, 1) > 75) && (cotes[7][2] > 1.15) && (cotes[7][2] * (100 - Math.Round(V1MT, 1)) > 95)) Console.WriteLine("Vainqueur double chance à la mi-temps : " + e2.Nom + " ou nul (" + cotes[7][2] + ")");
            if ((BTTSFT > 60) && (cotes[8][0] > 1.15) && (cotes[8][0] * BTTSFT > 95)) Console.WriteLine("BTTS Oui : " + "(" + cotes[8][0] + ")");
            else if ((100 - BTTSFT > 60) && (cotes[8][1] > 1.15) && (cotes[8][1] * (100 - BTTSFT) > 95)) Console.WriteLine("BTTS Non : " + "(" + cotes[8][1] + ")");


            Console.Write("\n\nVotre choix : ");
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

        static string AfficherMeilleursPronos(Data data, string[] args)
        {
            Console.Clear();
            List<Pronostic> matchs1X2_1 = new List<Pronostic>();
            List<Pronostic> matchs1X2_1X = new List<Pronostic>();
            List<Pronostic> matchs1X2_2 = new List<Pronostic>();
            List<Pronostic> matchs1X2_X2 = new List<Pronostic>();
            List<Pronostic> matchsBTTS = new List<Pronostic>();
            List<Pronostic> matchsNBTTS = new List<Pronostic>();
            List<Pronostic> matchsPlus15 = new List<Pronostic>();
            List<Pronostic> matchsMoins15 = new List<Pronostic>();
            List<Pronostic> matchsMoins25 = new List<Pronostic>();
            try
            {
                Console.WriteLine("CHARGEMENT DES MEILLEURS PRONOSTICS...");
                for (int c = 0; c < data.Competitions.Count()-1; c++)
                {
                    for (int s = 0; s < data.Competitions[c].Saisons.Count; s++){
                        data = data._Json.CreateEquipes(data, data.Competitions[c].Saisons[s]);
                        data = data._Json.CreateMatchs(data, data.Competitions[c].Saisons[s]);
                    }
                }
                Console.Clear();
                matchsBTTS = ChargerBTTS(data);
                matchsNBTTS = ChargerNBTTS(data);
                matchsPlus15 = ChargerPlus15(data);
                matchsMoins15 = ChargerMoins15(data);
                matchsMoins25 = ChargerMoins25(data);
                matchs1X2_1 = Charger1X2_1(data);
                matchs1X2_1X = Charger1X2_1X(data);
                matchs1X2_2 = Charger1X2_2(data);
                matchs1X2_X2 = Charger1X2_X2(data);
            }
            catch (Exception e){ Console.WriteLine(e); }
            string choix = "";
            Console.WriteLine(" __________________________________");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|       QUEDUSALE PRONOSTICS       |");
            Console.WriteLine("|__________________________________|\n");
            Console.WriteLine(" __________________________________");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|      MENU MEILLEURS PRONOS       |");
            Console.WriteLine("|__________________________________|");
            Console.WriteLine("| - 0 : fermer app                 |");
            Console.WriteLine("| - 1 : retour menu principal      |");
            Console.WriteLine("|_________________________ ________|");

            double nM6 = 0;
            double nOK6 = 0;
            for (int m = 0; m < matchs1X2_1.Count(); m++)
            {
                if (matchs1X2_1[m].DateHeure.Date < DateTime.Today)
                {
                    nM6++;
                    if (matchs1X2_1[m].Score[0] > matchs1X2_1[m].Score[1]) nOK6++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES PRONOS VICTOIRE DOMICILE 7 DERNIERS JOURS (" + nOK6 + "/" + nM6 + " : " + Math.Round(nOK6 / nM6 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchs1X2_1.Count(); m++) {
                if (matchs1X2_1[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchs1X2_1[m].Score[0] > matchs1X2_1[m].Score[1])
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_1[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_1[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_1[m].NomEquipes[0] + " - " + matchs1X2_1[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_1[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS VICTOIRE DOMICILE PROCHAINS JOURS :\n");
            for (int m = 0; m < matchs1X2_1.Count(); m++) if (matchs1X2_1[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_1[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_1[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_1[m].NomEquipes[0] + " - " + matchs1X2_1[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_1[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n__________________________________________\n");
            
            double nM9 = 0;
            double nOK9 = 0;
            for (int m = 0; m < matchs1X2_1X.Count(); m++)
            {
                if (matchs1X2_1X[m].DateHeure.Date < DateTime.Today)
                {
                    nM9++;
                    if (matchs1X2_1X[m].Score[0] >= matchs1X2_1X[m].Score[1]) nOK9++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES PRONOS VICTOIRE/NUL DOMICILE 7 DERNIERS JOURS (" + nOK9 + "/" + nM9 + " : " + Math.Round(nOK9 / nM9 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchs1X2_1X.Count(); m++)
            {
                if (matchs1X2_1X[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchs1X2_1X[m].Score[0] >= matchs1X2_1X[m].Score[1])
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_1X[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_1X[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_1X[m].NomEquipes[0] + " - " + matchs1X2_1X[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_1X[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS VICTOIRE/NUL DOMICILE PROCHAINS JOURS :\n");
            for (int m = 0; m < matchs1X2_1X.Count(); m++) if (matchs1X2_1X[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_1X[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_1X[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_1X[m].NomEquipes[0] + " - " + matchs1X2_1X[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_1X[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n__________________________________________\n");

            double nM8 = 0;
            double nOK8 = 0;
            for (int m = 0; m < matchs1X2_2.Count(); m++)
            {
                if (matchs1X2_2[m].DateHeure.Date < DateTime.Today)
                {
                    nM8++;
                    if (matchs1X2_2[m].Score[0] < matchs1X2_2[m].Score[1]) nOK8++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES PRONOS VICTOIRE EXTERIEUR 7 DERNIERS JOURS (" + nOK8 + "/" + nM8 + " : " + Math.Round(nOK8 / nM8 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchs1X2_2.Count(); m++)
            {
                if (matchs1X2_2[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchs1X2_2[m].Score[0] < matchs1X2_2[m].Score[1])
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_2[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_2[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_2[m].NomEquipes[0] + " - " + matchs1X2_2[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_2[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS VICTOIRE EXTERIEUR PROCHAINS JOURS :\n");
            for (int m = 0; m < matchs1X2_2.Count(); m++) if (matchs1X2_2[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_2[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_2[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_2[m].NomEquipes[0] + " - " + matchs1X2_2[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_2[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n__________________________________________\n");

            double nM10 = 0;
            double nOK10 = 0;
            for (int m = 0; m < matchs1X2_X2.Count(); m++)
            {
                if (matchs1X2_X2[m].DateHeure.Date < DateTime.Today)
                {
                    nM10++;
                    if (matchs1X2_X2[m].Score[0] <= matchs1X2_X2[m].Score[1]) nOK10++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES PRONOS NUL/VICTOIRE EXTERIEUR 7 DERNIERS JOURS (" + nOK10 + "/" + nM10 + " : " + Math.Round(nOK10 / nM10 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchs1X2_X2.Count(); m++)
            {
                if (matchs1X2_X2[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchs1X2_X2[m].Score[0] <= matchs1X2_X2[m].Score[1])
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_X2[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_X2[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_X2[m].NomEquipes[0] + " - " + matchs1X2_X2[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_X2[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS NUL/VICTOIRE EXTERIEUR PROCHAINS JOURS :\n");
            for (int m = 0; m < matchs1X2_X2.Count(); m++) if (matchs1X2_X2[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchs1X2_X2[m].IdCompetition).ToList()[0].Nom + ") " + matchs1X2_X2[m].DateHeure.Date.ToShortDateString() + " : " + matchs1X2_X2[m].NomEquipes[0] + " - " + matchs1X2_X2[m].NomEquipes[1] + "(" + Math.Round(matchs1X2_X2[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n__________________________________________\n");
            
            double nM = 0;
            double nOK = 0;
            for (int m = 0; m < matchsBTTS.Count(); m++) {
                if (matchsBTTS[m].DateHeure.Date < DateTime.Today)
                {
                    nM++;
                    if (matchsBTTS[m].Score[0] > 0 && matchsBTTS[m].Score[1] > 0) nOK++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES PRONO BTTS 7 DERNIERS JOURS (" + nOK + "/" + nM + " : " + Math.Round(nOK/nM*100.00, 2) + "%)\n");
            for (int m = 0; m < matchsBTTS.Count(); m++)
            {
                if (matchsBTTS[m].DateHeure.Date < DateTime.Today)
                {
                    if ((matchsBTTS[m].Score[0] >= 1) && (matchsBTTS[m].Score[1] >= 1))
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsBTTS[m].IdCompetition).ToList()[0].Nom + ") " + matchsBTTS[m].DateHeure.Date.ToShortDateString() + " : " + matchsBTTS[m].NomEquipes[0] + " - " + matchsBTTS[m].NomEquipes[1] + "(" + Math.Round(matchsBTTS[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS BTTS PROCHAINS JOURS :\n");
            for (int m = 0; m < matchsBTTS.Count(); m++) if(matchsBTTS[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsBTTS[m].IdCompetition).ToList()[0].Nom + ") " +matchsBTTS[m].DateHeure.Date.ToShortDateString() + " : " + matchsBTTS[m].NomEquipes[0] + " - " + matchsBTTS[m].NomEquipes[1] + "(" + Math.Round(matchsBTTS[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n__________________________________________\n");

            double nM2 = 0;
            double nOK2 = 0;
            for (int m = 0; m < matchsNBTTS.Count(); m++)
            {
                if (matchsNBTTS[m].DateHeure.Date < DateTime.Today)
                {
                    nM2++;
                    if (matchsNBTTS[m].Score[0] < 1 || matchsNBTTS[m].Score[1] < 1) nOK2++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES NON BTTS 7 DERNIERS JOURS (" + nOK2 + "/" + nM2 + " : " + Math.Round(nOK2 / nM2 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchsNBTTS.Count(); m++)
            {
                if (matchsNBTTS[m].DateHeure.Date < DateTime.Today)
                {
                    if ((matchsNBTTS[m].Score[0] < 1) || (matchsNBTTS[m].Score[1] < 1))
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsNBTTS[m].IdCompetition).ToList()[0].Nom + ") " + matchsNBTTS[m].DateHeure.Date.ToShortDateString() + " : " + matchsNBTTS[m].NomEquipes[0] + " - " + matchsNBTTS[m].NomEquipes[1] + "(" + Math.Round(matchsNBTTS[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS NON BTTS PROCHAINS JOURS :\n");
            for (int m = 0; m < matchsNBTTS.Count(); m++) if (matchsNBTTS[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsNBTTS[m].IdCompetition).ToList()[0].Nom + ") " + matchsNBTTS[m].DateHeure.Date.ToShortDateString() + " : " + matchsNBTTS[m].NomEquipes[0] + " - " + matchsNBTTS[m].NomEquipes[1] + "(" + Math.Round(matchsNBTTS[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n_______________________________________________\n");

            double nM3 = 0;
            double nOK3 = 0;
            for (int m = 0; m < matchsPlus15.Count(); m++)
            {
                if (matchsPlus15[m].DateHeure.Date < DateTime.Today)
                {
                    nM3++;
                    if (matchsPlus15[m].Score[0] + matchsPlus15[m].Score[1] > 1.5) nOK3++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES +1.5 BUTS FIN DU MATCH 7 DERNIERS JOURS (" + nOK3 + "/" + nM3 + " : " + Math.Round(nOK3 / nM3 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchsPlus15.Count(); m++)
            {
                if (matchsPlus15[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchsPlus15[m].Score[0] + matchsPlus15[m].Score[1] > 1.5)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsPlus15[m].IdCompetition).ToList()[0].Nom + ") " + matchsPlus15[m].DateHeure.Date.ToShortDateString() + " : " + matchsPlus15[m].NomEquipes[0] + " - " + matchsPlus15[m].NomEquipes[1] + "(" + Math.Round(matchsPlus15[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS +1.5 BUTS FIN DU MATCH PROCHAINS JOURS :\n");
            for (int m = 0; m < matchsPlus15.Count(); m++) if (matchsPlus15[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsPlus15[m].IdCompetition).ToList()[0].Nom + ") " + matchsPlus15[m].DateHeure.Date.ToShortDateString() + " : " + matchsPlus15[m].NomEquipes[0] + " - " + matchsPlus15[m].NomEquipes[1] + "(" + Math.Round(matchsPlus15[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n_______________________________________________\n");

            double nM4 = 0;
            double nOK4 = 0;
            for (int m = 0; m < matchsMoins15.Count(); m++)
            {
                if (matchsMoins15[m].DateHeure.Date < DateTime.Today)
                {
                    nM4++;
                    if (matchsMoins15[m].Score[0] + matchsMoins15[m].Score[1] < 1.5) nOK4++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES -1.5 BUTS FIN DU MATCH 7 DERNIERS JOURS (" + nOK4 + "/" + nM4 + " : " + Math.Round(nOK4 / nM4 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchsMoins15.Count(); m++)
            {
                if (matchsMoins15[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchsMoins15[m].Score[0] + matchsMoins15[m].Score[1] < 1.5)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsMoins15[m].IdCompetition).ToList()[0].Nom + ") " + matchsMoins15[m].DateHeure.Date.ToShortDateString() + " : " + matchsMoins15[m].NomEquipes[0] + " - " + matchsMoins15[m].NomEquipes[1] + "(" + Math.Round(matchsMoins15[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS -1.5 BUTS FIN DU MATCH PROCHAINS JOURS :\n");
            for (int m = 0; m < matchsMoins15.Count(); m++) if (matchsMoins15[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsMoins15[m].IdCompetition).ToList()[0].Nom + ") " + matchsMoins15[m].DateHeure.Date.ToShortDateString() + " : " + matchsMoins15[m].NomEquipes[0] + " - " + matchsMoins15[m].NomEquipes[1] + "(" + Math.Round(matchsMoins15[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n_______________________________________________\n");

            double nM5 = 0;
            double nOK5 = 0;
            for (int m = 0; m < matchsMoins25.Count(); m++)
            {
                if (matchsMoins25[m].DateHeure.Date < DateTime.Today)
                {
                    nM5++;
                    if (matchsMoins25[m].Score[0] + matchsMoins25[m].Score[1] < 2.5) nOK5++;
                }
            }
            Console.WriteLine("\nSTATISTIQUES -2.5 BUTS FIN DU MATCH 7 DERNIERS JOURS (" + nOK5 + "/" + nM5 + " : " + Math.Round(nOK5 / nM5 * 100.00, 2) + "%)\n");
            for (int m = 0; m < matchsMoins25.Count(); m++)
            {
                if (matchsMoins25[m].DateHeure.Date < DateTime.Today)
                {
                    if (matchsMoins25[m].Score[0] + matchsMoins25[m].Score[1] < 2.5)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsMoins25[m].IdCompetition).ToList()[0].Nom + ") " + matchsMoins25[m].DateHeure.Date.ToShortDateString() + " : " + matchsMoins25[m].NomEquipes[0] + " - " + matchsMoins25[m].NomEquipes[1] + "(" + Math.Round(matchsMoins25[m].Fiabilite, 2) + "%)");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLISTE MATCHS -2.5 BUTS FIN DU MATCH PROCHAINS JOURS :\n");
            for (int m = 0; m < matchsMoins25.Count(); m++) if (matchsMoins25[m].DateHeure.Date >= DateTime.Today) Console.WriteLine(" (" + data.Competitions.Where(x => x.Id == matchsMoins25[m].IdCompetition).ToList()[0].Nom + ") " + matchsMoins25[m].DateHeure.Date.ToShortDateString() + " : " + matchsMoins25[m].NomEquipes[0] + " - " + matchsMoins25[m].NomEquipes[1] + "(" + Math.Round(matchsMoins25[m].Fiabilite, 2) + "%)");
            Console.WriteLine("\n\n_______________________________________________\n");
            Console.Write("\nVotre choix : ");
            choix = Console.ReadLine();
            switch (choix)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    Main(args);
                    break;
                default:
                    Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;

        }


        /*============================================================================ PARTIE CALCUL ============================================================================*/


        static double factorial(int number)
        {
            if (number == 1 || number == 0)
                return 1;
            else
                return number * factorial(number - 1);
        }
        static List<Pronostic> Charger1X2_1(Data data)
        {
            List<List<double>> pointsEquipesHome = new List<List<double>>();
            List<List<double>> pointsEquipesAway = new List<List<double>>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchs1X2_1 = new List<Pronostic>();
            List<double> liste = new List<double> { 0, 0 };
            for (int c = 0; c < data.Competitions.Count(); c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(liste);
                    liste = new List<double> { 0, 0 };
                    pointsEquipesAway.Add(liste);
                    liste = new List<double> { 0, 0 };
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today)
                        {
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0])
                            {
                                pointsEquipesHome[iEquipes][0] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                                pointsEquipesHome[iEquipes][1] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                            }
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1])
                            {
                                pointsEquipesAway[iEquipes][0] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                                pointsEquipesAway[iEquipes][1] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                            }
                        }
                    }
                    iEquipes++;
                }
            }
            double score = 0.0;
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count(); c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (!matchs1X2_1.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1))
                        {
                            score = (pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][0] / pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][1]) / (pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][0] / pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][1]);
                            if (score > 3.5)
                            {
                                prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                                prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                                prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                                prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                                prono.Prono = "Victoire : " + prono.NomEquipes[0];
                                prono.Fiabilite = score*10*1.5;
                                if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                                matchs1X2_1.Add(prono);
                                prono = new Pronostic();
                            }
                        }
                            
                    }
                }
            }

            return matchs1X2_1;
        }
        static List<Pronostic> Charger1X2_1X(Data data)
        {
            List<List<double>> pointsEquipesHome = new List<List<double>>();
            List<List<double>> pointsEquipesAway = new List<List<double>>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchs1X2_1 = new List<Pronostic>();
            List<double> liste = new List<double> { 0, 0 };
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(liste);
                    liste = new List<double> { 0, 0 };
                    pointsEquipesAway.Add(liste);
                    liste = new List<double> { 0, 0 };
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today)
                        {
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0])
                            {
                                pointsEquipesHome[iEquipes][0] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                                pointsEquipesHome[iEquipes][1] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                            }
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1])
                            {
                                pointsEquipesAway[iEquipes][0] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                                pointsEquipesAway[iEquipes][1] += data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                            }
                        }
                    }
                    iEquipes++;
                }
            }
            double score = 0.0;
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (!matchs1X2_1.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1))
                        {
                            score = (pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][0] / pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][1]) / (pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][0] / pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][1]);
                            if (score <=4.5 && score >= 3)
                            {
                                prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                                prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                                prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                                prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                                prono.Prono = "Victoire/Nul : " + prono.NomEquipes[0];
                                prono.Fiabilite = score * 10 * 3;
                                if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                                matchs1X2_1.Add(prono);
                                prono = new Pronostic();
                            }
                        }

                    }
                }
            }

            return matchs1X2_1;
        }
        static List<Pronostic> Charger1X2_2(Data data)
        {
            List<List<double>> pointsEquipesHome = new List<List<double>>();
            List<List<double>> pointsEquipesAway = new List<List<double>>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchs1X2_2 = new List<Pronostic>();
            List<double> liste = new List<double> { 0, 0 };
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(liste);
                    liste = new List<double> { 0, 0 };
                    pointsEquipesAway.Add(liste);
                    liste = new List<double> { 0, 0 };
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today)
                        {
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0])
                            {
                                pointsEquipesHome[iEquipes][0] = pointsEquipesHome[iEquipes][0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                                pointsEquipesHome[iEquipes][1] = pointsEquipesHome[iEquipes][1] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                            }
                            else if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1])
                            {
                                pointsEquipesAway[iEquipes][0] = pointsEquipesAway[iEquipes][0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                                pointsEquipesAway[iEquipes][1] = pointsEquipesAway[iEquipes][1] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                            }
                        }
                    }
                    iEquipes++;
                }
            }
            double score = 0.0;
            Pronostic prono = new Pronostic(); 
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (!matchs1X2_2.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1))
                        {
                            score = (pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][0] / pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][1]) / (pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][0] / pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][1]);
                            if (score < 0.6)
                            {
                                prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                                prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                                prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                                prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                                prono.Prono = "Victoire : " + prono.NomEquipes[1];
                                prono.Fiabilite = (1 - score) * 100 * 1.2;
                                if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                                matchs1X2_2.Add(prono);
                                prono = new Pronostic();
                            }
                        }

                    }
                }
            }
            return matchs1X2_2;
        }
        static List<Pronostic> Charger1X2_X2(Data data)
        {
            List<List<double>> pointsEquipesHome = new List<List<double>>();
            List<List<double>> pointsEquipesAway = new List<List<double>>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchs1X2_2 = new List<Pronostic>();
            List<double> liste = new List<double> { 0, 0 };
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(liste);
                    liste = new List<double> { 0, 0 };
                    pointsEquipesAway.Add(liste);
                    liste = new List<double> { 0, 0 };
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today)
                        {
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0])
                            {
                                pointsEquipesHome[iEquipes][0] = pointsEquipesHome[iEquipes][0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                                pointsEquipesHome[iEquipes][1] = pointsEquipesHome[iEquipes][1] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                            }
                            else if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1])
                            {
                                pointsEquipesAway[iEquipes][0] = pointsEquipesAway[iEquipes][0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1];
                                pointsEquipesAway[iEquipes][1] = pointsEquipesAway[iEquipes][1] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0];
                            }
                        }
                    }
                    iEquipes++;
                }
            }
            double score = 0.0;
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (!matchs1X2_2.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1))
                        {
                            score = (pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][0] / pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])][1]) / (pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][0] / pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])][1]);
                            if (score >= 0.4 && score <= 0.8)
                            {
                                prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                                prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                                prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                                prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                                prono.Prono = "Victoire/Nul : " + prono.NomEquipes[1];
                                prono.Fiabilite = (1-score) * 100 * 1.8;
                                if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                                matchs1X2_2.Add(prono);
                                prono = new Pronostic();
                            }
                        }

                    }
                }
            }
            return matchs1X2_2;
        }
        static List<Pronostic> ChargerBTTS(Data data)
        {
            List<double> pointsChampionnats = new List<double>();
            for (int i = 0; i < data.Competitions.Count()-1; i++) pointsChampionnats.Add(0);
            List<double> pointsEquipesHome = new List<double>();
            List<double> pointsEquipesAway = new List<double>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchsBTTS = new List<Pronostic>();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] > 0 && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] > 0)
                        {
                            pointsChampionnats[c]++;
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]) pointsEquipesHome[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }   
            }
            iEquipes = 0;
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    pointsEquipesAway.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1] && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] > 0 && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] > 0)
                        {
                            pointsEquipesAway[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        double score1 = pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])] / ((pointsChampionnats[c] / 2) / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        double score2 = pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])] / ((pointsChampionnats[c] / 2) / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        if (!matchsBTTS.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1) && score1 > 1.05 && score2 > 1.25)
                        {
                            prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                            prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                            prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                            prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                            prono.Prono = "BTTS : Oui";
                            prono.Fiabilite = score1*score2 * 100 * 0.4;
                            if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                            matchsBTTS.Add(prono);
                            prono = new Pronostic();
                        }
                    }
                }
            }

            return matchsBTTS;
        }

        static List<Pronostic> ChargerNBTTS(Data data)
        {
            List<double> pointsChampionnats = new List<double>();
            for (int i = 0; i < data.Competitions.Count()-1; i++) pointsChampionnats.Add(0);
            List<double> pointsEquipesHome = new List<double>();
            List<double> pointsEquipesAway = new List<double>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchsNBTTS = new List<Pronostic>();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] < 1 || data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] < 1))
                        {
                            pointsChampionnats[c]++;
                            if(data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0])pointsEquipesHome[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            iEquipes = 0;
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    pointsEquipesAway.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1] && (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] < 1 || data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] < 1))
                        {
                            pointsEquipesAway[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        double score1 = pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])] / ((pointsChampionnats[c] / 2) / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        double score2 = pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])] / ((pointsChampionnats[c]) / 2 / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        if (!matchsNBTTS.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1) && score1 > 0.8 && score2 > 1.2)
                        {
                            prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                            prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                            prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                            prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                            prono.Prono = "BTTS : Non";
                            prono.Fiabilite = score1 * score2 * 100 * 0.4;
                            if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                            matchsNBTTS.Add(prono);
                            prono = new Pronostic();
                        }
                    }
                }
            }

            return matchsNBTTS;
        }

        static List<Pronostic> ChargerPlus15(Data data)
        {
            List<double> pointsChampionnats = new List<double>();
            for (int i = 0; i < data.Competitions.Count()-1; i++) pointsChampionnats.Add(0);
            List<double> pointsEquipesHome = new List<double>();
            List<double> pointsEquipesAway = new List<double>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchsPlus15 = new List<Pronostic>();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] > 1.5)
                        {
                            pointsChampionnats[c]++;
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]) pointsEquipesHome[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            iEquipes = 0;
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    pointsEquipesAway.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1] && (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] > 1.5))
                        {
                            pointsEquipesAway[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        double score1 = pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])] / ((pointsChampionnats[c] / 2) / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        double score2 = pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])] / ((pointsChampionnats[c]) / 2 / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        if (!matchsPlus15.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1) && score1 > 1.05 && score2 > 1.1)
                        {
                            prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                            prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                            prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                            prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                            prono.Prono = "Nombre de buts : + 1.5";
                            prono.Fiabilite = score1 * score2 * 100 * 0.6;
                            if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                            matchsPlus15.Add(prono);
                            prono = new Pronostic();
                        }
                    }
                }
            }

            return matchsPlus15;
        }

        static List<Pronostic> ChargerMoins15(Data data)
        {
            List<double> pointsChampionnats = new List<double>();
            for (int i = 0; i < data.Competitions.Count()-1; i++) pointsChampionnats.Add(0);
            List<double> pointsEquipesHome = new List<double>();
            List<double> pointsEquipesAway = new List<double>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchsMoins15 = new List<Pronostic>();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] < 1.5)
                        {
                            pointsChampionnats[c]++;
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]) pointsEquipesHome[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            iEquipes = 0;
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    pointsEquipesAway.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1] && (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] < 1.5))
                        {
                            pointsEquipesAway[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        double score1 = pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])] / ((pointsChampionnats[c] / 2) / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        double score2 = pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])] / ((pointsChampionnats[c]) / 2 / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        if (!matchsMoins15.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1) && score1 > 1.5 && score2 > 1.5)
                        {
                            prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                            prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                            prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                            prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                            prono.Prono = "Nombre de buts : - 1.5";
                            prono.Fiabilite = score1 * score2 * 10 * 1.2;
                            if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                            matchsMoins15.Add(prono);
                            prono = new Pronostic();
                        }
                    }
                }
            }

            return matchsMoins15;
        }

        static List<Pronostic> ChargerMoins25(Data data)
        {
            List<double> pointsChampionnats = new List<double>();
            for (int i = 0; i < data.Competitions.Count()-1; i++) pointsChampionnats.Add(0);
            List<double> pointsEquipesHome = new List<double>();
            List<double> pointsEquipesAway = new List<double>();
            int iEquipes = 0;
            List<Equipe> equipes = new List<Equipe>();
            List<Pronostic> matchsMoins25 = new List<Pronostic>();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    equipes.Add(data.Competitions[c].Saisons[0].Equipes[e]);
                    pointsEquipesHome.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] < 2.5)
                        {
                            pointsChampionnats[c]++;
                            if (data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]) pointsEquipesHome[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            iEquipes = 0;
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    pointsEquipesAway.Add(0);
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        if (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date < DateTime.Today && data.Competitions[c].Saisons[0].Equipes[e].Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1] && (data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[0] + data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT[1] < 2.5))
                        {
                            pointsEquipesAway[iEquipes]++;
                        }
                    }
                    iEquipes++;
                }
            }
            Pronostic prono = new Pronostic();
            for (int c = 0; c < data.Competitions.Count()-1; c++)
            {
                for (int e = 0; e < data.Competitions[c].Saisons[0].Equipes.Count(); e++)
                {
                    for (int m = 0; m < data.Competitions[c].Saisons[0].Equipes[e].Matchs.Count; m++)
                    {
                        double score1 = pointsEquipesHome[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[0]).ToList()[0])] / ((pointsChampionnats[c] / 2) / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        double score2 = pointsEquipesAway[equipes.IndexOf(equipes.Where(x => x.Id == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdEquipes[1]).ToList()[0])] / ((pointsChampionnats[c]) / 2 / Convert.ToDouble(data.Competitions[c].Saisons[0].Equipes.Count()));
                        if (!matchsMoins25.Any(x => x.NomEquipes == data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date >= DateTime.Today.AddDays(-7) && data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure.Date <= DateTime.Today.AddDays(1) && score1 > 1.2 && score2 > 1.2)
                        {
                            prono.NomEquipes = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].NomEquipes;
                            prono.IdCompetition = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].IdCompetition;
                            prono.DateHeure = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].DateEtHeure;
                            prono.Score = data.Competitions[c].Saisons[0].Equipes[e].Matchs[m].ScoreFT;
                            prono.Prono = "Nombre de buts : - 2.5";
                            prono.Fiabilite = score1 * score2 * 100 * 0.3;
                            if (prono.Fiabilite > 100) prono.Fiabilite = 100;
                            matchsMoins25.Add(prono);
                            prono = new Pronostic();
                        }
                    }
                }
            }

            return matchsMoins25;
        }

        /**
        * <summary> Fonction qui récupère les nombres de buts de la saison </summary>
        * <remarks> 
        * Le premier   : Correspond à la saison [0], à l'équipe locale [1] ou à l'équipe visiteuse [2]
        * Le second    : Correspond aux buts, si les buts sont marqués [0] ou concédés [1]
        * Le troisième : Correspond à une équipe, l'équipe à domicile [0] ou l'équipe à l'extérieur [1]
        * Le quatrième : Correspond à la durée, la première mi-temps [0] ou la fin du match [1]
        * </remarks>
        **/


        static List<List<List<List<int>>>> RecuperationButs(Data data, int c, int s, Match match)
        {
            List<List<List<List<int>>>> Buts = new List<List<List<List<int>>>>
            {
                new List<List<List<int>>>
                {
                    new List<List<int>>
                    {
                        new List<int>{0, 0},
                        new List<int>{0, 0},
                    },
                    new List<List<int>>
                    {
                        new List<int>{0, 0},
                        new List<int>{0, 0},
                    }
                },
                new List<List<List<int>>>
                {
                    new List<List<int>>
                    {
                        new List<int>{0, 0},
                        new List<int>{0, 0},
                    },
                    new List<List<int>>
                    {
                        new List<int>{0, 0},
                        new List<int>{0, 0},
                    }
                },
                new List<List<List<int>>>
                {
                    new List<List<int>>
                    {
                        new List<int>{0, 0},
                        new List<int>{0, 0},
                    },
                    new List<List<int>>
                    {
                        new List<int>{0, 0},
                        new List<int>{0, 0},
                    }
                },
            };
            List<Match> matchs = new List<Match>();
            for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count(); e++)
            {
                for (int m = 0; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count(); m++)
                {
                    if (!matchs.Contains(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m]))
                    {
                       if(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m].DateEtHeure < match.DateEtHeure) matchs.Add(data.Competitions[c].Saisons[s].Equipes[e].Matchs[m]);
                    }
                }
            }
            foreach (Match m in matchs)
            {
                Buts[0][0][0][0] = Buts[0][0][0][0] + m.ScoreMT[0]; // Nombre de buts marqué au total à domicile, mi-temps
                Buts[0][0][0][1] = Buts[0][0][0][1] + m.ScoreFT[0]; // Nombre de buts marqué au total à domicile, fin de match
                Buts[0][0][1][0] = Buts[0][0][1][0] + m.ScoreMT[1]; // Nombre de buts marqué au total à l'extérieur, mi-temps
                Buts[0][0][1][1] = Buts[0][0][1][1] + m.ScoreFT[1]; // Nombre de buts marqué au total à l'extérieur, fin de match
                Buts[0][1][0][0] = Buts[0][1][0][0] + m.ScoreMT[1]; // Nombre de buts concédé au total à domicile, mi-temps
                Buts[0][1][0][1] = Buts[0][1][0][1] + m.ScoreFT[1]; // Nombre de buts concédé au total à domicile, fin de match
                Buts[0][1][1][0] = Buts[0][1][1][0] + m.ScoreMT[0]; // Nombre de buts concédé au total à l'extérieur, mi-temps
                Buts[0][1][1][1] = Buts[0][1][1][1] + m.ScoreFT[0]; // Nombre de buts concédé au total à l'extérieur, fin de match

                if (m.IdEquipes[0] == match.IdEquipes[0])
                {
                    Buts[1][0][0][0] = Buts[1][0][0][0] + m.ScoreMT[0]; // Nombre de buts marqué par l'équipe à domicile, mi-temps
                    Buts[1][0][0][1] = Buts[1][0][0][1] + m.ScoreFT[0]; // Nombre de buts marqué par l'équipe à domicile, fin de match
                    Buts[1][1][0][0] = Buts[1][1][0][0] + m.ScoreMT[1]; // Nombre de buts concédé par l'équipe à domicile, mi-temps
                    Buts[1][1][0][1] = Buts[1][1][0][1] + m.ScoreFT[1]; // Nombre de buts concédé par l'équipe à domicile, fin de match
                }
                else if (m.IdEquipes[1] == match.IdEquipes[1])
                {
                    Buts[2][0][1][0] = Buts[2][0][1][0] + m.ScoreMT[1]; // Nombre de buts marqué par l'équipe à l'extérieur, mi-temps
                    Buts[2][0][1][1] = Buts[2][0][1][1] + m.ScoreFT[1]; // Nombre de buts marqué par l'équipe à l'extérieur, fin de match
                    Buts[2][1][1][0] = Buts[2][1][1][0] + m.ScoreMT[0]; // Nombre de buts concédé par l'équipe à l'extérieur, mi-temps
                    Buts[2][1][1][1] = Buts[2][1][1][1] + m.ScoreFT[0]; // Nombre de buts concédé par l'équipe à l'extérieur, fin de match
                }
            }
            
            return Buts;
        }
        static List<List<double>> ChargerCotes(Data data, int c, int s, Match match)
        {
            List<List<double>> Cotes = new List<List<double>>
            {
                new List<double> {0,0,0}, //victoire final 1X2
                new List<double> {0,0,0}, //victoire mitemps 1X2
                new List<double> {0,0,0,0}, //nombre buts plus final
                new List<double> {0,0,0,0}, //nombre buts moins final
                new List<double> {0,0,0}, //nombre buts plus mi-temps
                new List<double> {0,0,0}, //nombre buts moins mi-temps
                new List<double> {0,0,0}, //victoire final double chance 1X2
                new List<double> {0,0,0}, //victoire mitemps double chance 1X2
                new List<double> {0,0}, //btts o/n
            };
            Equipe e1 = data.Equipes.Where(x => x.Id == match.IdEquipes[0]).ToList()[0];
            Equipe e2 = data.Equipes.Where(x => x.Id == match.IdEquipes[1]).ToList()[0];
            Console.Clear();
            Console.WriteLine(" _VAINQUEUR FINAL_");
            Console.Write("\nCôte " + e1.Nom + " : ");
            Cotes[0][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte NUL : ");
            Cotes[0][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte " + e2.Nom + " : ");
            Cotes[0][2] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n\n _VAINQUEUR MI-TEMPS_");
            Console.Write("\nCôte " + e1.Nom + " : ");
            Cotes[1][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte NUL : ");
            Cotes[1][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte " + e2.Nom + " : ");
            Cotes[1][2] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n\n _NOMBRES DE BUTS DANS LE MATCH_");
            Console.Write("\nCôte plus de 0.5 buts dans le match : ");
            Cotes[2][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte plus de 1.5 buts dans le match : ");
            Cotes[2][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte plus de 2.5 buts dans le match : ");
            Cotes[2][2] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte plus de 3.5 buts dans le match : ");
            Cotes[2][3] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 0.5 buts dans le match : ");
            Cotes[3][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 1.5 buts dans le match : ");
            Cotes[3][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 2.5 buts dans le match : ");
            Cotes[3][2] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 3.5 buts dans le match : ");
            Cotes[3][3] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n\n _NOMBRES DE BUTS MI-TEMPS_");
            Console.Write("\nCôte plus de 0.5 buts mi-temps : ");
            Cotes[4][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte plus de 1.5 buts mi-temps : ");
            Cotes[4][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte plus de 2.5 buts mi-temps : ");
            Cotes[4][2] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 0.5 buts mi-temps : ");
            Cotes[5][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 1.5 buts mi-temps : ");
            Cotes[5][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte moins de 2.5 buts mi-tempsh : ");
            Cotes[5][2] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n\n _VAINQUEUR DOUBLE CHANCE FINAL_");
            Console.Write("\nCôte " + e1.Nom + " ou nul : ");
            Cotes[6][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte " + e1.Nom + " ou " + e2.Nom + " : ");
            Cotes[6][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte " + e2.Nom + " ou nul : ");
            Cotes[6][2] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n\n _VAINQUEUR DOUBLE CHANCE MI-TEMPS_");
            Console.Write("\nCôte " + e1.Nom + " ou nul : ");
            Cotes[7][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte " + e1.Nom + " ou " + e2.Nom + " : ");
            Cotes[7][1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte " + e2.Nom + " ou nul : ");
            Cotes[7][2] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n\n _BTTS_");
            Console.Write("\nCôte Oui : ");
            Cotes[8][0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nCôte Non : ");
            Cotes[8][1] = Convert.ToDouble(Console.ReadLine());
            return Cotes;
        }
        #endregion
    }
}

/*============================================================================ RESTANT A FAIRE ============================================================================*/
// Tout découle de la fonction RecuperationButs et les fonctions sont mises dans l'ordre, chaque sous-fonction, dépend de la fonction du-dessus
// Si fonction RecuperationButs OK, le reste découle tout seul

/*
 * Débeuguer la fonction RecuperationButs... (résultat faussé, peut-être dû à la non-différence entre Domicile/Extérieur ou beug de l'API...) 
 * 
 * Calculer les moyennes : (Grâce à la fonction RecuperationButs -> Retourne un nombre décimal)
 *             ¤ MoyenneButMarque :
 *                 ° Mi-temps :
 *                      SaisonDomicile => 1er cas général / Nbr match joué à domicile toute équipe confondue
 *                      SaisonExtérieur => 3ème cas général / Nbr match joué à l'extérieur toute équipe confondue
 *                      EquipeDomicile => 1er cas du 1er IF / Nbr match joué de l'équipe à domicile
 *                      EquipeExterieur => 1er cas du 2nd IF / Nbr match joué de l'équipe à l'extérieur
 *                 ° FinMatch :
 *                      SaisonDomicile => 2nd cas général / Nbr match joué à domicile toute équipe confondue
 *                      SaisonExtérieur => 4ème cas général / Nbr match joué à l'extérieur toute équipe confondue
 *                      EquipeDomicile => 2nd cas du 1er IF / Nbr match joué à domicile
 *                      EquipeExterieur  => 2nd cas du 2nd IF / Nbr match joué à l'extérieur
 *             ¤ MoyenneButConcede :
 *                 ° Mi-temps :
 *                      SaisonDomicile => 5ème cas général / Nbr match joué à domicile toute équipe confondue
 *                      SaisonExterieur => 7ème cas général / Nbr match joué à l'extérieur toute équipe confondue
 *                      EquipeDomicile => 3ème cas du 1er IF / Nbr match joué à domicile
 *                      EquipeExterieur => 3ème cas du 2nd IF / Nbr match joué à l'extérieur
 *                 ° FinMatch :
 *                      SaisonDomicile => 6ème cas général / Nbr match joué à domicile toute équipe confondue
 *                      SaisonExterieur => 8ème cas général / Nbr match joué à l'extérieur toute équipe confondue
 *                      EquipeDomicile => 4ème cas du 1er IF / Nbr match joué à domicile
 *                      EquipeExterieur  => 4ème cas du 2nd IF / Nbr match joué à l'extérieur
 *
 * Calculer la force d'attaque des équipes : (Grâce aux moyennes -> Retourne un décimal)
 *              ¤ EquipeDomicile :
 *                 ° MiTemps : (MoyenneButMarque -> Mi-temps -> EquipeDomicile) / (MoyenneButMarque -> Mi-Temps -> SaisonDomicile)
 *                 ° FinMatch : (MoyenneButMarque -> FinMatch -> EquipeDomicile) / (MoyenneButMarque -> FinMatch -> SaisonDomicile)
 *              ¤ EquipeExterieur :
 *                 ° MiTemps : (MoyenneButMarque -> Mi-temps -> EquipeExterieur) / (MoyenneButMarque -> Mi-Temps -> SaisonExterieur)
 *                 ° FinMatch : (MoyenneButMarque -> FinMatch -> EquipeExterieur) / (MoyenneButMarque -> FinMatch -> SaisonExterieur) 
 *                               
 * Calculer le potentiel de défense des équipes : (Grâce aux moyennes -> Retourne un décimal)
 *              ¤ EquipeDomicile :
 *                 ° MiTemps : (MoyenneButConcede -> Mi-temps -> EquipeDomicile) / (MoyenneButConcede -> Mi-Temps -> SaisonDomicile)
 *                 ° FinMatch : (MoyenneButConcede -> FinMatch -> EquipeDomicile) / (MoyenneButConcede -> FinMatch -> SaisonDomicile)
 *              ¤ EquipeExterieur :
 *                 ° MiTemps : (MoyenneButConcede -> Mi-temps -> EquipeExterieur) / (MoyenneButConcede -> Mi-Temps -> SaisonExterieur)
 *                 ° FinMatch : (MoyenneButConcede -> FinMatch -> EquipeExterieur) / (MoyenneButConcede -> FinMatch -> SaisonExterieur) 
 * 
 * Calculer les espérances de buts : (Grâce aux moyennes, force d'attaque et potentiel de défense calculer -> Retourne un décimal)
 *              ¤ EquipeDomicile :
 *                 ° MiTemps : (ForceAttaque -> EquipeDomicile -> Mitemps) * (PotentielDefense -> EquipeExterieur -> MiTemps) * (MoyenneButDomicile -> MiTemps -> SaisonDomicile)
 *                 ° FinMatch : (ForceAttaque -> EquipeDomicile -> FinMatch) * (PotentielDefense -> EquipeExterieur -> FinMatch) * (MoyenneButDomicile -> FinMatch -> SaisonDomicile)
 *              ¤ EquipeExterieur :
 *                 ° MiTemps : (ForceAttaque -> EquipeExterieur -> Mitemps) * (PotentielDefense -> EquipeDomicile -> MiTemps) * (MoyenneButExterieur -> MiTemps -> SaisonDomicile)
 *                 ° FinMatch : (ForceAttaque -> EquipeExterieur -> FinMatch) * (PotentielDefense -> EquipeDomicile -> FinMatch) * (MoyenneButExterieur -> FinMatch -> SaisonDomicile)
 *
 * Créer deux tableaux (mi-temps, fin de match) de nombre de buts esperer pour l'équipe à domicile puis calculer dans une boucle la probabilité que l'équipe marque X but(s) en incrémentant X (X compris entre 0 et 10 ?)
 * Faire de même pour l'équipe à l'extérieur -> Retourne des probabilités
 * 
 *              LoiPoisson en "Français" = (((((EsperanceButEquipe)^ButEspere) * e(-EsperanceButEquipe)) / (ButEspere!)) * 100)
 *              
 *              En C# : LoiPoisson = ((((Math.Pow(EsperanceButEquipe, ButEspere)) * (Math.Exp(-EsperanceButEquipe))) / Math.Fact(ButEspere)) * 100)
 *              Pas sûr pour la factorielle...
 *  
 *  Créer deux "matrices" (mi-temps, fin de match) des scores probables : (0-0, 0-1, 1-0, ... 9-10, 10-9, 10-10) et additionner les deux équipes pour obtenir le résultat de la probabilité de chaque score -> Retourne des probabilités
 *  
 *  Les pronostics : (Retourne des probabilités)
 *              ¤ Score Exact :
 *                 ° MiTemps => Probabilité donné directement dans le premier tableau à 2 dimensions / matrice
 *                 ° FinMatch => Probabilité donné directement dans le second tableau à 2 dimensions / matrice
 *              ¤ Victoire :
 *                 ° MiTemps :
 *                      EquipeDomicileMT => Additionner les différentes probabilités que l'équipe locale gagne à la mi-temps 
 *                      NulMT => Additionner les différentes probabilités que les deux équipes fassent match nul à la mi-temps    
 *                      EquipeExterieurMT =>  Additionner les différentes probabilités que l'équipe visiteuse gagne à la mi-temps
 *                 ° FinMatch :
 *                      EquipeDomicileFT => Additionner les différentes probabilités que l'équipe locale gagne à la fin du match 
 *                      NulFT => Additionner les différentes probabilités que les deux équipes fassent match nul à la fin du match    
 *                      EquipeExterieurFT =>  Additionner les différentes probabilités que l'équipe visiteuse gagne à la fin du match
 *              ¤ Nbre de buts :
 *                 ° MiTemps :
 *                      moins0.5butMT => Additionner les différentes probabilités qu'il y ait moins de 1 but à la mi-temps 
 *                      plus0.5butMT => Additionner les différentes probabilités qu'il y ait au moins 1 but à la mi-temps
 *                      moins1.5butsMT => Additionner les différentes probabilités qu'il y ait moins de 2 buts à la mi-temps 
 *                      plus1.5butsMT => Additionner les différentes probabilités qu'il y ait au moins 2 but à la mi-temps
 *                      moins2.5butsMT => Additionner les différentes probabilités qu'il y ait moins de 3 but à la mi-temps 
 *                      plus2.5butsMT => Additionner les différentes probabilités qu'il y ait au moins 3 but à la mi-temps
 *                      moins3.5butsMT => Additionner les différentes probabilités qu'il y ait moins de 4 buts à la mi-temps 
 *                      plus3.5butsMT => Additionner les différentes probabilités qu'il y ait au moins 4 but à la mi-temps  
 *                 ° FinMatch :
 *                     moins0.5butFT => Additionner les différentes probabilités qu'il y ait moins de 1 but à la fin du match 
 *                     plus0.5butFT => Additionner les différentes probabilités qu'il y ait au moins 1 but à la fin du match
 *                     moins1.5butsFT => Additionner les différentes probabilités qu'il y ait moins de 2 buts à la fin du match 
 *                     plus1.5butsFT => Additionner les différentes probabilités qu'il y ait au moins 2 but à la fin du match
 *                     moins2.5butsFT => Additionner les différentes probabilités qu'il y ait moins de 3 but à la fin du match
 *                     plus2.5butsFT => Additionner les différentes probabilités qu'il y ait au moins 3 but à la fin du match
 *                     moins3.5butsFT => Additionner les différentes probabilités qu'il y ait moins de 4 buts à la fin du match
 *                     plus3.5butsFT => Additionner les différentes probabilités qu'il y ait au moins 4 but à la fin du match
 *               ¤ BTTS :
 *                 ° MiTemps :
 *                      OuiMT => Additionner les différentes probabilités que les deux équipes marquent lors de la première mi-temps
 *                      NonMT => Additionner les différentes probabilités que les deux équipes ne marquent pas lors de la première mi-temps
 *                 ° FinMatch :
 *                      OuiFT => Additionner les différentes probabilités que les deux équipes marquent lors du match
 *                      NonFT => Additionner les différentes probabilités que les deux équipes ne marquent pas lors du match
 *                      
 * Afficher les différents types de paris sur les matchs
 */
