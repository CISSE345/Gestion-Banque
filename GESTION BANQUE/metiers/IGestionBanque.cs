using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_BANQUE.entities;

namespace GESTION_BANQUE.metiers
{
    internal interface IGestionBanque
    {
            void Ajouter(T entity);
            T Afficher(int id);
            void Modifier(T entity);
            void Supprimer(int id);
            IEnumerable<T> LireTous();
           
    }


    }
