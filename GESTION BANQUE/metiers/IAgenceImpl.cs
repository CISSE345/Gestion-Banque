using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_BANQUE.entities;

namespace GESTION_BANQUE.metiers
{
    internal class IAgenceImpl: IGestionBanque<Agence>
    {
            private  List<Agence> agences = new List<Agence>();
            private static int nextId = 1;

        // Ajouter une agence
        public void Ajouter(Agence entity)
        {

            entity.Id = nextId++;
            entity.Libelle = $"{entity.Code.Substring(0, 3).ToUpper()}{entity.Id}";
            agences.Add(entity);
            Console.WriteLine("Agence ajoutée avec succès.");
        }

            // Lire une agence par ID
            public Agence Afficher(int id)
            {
                return agences.FirstOrDefault(a => a.Id == id);
            }

            // Mettre à jour une agence existante
            public void Modifier(Agence entity)
            {
                var agence = agences.FirstOrDefault(a => a.Id == entity.Id);
                if (agence != null)
                {
                    agence.Code = entity.Code;
                    agence.Libelle = entity.Libelle;
                Console.WriteLine("Agence modifiee :" + "libelle:" + entity.Libelle + "Code:" + entity.Code);
            }
                else
                {
                    Console.WriteLine("Agence non trouvée !");
                }
            }

            // Supprimer une agence par ID
            public void Supprimer(int id)
            {
                var agence = agences.FirstOrDefault(a => a.Id == id);
                if (agence != null)
                {
                    agences.Remove(agence);
                    Console.WriteLine($"Agence supprimée avec ID : {id}");
                }
                else
                {
                    Console.WriteLine("Agence non trouvée !");
                }
            }

            // Lire toutes les agences
            public IEnumerable<Agence> LireTous()
            {
                return agences;
            }
        }


    }
