using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BANQUE.entities
{
    internal class CompteSimple : Comptes
    {
        private float tauxDecouvert;

        public CompteSimple()
        {
            nbC++;
            Id = nbC;
        }

        public CompteSimple(string numCompte, float solde, Client clientID, float tauxDecouvert) : base(numCompte, solde, clientID)
        {
            this.numCompte = numCompte;
            this.solde = solde;
            this.clientID = clientID;
            this.TauxDecouvert = tauxDecouvert;
        }

        public float TauxDecouvert
        {
            get { return tauxDecouvert; }
            set { tauxDecouvert = value; }
        }

        public override string ToString()
        {
            return base.ToString()+ "" + "Tauxdecouverte:" + TauxDecouvert;
        }
    }
}
