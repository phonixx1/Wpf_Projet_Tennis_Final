using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Equipe_Competition
    {
        /*Competition competition_engagee;
        Membre capitaine;
        List<Membre> composition_Equipe;
        int[] tab_points_joueurs;
        int points_equipe;
        
        public Equipe_Competition(Membre cptn, Competition compet) // on cree l'equipe avec le capitaine il choisira le reste de lequipe plus tard ou prend son tps pour selectionner
                                                                   // et la compet car une equipe s'engage pour une compet
        {

            this.capitaine = cptn;
            this.competition_engagee = compet;
        }
        public Equipe_Competition(Membre cptn, Competition compet, List<Membre> equipe)
        {
            this.capitaine = cptn;
            this.competition_engagee = compet;
            foreach (Membre element in equipe)
            {
                if (!this.Ajouter_un_membre(element))
                {
                    Console.WriteLine("Erreur : Un membre de la liste ne peut pas participer a la compet");
                    this.composition_Equipe = null;
                }
            }
            if (this.composition_Equipe != null)
            {
                this.tab_points_joueurs = new int[composition_Equipe.Count];
                this.composition_Equipe = equipe;
                composition_Equipe.Add(cptn);
                foreach(Membre element in equipe)
                {
                    element.Equipes.Add(this);
                }
            }
        }
        public Competition Competition_engagee
        {
            get { return competition_engagee; }
        }
        public Membre Capitaine
        {
            get { return capitaine; }
        }
        public List<Membre> Composition_Equipe
        {
            get { return composition_Equipe; }
        }
        public void Ajout_Points(int indice_joueur, int points)
        {
            tab_points_joueurs[indice_joueur] += points;
            points_equipe += points;
        }
        
        bool Ajouter_un_membre(Membre A_Ajouter)
        {
            bool Ajout_reussi=false;
            if (A_Ajouter.Calcul_age() < 18)
            {
                if ((A_Ajouter.Calcul_age() == this.competition_engagee.Tranche_age) || (A_Ajouter.Calcul_age() == this.competition_engagee.Tranche_age + 1))
                {
                    Ajout_reussi = true;
                    foreach (Equipe_Competition element in A_Ajouter.Equipes)
                    {
                        if ((element.competition_engagee.Date_debut_evenement > this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_debut_evenement < this.competition_engagee.Date_fin_evenement)
                            || (element.competition_engagee.Date_fin_evenement > this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_fin_evenement < this.competition_engagee.Date_fin_evenement))
                        {
                            Ajout_reussi = false;
                        }
                    }
                }

            }
            else
            {
                if ((A_Ajouter.Calcul_age() >= this.competition_engagee.Tranche_age)&&(A_Ajouter.Calcul_age() <= this.competition_engagee.Tranche_age+10))
                {
                    Ajout_reussi = true;
                    foreach (Equipe_Competition element in A_Ajouter.Equipes)
                    {
                        if ((element.competition_engagee.Date_debut_evenement > this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_debut_evenement < this.competition_engagee.Date_fin_evenement)
                            || (element.competition_engagee.Date_fin_evenement > this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_fin_evenement < this.competition_engagee.Date_fin_evenement)
                            || (element.competition_engagee.Date_debut_evenement< this.competition_engagee.Date_debut_evenement)&&(element.competition_engagee.Date_fin_evenement > this.competition_engagee.Date_fin_evenement))
                        {
                            Ajout_reussi = false;
                        }
                    }
                }
            }
            return Ajout_reussi;

        }*/
    }
}
