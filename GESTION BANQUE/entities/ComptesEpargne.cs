using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BANQUE.entities
{
    internal class ComptesEpargne : Comptes
    {
        private int duree;

        public ComptesEpargne()
        {
            nbC++;
            Id = nbC;
        }

        public ComptesEpargne(string numCompte, float solde, Client clientID, int duree) : base(numCompte, solde, clientID)
        {
            this.numCompte = numCompte;
            this.solde = solde;
            this.clientID = clientID;
            this.duree = duree;
        }

        public int Duree
        {
            get { return duree; }
            set { duree = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "" + "Duree:" + Duree;
        }
    }
}

