using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_BANQUE.entities;
using GESTION_BANQUE.metiers;
using static System.Collections.Specialized.BitVector32;

namespace GESTION_BANQUE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAgenceImpl gestionAgence = new IAgenceImpl();
            IClientImpl gestionClient = new IClientImpl();
            ICompteImpl gestionCompte = new ICompteImpl();

            int choix;
            
            do
            {
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("1- Gestion Agence");
                Console.WriteLine("2- Gestion Client");
                Console.WriteLine("3- Gestion Comptes");
                Console.WriteLine("4- Quitter");
                Console.Write("Choisissez une option: ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {

                     case 1:
                        Console.WriteLine("Menu agence ");
                        Console.WriteLine("1: ajouter agence ");
                        Console.WriteLine("2: afficher une agence ");
                        Console.WriteLine("3: modifier  agence");
                        Console.WriteLine("4: supprimer agence ");
                        Console.WriteLine("5. Afficher toutes les agences");
                        int type = int.Parse(Console.ReadLine());
                        if(type == 1)
                        {
                            Console.Write("Entrez le code de l'agence : ");
                            string codeAjout = Console.ReadLine();
                            Agence nouvelleAgence = new Agence { Code = codeAjout };
                            gestionAgence.Ajouter(nouvelleAgence);
                        }
                        else if(type ==2){
                            Console.Write("Entrez l'ID de l'agence à afficher : ");
                            int idAfficher = int.Parse(Console.ReadLine());
                            Agence agenceAffichee = gestionAgence.Afficher(idAfficher);

                            if (agenceAffichee != null)
                            {
                                Console.WriteLine("ID :"+ agenceAffichee.Id+ "" + " Code :" +agenceAffichee.Code + "" + "Libellé : "+agenceAffichee.Libelle);
                            }
                            else
                            {
                                Console.WriteLine("Agence non trouvée !");
                            }
                        }
                        else if(type == 3)
                        {
                            Console.Write("Entrez l'ID de l'agence à modifier : ");
                            int idModifier = int.Parse(Console.ReadLine());
                            Console.Write("Entrez le nouveau code de l'agence : ");
                            string codeModifier = Console.ReadLine();
                            Agence agenceModifiee = new Agence {Id = idModifier, Code = codeModifier };
                            gestionAgence.Modifier(agenceModifiee);
                        }
                        else if (type == 4)
                        {
                            Console.Write("Entrez l'ID de l'agence à supprimer : ");
                            int idSupprimer = int.Parse(Console.ReadLine());
                            gestionAgence.Supprimer(idSupprimer);
                        }
                        else if(type == 5)
                        {
                            Console.WriteLine("=== Liste de toutes les agences ===");
                            foreach (var agence in gestionAgence.LireTous())
                            {
                                Console.WriteLine("ID : " + agence.Id);
                                Console.WriteLine("Code:" + agence.Code);
                                Console.WriteLine("Libellé :" +agence.Libelle);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Type invalide.");
                        }
                        break;


                    case 2:
                        Console.WriteLine("Menu Client ");
                        Console.WriteLine("1: ajouter Client ");
                        Console.WriteLine("2: afficher un Client ");
                        Console.WriteLine("3: modifier  Client");
                        Console.WriteLine("4: supprimer Client ");
                        Console.WriteLine("5. Afficher toutes les Client");
                        int num = int.Parse(Console.ReadLine());
                        if (num == 1)
                        {
                            Console.Write("Entrez le nom du client : ");
                            string nom = Console.ReadLine();
                            Console.Write("Entrez le prénom du client : ");
                            string prenom = Console.ReadLine();
                            Console.Write("Entrez le numéro de téléphone du client : ");
                            string tel = Console.ReadLine();

                            Client nouveauClient = new Client { Nom = nom, Prenom = prenom, Tel = tel };
                            gestionClient.Ajouter(nouveauClient);
                            break;
                        }
                        else if(num == 2)
                        {
                            Console.Write("Entrez l'ID du client à afficher : ");
                            int idAfficher = int.Parse(Console.ReadLine());
                            Client clientAffiche = gestionClient.Afficher(idAfficher);

                            if (clientAffiche != null)
                            {
                                Console.WriteLine($"ID :"+clientAffiche.Id + "" + " Nom " +clientAffiche.Nom +"" +" Prénom :"+ clientAffiche.Prenom + "" +" Tel :" +clientAffiche.Tel+ "" +" Agence :" +clientAffiche.Agence.Libelle);
                            }
                            else
                            {
                                Console.WriteLine("Client non trouvé !");
                            }
                        }
                        else if(num == 3)
                        {
                            Console.Write("Entrez l'ID du client à modifier : ");
                            int idModifier = int.Parse(Console.ReadLine());
                            Console.Write("Entrez le nouveau nom du client : ");
                            string nomModif = Console.ReadLine();
                            Console.Write("Entrez le nouveau prénom du client : ");
                            string prenomModif = Console.ReadLine();
                            Console.Write("Entrez le nouveau numéro de téléphone du client : ");
                            string telModif = Console.ReadLine();

                            Client clientModifie = new Client { Id = idModifier, Nom = nomModif, Prenom = prenomModif, Tel = telModif };
                            gestionClient.Modifier(clientModifie);
                        }
                        else if(num == 4)
                        {
                            Console.Write("Entrez l'ID du client à supprimer : ");
                            int idSupprimer = int.Parse(Console.ReadLine());
                            gestionClient.Supprimer(idSupprimer);
                        }
                        else if(num == 5)
                        {
                            Console.WriteLine("=== Liste de tous les clients ===");
                            foreach (var client in gestionClient.LireTous())
                            {
                                Console.WriteLine("ID : " + client.Id);
                                Console.WriteLine("nom:" + client.Nom);
                                Console.WriteLine("Prenom :" + client.Prenom);
                                Console.WriteLine("tel :" + client.Tel);
                                Console.WriteLine("Agence: " + client.Agence.Libelle);
                            }
                        }
                        else
                        {
                            Console.WriteLine("type invalide");
                        }

                        break;

                    case 3:
                        Console.WriteLine("2 compte simple ");
                        Console.WriteLine("1 compte epargne");
                        int tp = int.Parse(Console.ReadLine());
                        if(tp == 1) {
                            Console.WriteLine("Menu Compte ");
                            Console.WriteLine("1: ajouter Compte ");
                            Console.WriteLine("2: afficher un Compte ");
                            Console.WriteLine("3: modifier  Compte");
                            Console.WriteLine("4: supprimer Compte ");
                            Console.WriteLine("5. Afficher toutes les Compte");
                            int num2 = int.Parse(Console.ReadLine());
                            

                        }

                        break;

                    case 4:
                        Console.WriteLine("Quitter!");
                        break;

                    default:
                        Console.WriteLine("Option invalide.");
                        break;
                }
            } while (choix != 4);
        }
    }
}
