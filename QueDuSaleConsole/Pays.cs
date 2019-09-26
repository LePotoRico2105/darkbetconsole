using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    class Pays
    {
        private int id;
        private string nom;

        public Pays()
        {
            Console.WriteLine("Nouveau pays créé");
        }

        public Pays(int pId, string pNom)
        {
            this.id = pId;
            this.nom = pNom;
            Console.WriteLine("Nouveau pays créé : " + nom);
        }

        ~Pays()
        {
            Console.WriteLine("Pays détruit");
        }
    
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }
    }
}
