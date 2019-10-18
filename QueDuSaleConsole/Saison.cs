using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Saison
    {
        private int id;
        private string gagnant;
        private DateTime debut, fin;
        private List<Equipe> equipes;

        public Saison()
        {
        }

        public Saison(int pId, string pGagnant, DateTime pDebut, DateTime pFin)
        {
            this.id = pId;
            if (this.gagnant == null) this.gagnant = null;
                else this.gagnant = pGagnant;
            this.debut = pDebut;
            this.fin = pFin;
            this.equipes = new List<Equipe>();
        }

        ~Saison()
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

        public string Gagnant
        {
            get
            {
                return gagnant;
;
            }

            set
            {
                gagnant = value;
            }
        }


        public DateTime Debut
        {
            get
            {
                return debut;
            }

            set
            {
                debut = value;
            }
        }

        public DateTime Fin
        {
            get
            {
                return fin;
            }

            set
            {
                fin = value;
            }
        }
        public List<Equipe> Equipes
        {
            get
            {
                return equipes;
            }

            set
            {
                equipes = value;
            }
        }

    }
}
