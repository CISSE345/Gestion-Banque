using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_BANQUE.entities;

namespace GESTION_BANQUE.metiers
{
    internal class IClientImpl: IGestionBanque<Client>
    {
            private List<Client> clients = new List<Client>();
            private List<Agence> agences = new List<Agence>();
        public IClientImpl(List<Agence> agencesExistantes)
        {
            agences = agencesExistantes;
        }

        public IClientImpl()
        {
        }

        private static int nextId = 1;

        //Ajouter client


        public void Ajouter(Client entity)
        {
            Console.WriteLine("Veuillez choisir une agence pour ce client :");
            foreach (var agence in agences)
            {
                Console.WriteLine("ID:"+agence.Id +""+ "code:"+ agence.Code + "" + "Libelle:" + agence.Libelle);
            }

            Console.Write("Entrez l'ID de l'agence : ");
            if (int.TryParse(Console.ReadLine(), out int agID))
            {
                var agenceSelectionnee = agences.FirstOrDefault(a => a.Id == agID);
                if (agenceSelectionnee != null)
                {
                    entity.Id = nextId++;
                    entity.Agence = agenceSelectionnee;
                    clients.Add(entity);
                    Console.WriteLine("Client ajouté : " + entity.Nom + "" + "Agence :" +agenceSelectionnee.Libelle);
                }
                else
                {
                    Console.WriteLine("Agence non trouvée. Client non ajouté.");
                }
            }
            else
            {
                Console.WriteLine("Entrée invalide. Client non ajouté.");
            }
        }

        public Client Afficher(int id)
            {
                return clients.FirstOrDefault(c => c.Id == id);
            }

        // Mettre à jour un client existant
        public void Modifier(Client entity)
        {
            var client = clients.FirstOrDefault(c => c.Id == entity.Id);
            if (client != null)
            {
                client.Nom = entity.Nom;
                client.Prenom = entity.Prenom;
                client.Tel = entity.Tel;

                Console.WriteLine("Voulez-vous changer l'agence du client ? (O/N)");
                string reponse = Console.ReadLine();
                if (reponse?.ToUpper() == "O")
                {
                    Console.WriteLine("Veuillez choisir une nouvelle agence :");
                    foreach (var agence in agences)
                    {
                        Console.WriteLine("ID:" + agence.Id + "" + "code:" + agence.Code + "" + "Libelle:" + agence.Libelle);
                    }

                    Console.Write("Entrez l'ID de la nouvelle agence : ");
                    if (int.TryParse(Console.ReadLine(), out int agenceId))
                    {
                        var nouvelleAgence = agences.FirstOrDefault(a => a.Id == agenceId);
                        if (nouvelleAgence != null)
                        {
                            client.Agence = nouvelleAgence;
                            Console.WriteLine("Agence mise à jour pour le client :"+ client.Nom+ " Nouvelle agence :" +nouvelleAgence.Libelle);
                        }
                        else
                        {
                            Console.WriteLine("Agence non trouvée. Modification annulée.");
                        }
                    }
                }
                Console.WriteLine("Client modifié :" +client.Nom );
            }
            else
            {
                Console.WriteLine("Client non trouvé !");
            }
        }

        // Supprimer un client par ID
        public void Supprimer(int id)
            {
                var client = clients.FirstOrDefault(c => c.Id == id);
                if (client != null)
                {
                    clients.Remove(client);
                    Console.WriteLine("Client supprimé avec ID :"+ id);
                }
                else
                {
                    Console.WriteLine("Client non trouvé !");
                }
            }

        public IEnumerable<Client> LireTous()
        {
            return clients;
        }
    }

    }
