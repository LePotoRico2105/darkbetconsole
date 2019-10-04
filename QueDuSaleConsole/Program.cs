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
            Console.WriteLine(" DOWNLOAD DATE...");
            Data data = new Data();
            Console.Clear();
            Console.WriteLine(" ------------------------");
            Console.WriteLine(" | QUEDUSALE PRONOSTICS |");
            Console.WriteLine(" ------------------------");
            AfficherCompetitions(data);
            Console.Read();
        }

        static void AfficherCompetitions(Data data)
        {
            Console.WriteLine("\n La liste des compétitions :");
            for (int c = 0; c < data.Competitions.Count(); c++) Console.WriteLine(" - " + data.Competitions[c].Nom + "(" + data.Competitions[c].Id + "/" + data.Competitions[c].Code + ") - " + data.Competitions[c].UnPays.Nom + "(" + data.Competitions[c].UnPays.Id + ") - saison actuelle(" + data.Competitions[c].SaisonActuelle.Id + ") : " + data.Competitions[c].SaisonActuelle.Debut.ToShortDateString() + " -> " + data.Competitions[c].SaisonActuelle.Fin.ToShortDateString());
        }
    }
}
