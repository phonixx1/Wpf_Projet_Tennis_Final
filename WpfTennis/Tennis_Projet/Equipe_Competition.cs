using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    /// <summary>
    /// Dasn cette classe on gere l'ajout d'un membre a une competition donc on verifie les paramtres du membres et on definit sil peut ou
    /// non participer a la competition pour laquelle l'equipe est enagée
    /// </summary>
    public class Equipe_Competition
    {
        Competition competition_engagee;
        Membre capitaine;
        List<Membre> composition_Equipe=new List<Membre>();
        int[] tab_points_joueurs;  // point par joueur
        int points_equipe;// point dequipe

        #region Constructeurs
        public Equipe_Competition( Competition compet) // dans ce cas le capitaine sera le premier membre ajouté a lequipe
        {
            this.competition_engagee = compet;
            

        }
        public Equipe_Competition(Membre cptn, Competition compet) // on cree l'equipe avec le capitaine il choisira le reste de lequipe plus tard ou prend son tps pour selectionner
                                                                   // et la compet car une equipe s'engage pour une compet
        {
            this.competition_engagee = compet;
            if (Ajouter_un_membre(cptn))
            {
                this.capitaine = cptn;
            }
            else
            {
                this.capitaine = null;
            }
            
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
        #endregion
        #region Proprietes
        public Membre Capitaine
        {
            get { return capitaine; }
            set { this.capitaine = value; }
        }
        
        public Competition Competition_engagee
        {
            get { return competition_engagee; }
        }
       
        public List<Membre> Composition_Equipe
        {
            get { return composition_Equipe; }
        }
        public int Points_Equipe
        {
            get { return points_equipe; }
            set { this.points_equipe = value; }
        }
        #endregion
        public void Ajout_Points(int indice_joueur, int points)
        {
            tab_points_joueurs[indice_joueur] += points;
            points_equipe += points;
        }
        public void FaireAjoutUnMembre(Membre aAjouter)
        {
            this.composition_Equipe.Add(aAjouter);
            aAjouter.Equipes.Add(this);
        }
        public bool Ajouter_un_membre(Membre A_Ajouter)// test plein de condition pour voir si on peut ajouter un membre a la competition

        {
            bool Ajout_reussi=false;
            if (A_Ajouter.Calcul_age() < 18)
            {
                if ((A_Ajouter.Calcul_age() == this.competition_engagee.Tranche_age) || (A_Ajouter.Calcul_age() == this.competition_engagee.Tranche_age + 1))
                {
                    if ((A_Ajouter.Sexe.ToLower() == "f" && (this.competition_engagee.TypeCompetition == "simple femme" || this.competition_engagee.TypeCompetition == "double femme" || this.competition_engagee.TypeCompetition == "equipe femme"))
                        || (A_Ajouter.Sexe.ToLower() == "m" && (this.competition_engagee.TypeCompetition == "simple homme" || this.competition_engagee.TypeCompetition == "double homme" || this.competition_engagee.TypeCompetition == "equipe homme")))
                    {
                        Ajout_reussi = true;
                        foreach (Equipe_Competition element in A_Ajouter.Equipes)
                        {
                            if ((element.competition_engagee.Date_debut_evenement >= this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_debut_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.competition_engagee.Date_fin_evenement >= this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_fin_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.competition_engagee.Date_debut_evenement <= this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_fin_evenement >= this.competition_engagee.Date_fin_evenement))
                            {
                                Ajout_reussi = false;
                            }
                        }
                        foreach (Stage element in A_Ajouter.Stage)
                        {
                            if ((element.Date_debut_evenement >= this.competition_engagee.Date_debut_evenement) && (element.Date_debut_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.Date_fin_evenement >= this.competition_engagee.Date_debut_evenement) && (element.Date_fin_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.Date_debut_evenement <= this.competition_engagee.Date_debut_evenement) && (element.Date_fin_evenement >= this.competition_engagee.Date_fin_evenement))
                            {
                                Ajout_reussi = false;
                            }
                        }
                    }
                }

            }
            else
            {
                if ((A_Ajouter.Calcul_age() >= this.competition_engagee.Tranche_age)&&(A_Ajouter.Calcul_age() <= (this.competition_engagee.Tranche_age+10)))
                {
                    if ((A_Ajouter.Sexe.ToLower()=="f"&&(this.competition_engagee.TypeCompetition=="simple femme"|| this.competition_engagee.TypeCompetition == "double femme" || this.competition_engagee.TypeCompetition == "equipe femme"))
                        || (A_Ajouter.Sexe.ToLower() == "m" && (this.competition_engagee.TypeCompetition == "simple homme" || this.competition_engagee.TypeCompetition == "double homme" || this.competition_engagee.TypeCompetition == "equipe homme")))
                    {
                        Ajout_reussi = true;
                        foreach (Equipe_Competition element in A_Ajouter.Equipes)
                        {
                            if ((element.competition_engagee.Date_debut_evenement >= this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_debut_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.competition_engagee.Date_fin_evenement >= this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_fin_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.competition_engagee.Date_debut_evenement <= this.competition_engagee.Date_debut_evenement) && (element.competition_engagee.Date_fin_evenement >= this.competition_engagee.Date_fin_evenement))
                            {
                                Ajout_reussi = false;
                            }
                        }
                        foreach (Stage element in A_Ajouter.Stage)
                        {
                            if ((element.Date_debut_evenement >= this.competition_engagee.Date_debut_evenement) && (element.Date_debut_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.Date_fin_evenement >= this.competition_engagee.Date_debut_evenement) && (element.Date_fin_evenement <= this.competition_engagee.Date_fin_evenement)
                                || (element.Date_debut_evenement <= this.competition_engagee.Date_debut_evenement) && (element.Date_fin_evenement >= this.competition_engagee.Date_fin_evenement))
                            {
                                Ajout_reussi = false;
                            }
                        }
                    }
                }
            }
            return Ajout_reussi;

        }
    }
}
