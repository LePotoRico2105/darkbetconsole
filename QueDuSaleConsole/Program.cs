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
                Console.WriteLine(" _______________________________");
                Console.WriteLine("|                               |");
                Console.WriteLine("|      QUEDUSALE PRONOSTICS     |");
                Console.WriteLine("|_______________________________|");
                Console.WriteLine(" _______________________________");
                Console.WriteLine("|                               |");
                Console.WriteLine("|         MENU PRINCIPAL        |");
                Console.WriteLine("|_______________________________|");
                Console.WriteLine(" _______________________");
                Console.WriteLine("|                      |");
                Console.WriteLine("|      LISTE CHOIX     |");
                Console.WriteLine("|______________________|");
                Console.WriteLine("| - 1 : competitions   |");
                Console.WriteLine("| - 0 : fermer app     |");
                Console.WriteLine("|______________________|");
                Console.Write("Votre choix : ");
                choix = Console.ReadLine();
                if (choix == "1") AfficherCompetitions(data);
            }
        }

        #region
        /**
         * <summary> Procédure qui affiche les compétitions </summary>
         */
        static void AfficherCompetitions(Data data)
        {
            Console.Clear();
            int comp = 0;
            int sais = 0;
            Console.WriteLine("\n La liste des compétitions :");
            for (int c = 0; c < data.Competitions.Count(); c++)
            {
                Console.WriteLine("\n" + c +" - " + data.Competitions[c].Nom + " - " + data.Competitions[c].UnPays.Nom);
                for (int s = 0; s < data.Competitions[c].Saisons.Count(); s++) Console.Write(" | "+ s + ":" + data.Competitions[c].Saisons[s].Debut.Year+ "/" + data.Competitions[c].Saisons[s].Fin.Year);
                Console.Write(" |");
            }
            Console.Write("\nChoisir compétition voulu : ");
            comp = Convert.ToInt32(Console.Read());
            Console.Write("Choisir saison voulu : ");
            sais = Convert.ToInt32(Console.Read());
        }

        /**
         * <summary> Procédure qui affiche les compétitions </summary>
         */
        static void AfficherEquipes(Data data)
        {
            Console.WriteLine("\n La liste des équipes :");
            for (int c = 0; c < data.Competitions.Count; c++)
            {      
                for (int s = 0; s < data.Competitions[c].Saisons.Count; s++)
                {
                    Console.WriteLine(data.Competitions[c].Nom + " (" + data.Competitions[c].Saisons[s].Debut.Year + "/" + +data.Competitions[c].Saisons[s].Fin.Year + ") :");
                    for (int e = 0; e < data.Competitions[c].Saisons[s].Equipes.Count; e++) Console.WriteLine(" - " + data.Competitions[c].Saisons[s].Equipes[e].Nom + " - " + data.Competitions[c].Saisons[s].Equipes[e].Stade);
                }

            }
            
            Console.Read();
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
        #endregion
    }
}