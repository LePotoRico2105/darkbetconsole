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
            Console.WriteLine(" | QUEDUSALE PRONOSTICSS |");
            Console.WriteLine(" ------------------------");
            Console.WriteLine("\n La liste des compétitions :");
            for (int c = 0; c < data.Competitions.Count(); c++) Console.WriteLine(" - " + data.Competitions[c].Nom);
            Console.Read();
        }
    }
}
