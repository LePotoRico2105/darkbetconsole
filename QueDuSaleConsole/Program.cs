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
            Console.WriteLine("DOWNLOAD DATA...");
            Data data = new Data();
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
         * <summary> Procédure qui affiche les compétitions </summary>
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
                Console.WriteLine("\n " + c +" - " + data.Competitions[c].Nom + " - " + data.Competitions[c].UnPays.Nom);
                for (int s = 0; s < data.Competitions[c].Saisons.Count(); s++) Console.Write(" | "+ s + ":" + data.Competitions[c].Saisons[s].Debut.Year+ "/" + data.Competitions[c].Saisons[s].Fin.Year);
                Console.WriteLine(" |");
            }
            Console.Write("\nChoisir compétition voulu : ");
            choix = Console.ReadLine();
            comp = Convert.ToInt32(choix);
            System.Threading.Thread.Sleep(500);
            Console.Write("Choisir saison voulu : ");
            choix = Console.ReadLine();
            sais = Convert.ToInt32(choix);
            choix = AfficherSaison(data, comp, sais);
            return choix;
        }

        /**
         * <summary> Procédure qui affiche la saison </summary>
         */
        static string AfficherSaison(Data data, int c, int s)
        {
            Console.Clear();
            data.Competitions[c].Saisons[s].Equipes = data._Json.CreateEquipes(data, data.Competitions[c].Saisons[s]);
            data = data._Json.CreateMatchs(data, data.Competitions[c].Saisons[s]);
            string choix = "";
            int nb_c = data.Competitions[c].Nom.Count() + 12 ;
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
         * <summary> Procédure qui affiche les équipes d'une saison </summary>
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
            Console.WriteLine(" __________________________");
            Console.WriteLine("|                          |");
            Console.WriteLine("|       MENU EQUIPES       |");
            Console.WriteLine("|__________________________|");
            Console.WriteLine("| - 0 : fermer app         |");
            Console.WriteLine("| - 1 : retour             |");
            Console.WriteLine("| - 2 : menu principal     |");
            Console.WriteLine("|__________________________|");
            for (int e = 3; e < data.Competitions[c].Saisons[s].Equipes.Count() + 2; e++) Console.WriteLine(" " + e + " - " + data.Competitions[c].Saisons[s].Equipes[e - 2].Nom);
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
                    if (choix != "0" || choix != "1" || choix != "2") AfficherEquipe(data, c, s, Convert.ToInt32(choix) - 2);
                    else Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;
        }

        /**
        * <summary> Procédure qui affiche les compétitions </summary>
        */
        static string AfficherEquipe(Data data, int c, int s, int e)
        {
            Console.Clear();
            string choix = "";
            Console.WriteLine(" _______________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
            Console.WriteLine("|_______________________________|\n");
            Console.WriteLine(" Vous avez selectionné l'équipe suivante : " + data.Competitions[c].Saisons[s].Equipes[e].Nom);
            Console.WriteLine("\n________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("|          MENU EQUIPES         |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("| - 0 : fermer app              |");
            Console.WriteLine("| - 1 : retour                  |");
            Console.WriteLine("| - 2 : menu principal          |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("| - 100 : afficher matchs       |");
            Console.WriteLine("|_______________________________|");
            Console.WriteLine("\n Ci-dessous les informations de l'équipe :");
            Console.WriteLine("\tLogo : " + data.Competitions[c].Saisons[s].Equipes[e].Logo);
            Console.WriteLine("\tNom du stade : " + data.Competitions[c].Saisons[s].Equipes[e].Stade);
            Console.Write("\nVotre choix : ");
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
                case "100":
                    AfficherMatchs(data, c, s);
                    break;
                default:
                    Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;
        }
        /**
         * <summary> Procédure qui affiche les matchs </summary>
         */
        /*static void AfficherMatchs(Data data)
        {
            Console.WriteLine("\n La liste des matchs :");
            for (int c = 0; c < data.Competitions.Count(); c++)
            {
                for (int s = 0; s < data.Competitions[c].Saisons.Count(); s++)
                {
                    Console.WriteLine("(" +data.Competitions[c].Nom + " - " + data.Competitions[c].Saisons[s].Debut.Year + ") :");
                    for (int m = 0; m < data.Competitions[c].Saisons[s].Matchs.Count(); m++)
                    {
                        Console.WriteLine(" - j:" + data.Competitions[c].Saisons[s].Matchs[m].Journee + " | " + data.Competitions[c].Saisons[s].Matchs[m].Equipes[0].Nom + " - " + data.Competitions[c].Saisons[s].Matchs[m].Equipes[1].Nom + " (" + data.Competitions[c].Saisons[s].Matchs[m].ScoreFT[0] + "-" + data.Competitions[c].Saisons[s].Matchs[m].ScoreFT[1] + ")");
                    }
                }
            }
            Console.Read();
        }*/

        /**
         * <summary> Procédure qui affiche les équipes d'une saison </summary>
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
            Console.WriteLine(" __________________________");
            Console.WriteLine("|                          |");
            Console.WriteLine("|       MENU MATCHS       |");
            Console.WriteLine("|__________________________|");
            Console.WriteLine("| - 0 : fermer app         |");
            Console.WriteLine("| - 1 : retour             |");
            Console.WriteLine("|__________________________|");
            for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count(); e++)
            {
                for (int m = 2; m < data.Competitions[c].Saisons[s].Equipes[e].Matchs.Count() + 2; m++)
                {
                    Console.WriteLine(data.Competitions[c].Saisons[s].Equipes.Where(x => x.Id == data.Competitions[c].Saisons[s].Equipes[e].Matchs[m - 2].IdEquipes[0]) + " - " + data.Competitions[c].Saisons[s].Equipes.Where(x => x.Id == data.Competitions[c].Saisons[s].Equipes[e].Matchs[m - 2].IdEquipes[1]));
                }
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
                default:
                    Console.WriteLine("Veuillez saisir une information valide");
                    break;
            }
            return choix;
        }
        /**
        * <summary> Procédure qui affiche les compétitions </summary>
        */
        static void AfficherMatch(Data data, int c, int s, int m)
        {
        }
        #endregion
    }
}