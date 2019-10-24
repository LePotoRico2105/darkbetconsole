using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DOWNLOAD DATA...");
            Data data = new Data();
            Console.Clear();
            Console.WriteLine(" ------------------------");
            Console.WriteLine(" | QUEDUSALE PRONOSTICS |");
            Console.WriteLine(" ------------------------");
            AfficherEquipes(data);
            Console.Read();
        }

        #region
        /**
         * <summary> Procédure qui affiche les compétitions </summary>
         */
        static void AfficherCompetitions(Data data)
        {
            Console.WriteLine("\n La liste des compétitions :");
            for (int c = 0; c < data.Competitions.Count(); c++) Console.WriteLine(" - " + data.Competitions[c].Nom + "(id:" + data.Competitions[c].Id + "/code:" + data.Competitions[c].Code + ") - " + data.Competitions[c].UnPays.Nom + "(id:" + data.Competitions[c].UnPays.Id + ") - saison actuelle(id:" + data.Competitions[c].SaisonActuelle.Id + ") : " + data.Competitions[c].SaisonActuelle.Debut.ToShortDateString() + " -> " + data.Competitions[c].SaisonActuelle.Fin.ToShortDateString());
        }

        /**
         * <summary> Procédure qui affiche les compétitions </summary>
         */
        static void AfficherEquipes(Data data)
        {
            Console.WriteLine("\n La liste des équipes :");
            for (int e = 0; e < data.Equipes.Count(); e++) Console.WriteLine(" - " + data.Equipes[e].Nom + "(id:" + data.Equipes[e].Id + "/initiale:" + data.Equipes[e].Initiale + ") - " + data.Equipes[e].Stade);
        }
        #endregion
    }
}