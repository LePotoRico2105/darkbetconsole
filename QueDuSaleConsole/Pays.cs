using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Pays
    {
        private int id;
        private string nom;

        public Pays()
        {
        }

        public Pays(int pId, string pNom)
        {
            this.id = pId;
            this.nom = pNom;
        }

        ~Pays()
        {
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
