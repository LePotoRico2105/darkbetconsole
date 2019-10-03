﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Saison
    {
        private int id;
        private DateTime debut, fin;

        public Saison()
        {
        }

        public Saison(int pId, DateTime pDebut, DateTime pFin)
        {
            this.id = pId;
            this.debut = pDebut;
            this.fin = pFin;
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
    }
}
