using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cours : Evenement
    {
        Entraineur entraineur_cours;
        string jour;
        List<Membre> eleves = new List<Membre>();
        public Cours(string nom, int prix, DateTime debut, TimeSpan duree, Entraineur prof, string jour) : base(nom, prix, debut, duree)
        {
            this.entraineur_cours = prof;
            this.jour = jour;
        }
        public Cours(string nom, int prix, DateTime debut, TimeSpan duree, Entraineur prof, string jour, List<Membre> eleves) : base(nom, prix, debut, duree)
        {
            this.entraineur_cours = prof;
            this.jour = jour;
            this.eleves = eleves;
        }
        public string Jour
        {
            get { return this.jour; }
        }
        public List<Membre> Eleves
        {
            get { return this.eleves; }
        }
        public Entraineur Entraineur_cours
        {
            get { return this.entraineur_cours; }
        }
        public void Changer_jour(string nouveau_jour)
        {
            this.jour = nouveau_jour;
        }
        public void Ajouter_membre(Membre membre)
        {
            eleves.Add(membre);
        }
    }
}
