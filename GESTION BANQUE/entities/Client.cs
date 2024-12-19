using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BANQUE.entities
{
    internal class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private Agence agence;

        public Client()
        {
        }

        public Client(string nom, string prenom, string tel, Agence agence)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
            this.agence = agence;
        }
        public int Id {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public Agence Agence
        {
            get { return agence; }
            set { agence = value; }
        }
        public override string ToString()
        {
            return "Id:" + Id + "" + "Nom:" + Nom + "" + "Prenom:" + Prenom + "Tel:" + Tel + "" + "Agence:"+Agence;
        }
    }
}
