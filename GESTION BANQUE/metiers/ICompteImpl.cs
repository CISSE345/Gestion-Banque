using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_BANQUE.entities;

namespace GESTION_BANQUE.metiers
{
    internal class ICompteImpl:IGestionBanque<Comptes>
    {
        private List<Comptes> comptes = new List<Comptes>();
        private List<Client> clients = new List<Client>();
        public ICompteImpl(List<Client> clientsExistants)
        {
            clients = clientsExistants;
        }

        public ICompteImpl()
        {
        }

        public void Ajouter(Comptes entity)
        {
            Console.WriteLine("Quel type de compte voulez-vous créer ?");
            Console.WriteLine("1. Compte Simple");
            Console.WriteLine("2. Compte Épargne");
            Console.Write("Votre choix : ");
            string choix = Console.ReadLine();

            Console.WriteLine("Veuillez choisir un client pour ce compte :");
            foreach (var client in clients)
            {
                Console.WriteLine($"ID : {client.Id}, Nom : {client.Nom}, Prénom : {client.Prenom}, Téléphone : {client.Tel}");
            }

            Console.Write("Entrez l'ID du client : ");
            if (int.TryParse(Console.ReadLine(), out int clientId))
            {
                var clientSelectionne = clients.FirstOrDefault(c => c.Id == clientId);
                if (clientSelectionne != null)
                {
                    
                    string telPart = clientSelectionne.Tel.Substring(Math.Max(0, clientSelectionne.Tel.Length - 4));
                    entity.NumCompte = $"{clientSelectionne.Id}{telPart}";
                    entity.Client = clientSelectionne;

                    if (choix == "1")
                    {
                        Console.Write("Entrez le montant du découvert autorisé : ");
                        decimal tauxDecouvert = decimal.Parse(Console.ReadLine());
                        var compteSimple = new CompteSimple
                        {
                            Id = entity.Id,
                            NumCompte = entity.NumCompte,
                            Solde = entity.Solde,
                            Client = entity.Client,
                            TauxDecouvert = (float)tauxDecouvert,
                        };
                        comptes.Add(compteSimple);
                        Console.WriteLine($"Compte Simple ajouté : ID : {compteSimple.Id}, Numéro : {compteSimple.NumCompte}, Solde : {compteSimple.Solde}, Découvert : {compteSimple.TauxDecouvert}");
                    }
                    else if (choix == "2")
                    {
                        Console.Write("Entrez la durée de l'épargne (en mois) : ");
                        int duree = int.Parse(Console.ReadLine());
                        var compteEpargne = new ComptesEpargne
                        {
                            Id = entity.Id,
                            NumCompte = entity.NumCompte,
                            Solde = entity.Solde,
                            Client = entity.Client,
                            Duree = duree
                        };
                        comptes.Add(compteEpargne);
                        Console.WriteLine($"Compte Épargne ajouté : ID : {compteEpargne.Id}, Numéro : {compteEpargne.NumCompte}, Solde : {compteEpargne.Solde}, Durée : {compteEpargne.Duree} mois");
                    }
                    else
                    {
                        Console.WriteLine("Type de compte invalide. Compte non ajouté.");
                    }
                }
                else
                {
                    Console.WriteLine("Client non trouvé. Compte non ajouté.");
                }
            }
            else
            {
                Console.WriteLine("Entrée invalide. Compte non ajouté.");
            }
        }

        public Comptes Afficher(int id)
        {
            return comptes.FirstOrDefault(c => c.Id == id);
        }


        public void Modifier(Comptes entity)
        {
            var compte = comptes.FirstOrDefault(c => c.Id == entity.Id);
            if (compte != null)
            {
                compte.Solde = entity.Solde;
                compte.NumCompte = entity.NumCompte;
                Console.WriteLine("Voulez-vous changer le client ? (O/N)");
                string reponse = Console.ReadLine();
                if (reponse?.ToUpper() == "O")
                {
                    Console.WriteLine("Veuillez choisir un nouveau client:");
                    foreach (var client in clients)
                    {
                        Console.WriteLine("ID:" + client.Id + "" + "nom:" + client.Nom + "" + "PRENOM:" + client.Prenom);
                    }

                    Console.Write("Entrez l'ID du nouv client : ");
                    if (int.TryParse(Console.ReadLine(), out int clientId))
                    {
                        var nouvClient = clients.FirstOrDefault(a => a.Id == clientId);
                        if (nouvClient != null)
                        {
                            compte.Client = nouvClient;
                            Console.WriteLine("CLIENT mise à jour pour le Compte :" + compte.Solde + " Nouvclient :" + nouvClient.Nom);
                        }
                        else
                        {
                            Console.WriteLine("Client non trouvée. Modification annulée.");
                        }
                    }
                }
                Console.WriteLine("Compte modifié :" + compte.NumCompte);
            }
            else
            {
                Console.WriteLine("Compte non trouvé !");
            }

        }

        public void Supprimer(int id)
        {
            var compte = comptes.FirstOrDefault(c => c.Id == id);
            if (compte != null)
            {
                comptes.Remove(compte);
                Console.WriteLine("Compte supprimé.");
            }
            else
            {
                Console.WriteLine("Compte introuvable.");
            }
        }

        public IEnumerable<Comptes> LireTous()
        {
            return comptes;
        }

    }
}
