using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BANQUE.entities
{
    internal abstract class Comptes
    {
        protected int id;
        protected string numCompte;
        protected float solde;
        protected Client clientID;
        protected static int nbC;

        protected Comptes()
        {
        }

        protected Comptes(string numCompte, float solde, Client clientID)
        {
            this.numCompte = numCompte;
            this.solde = solde;
            this.clientID = clientID;
        }
        public int Id {  
            get { return id; }
            set { id = value; }
        }
        public string NumCompte
        {
            get { return numCompte; }
            set { numCompte = value; }
        }
        public float Solde
        {
            get { return solde; }
            set { solde = value; }
        }
        public Client Client
        {
            get { return clientID; }
            set {  clientID = value; }
        }


    }
}
