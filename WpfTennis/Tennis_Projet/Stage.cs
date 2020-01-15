using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Stage : Evenement
    {
        List<Membre> membres_participants;
        Entraineur liste_entraineur;
        Club orga;
        public Stage(string nom, int prix, DateTime debut, TimeSpan duree, Club organisateur)
    : base(nom, prix, debut, duree)
        {
            this.orga = organisateur;

        }
        public bool Ajout_Membre(Membre membre)
        {
            bool Ajout_reussi = false;
            if (membre.Calcul_age() < 18)
            {
                Ajout_reussi = true;
                foreach (Stage element in membre.Stage)
                {
                    if ((element.Date_debut_evenement >= this.Date_debut_evenement) && (element.Date_debut_evenement <= this.Date_fin_evenement)
                        || (element.Date_fin_evenement >= this.Date_debut_evenement) && (element.Date_fin_evenement <= this.Date_fin_evenement)
                        || (element.Date_debut_evenement <= this.Date_debut_evenement) && (element.Date_fin_evenement >= this.Date_fin_evenement))
                    {
                        Ajout_reussi = false;
                    }
                }
                foreach (Equipe_Competition element in membre.Equipes)
                {
                    if ((element.Competition_engagee.Date_debut_evenement >= this.Date_debut_evenement) && (element.Competition_engagee.Date_debut_evenement <= this.Date_fin_evenement)
                        || (element.Competition_engagee.Date_fin_evenement >= this.Date_debut_evenement) && (element.Competition_engagee.Date_fin_evenement <= this.Date_fin_evenement)
                        || (element.Competition_engagee.Date_debut_evenement <= this.Date_debut_evenement) && (element.Competition_engagee.Date_fin_evenement >= this.Date_fin_evenement))
                    {
                        Ajout_reussi = false;
                    }
                }
            }
            return Ajout_reussi;
        }
        public Entraineur Ajout_entraineur()
        {
            Entraineur ajout=null; 
            foreach (Entraineur element in this.orga.Liste_Entraineur)
            {
                if((ajout==null)&&Ajout_Membre(element))
                {
                    ajout = element;
                }
            }
            return ajout;
        }
    }
}
