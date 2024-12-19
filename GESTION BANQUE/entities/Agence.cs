using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BANQUE.entities
{
    internal class Agence
    {
        private  int id;
        private string code;
        private string libelle;

        public Agence()
        {
        }

        public Agence(string libelle, string code)
        {
            this.libelle = id + code.Substring(0, 3).ToUpper();
            this.code = code;
        }
        public int Id {
            get{return id; }
            set{id = value;}
        }
        public string Code {
            get { return code; }
            set { code = value; }
        }
        public string Libelle 
        {
            get { return libelle; }
            set { libelle = value; }
        }

        public override string ToString()
        {
            return "Id:" +Id + "" +"Code:" +Code + "" + "Libelle:" +Libelle;
        }
    }
}
