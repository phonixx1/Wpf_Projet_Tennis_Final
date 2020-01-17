using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Une des grosses classes class du projet qui herite de evenement
    /// Cette class gere tous les aspects d'une competition
    /// </summary>
    public class Competition : Evenement , IEquatable<Competition>
    {
        bool compet_finie = false;
        Club club_organisateur;
        int tranche_age; // on peut participer tant que age >= tranche age pour le cas ou tranche > 18
                         // si tranche d'age <18 on a plein de petite tranche d'age si tranche d'age =11 alors c'est bon si le joueur a 11/12 ans
                         // si tranche d'age =13 alors 13/14 ans 15 ->15/16ans; 17->17/18 ans

        string niveau_france; // region departement national

        int nb_joueur; // nb de joueur par equipe dans cette competition

        double classement_max;

        string type_competition; // simple homme ; simple femme
                                 // double homme ; double femme
                                 // equipe homme ; equipe femme
                                 // verification a faire au cas où aucune de ces chaine ne soit mise en param
                                 

        List<Equipe_Competition> equipes_participantes;
        List<Match> liste_match;
        List<Membre> listeMembreGagnant = new List<Membre>();

        #region Constructeurs
        public Competition(string nom, int prix, DateTime debut, TimeSpan duree,Club organisateur,string type_competition,int tranche_age,string niveau,int nb_joueur,double classement_max) 
            : base(nom, prix, debut, duree)
        {
            equipes_participantes = new List<Equipe_Competition>();
            liste_match = new List<Match>();
            this.club_organisateur = organisateur;
            this.tranche_age = tranche_age;
            this.niveau_france = niveau;
            this.nb_joueur = nb_joueur;
            this.classement_max = classement_max;
            this.type_competition = type_competition.ToLower();
            
        }
        public Competition(string nom, int prix, DateTime debut, TimeSpan duree, Club organisateur, string type_competition, int tranche_age, string niveau, int nb_joueur, double classement_max,List<Equipe_Competition> equipes)
            : base(nom, prix, debut, duree)
        {
            equipes_participantes = new List<Equipe_Competition>();
            liste_match = new List<Match>();
            this.club_organisateur = organisateur;
            this.tranche_age = tranche_age;
            this.niveau_france = niveau;
            this.nb_joueur = nb_joueur;
            this.classement_max = classement_max;
            this.type_competition = type_competition.ToLower();
            this.equipes_participantes = equipes;
            
        }
        #endregion
        #region proprietes
        public List<Membre> ListeMembreGagnant
        {
            get { return this.listeMembreGagnant; }
            set { this.listeMembreGagnant = value; }
        }
        public bool Compet_finie
        {
            get { return compet_finie; }
            set { this.compet_finie = value; }
        }
        public int Tranche_age
        {
            get { return this.tranche_age; }
        }
        public List<Equipe_Competition> Equipe_participante
        {
            get { return this.equipes_participantes; }
            set { this.equipes_participantes = value; }
        }
        public List<Match> Liste_match
        {
            get { return this.liste_match; }
        }
        public int Nb_Joueur
        {
            get { return nb_joueur; }
        }
        public string TypeCompetition
        {
            get { return this.type_competition; }
            
        }
        #endregion

        #region Ajouts d'equipes, de matchs et veirifications diverses 
        public bool Ajouter_Equipe(Equipe_Competition equipe_Aajouter) // return true si l'equipe peut etre ajoutée false sinn
        {
            bool ajout_reussi=false;
            if(this==equipe_Aajouter.Competition_engagee && equipe_Aajouter.Composition_Equipe.Count == nb_joueur)
            {
                ajout_reussi = true;
            }

            return ajout_reussi;
        }

        public void Ajouter_Match_Simple(Equipe_Competition equipe1, Equipe_Competition equipe2, int indice_joueur_equipe1, int indice_joueur_equipe2)
        {
            liste_match.Add(new Match_Simple(equipe1, equipe2, indice_joueur_equipe1, indice_joueur_equipe2, "match simple"));
        }
        public void Ajouter_Match_Double(Equipe_Competition equipe1, Equipe_Competition equipe2, int indice_joueur1_equipe1, int indice_joueur1_equipe2, int indice_joueur2_equipe1, int indice_joueur2_equipe2)
        {
            liste_match.Add(new Match_Double(equipe1, equipe2, indice_joueur1_equipe1, indice_joueur1_equipe2, indice_joueur2_equipe1, indice_joueur2_equipe2, "match double"));
        }

        /// <summary>
        /// foction crée pour lancer une competition qui a ete change dans la section wpf
        /// </summary>
        
        public void Lancement_Compet(List<Equipe_Competition> equipe_gagnante, List<Membre> membre_gagnant)
        {
            Match_Simple test_match_simple = new Match_Simple();
            Match_Double test_match_double = new Match_Double();
            List<Match_Simple> liste_match_simple = new List<Match_Simple>();
            List<Match_Double> liste_match_double = new List<Match_Double>();
            int indice_liste_match_simple = 0;
            int indice_liste_match_double = 0;
            int indice_membre_gagnant = 0;
            for (int i = 0; i < liste_match.Count; i++)
            {
                if (liste_match[i].Type_match == "match simple")
                {
                    liste_match_simple.Add((Match_Simple)liste_match[i]);
                    liste_match_simple[indice_liste_match_simple].Ajout_point1(membre_gagnant[indice_membre_gagnant], equipe_gagnante[i]);
                    indice_liste_match_simple++;
                    indice_membre_gagnant++;
                }
                if (liste_match[i].Type_match == "match double")
                {
                    liste_match_double.Add((Match_Double)liste_match[i]);
                    liste_match_double[indice_liste_match_double].Ajout_point2(membre_gagnant[indice_membre_gagnant], membre_gagnant[indice_membre_gagnant + 1], equipe_gagnante[i]);
                    indice_liste_match_double++;
                    indice_membre_gagnant = indice_membre_gagnant + 2; ;
                }
            }
            compet_finie = true;
        }
        /// <summary>
        /// les 3 fonctions qui suivent verifie si un joueur n'est pas deje assigné dans un match 
        /// car un joueur peut jouer qu'une seule fois par competition
        /// </summary>
        
        public bool Nb_dispo1(int nb_aleatoire, List<int> liste_nombre_restants)
        {
            bool dispo = false;
            for (int i = 0; i < liste_nombre_restants.Count; i++)
            {
                if (nb_aleatoire == liste_nombre_restants[i])
                {
                    dispo = true;
                    liste_nombre_restants[i] = -1;
                }
            }
            return dispo;
        }
        public bool Nb_dispo2(int nb_aleatoire, List<int> liste_nombre_restants, int indice_equipe1, int indice_equipe2)
        {
            bool dispo = false;
            for (int i = 0; i < liste_nombre_restants.Count; i++)
            {
                if (nb_aleatoire == liste_nombre_restants[i] && indice_equipe1 != indice_equipe2)
                {
                    dispo = true;
                    liste_nombre_restants[i] = -1;
                }
            }
            return dispo;
        }

        public int Nb_dispo_double(int nb_aleatoire1, List<int> liste_nombre_restants)
        {
            int indice = -1;
            for (int i = 0; i < liste_nombre_restants.Count; i++)
            {
                if (nb_aleatoire1 == liste_nombre_restants[i])
                {
                    indice = i;
                }
            }
            return indice;
        }
        #endregion

        /// <summary>
        /// c'est dans cette fonction que notre liste de match est crée pour une competition
        /// elle crée des matchs aleatoirement en verifiant que les membres ne soit pas de la meme equipes
        /// et surtout en fonction du type de competition qui se deroule
        /// </summary>
        public void Creation_Liste_Match()
        {
            int nb_aleatoire1;
            int nb_aleatoire2;
            int indice_equipe1;
            int indice_joueur1;
            int indice_equipe2;
            int indice_joueur2;
            int nb_aleatoire3;
            int nb_aleatoire4;
            List<int> liste_nombre_possible = new List<int>();
            for (int i = 0; i < equipes_participantes.Count * nb_joueur; i++)
            {
                liste_nombre_possible.Add(i);
            }
            Random aleatoire = new Random();
            if (type_competition == "simple homme" || type_competition == "simple femme")
            {
                for (int j = 0; j < equipes_participantes.Count * nb_joueur / 2; j++)
                {
                    do
                    {
                        nb_aleatoire1 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe1 = nb_aleatoire1 / nb_joueur;
                        indice_joueur1 = nb_aleatoire1 % nb_joueur;
                    } while (Nb_dispo1(nb_aleatoire1, liste_nombre_possible) == false);
                    do
                    {
                        nb_aleatoire2 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe2 = nb_aleatoire2 / nb_joueur;
                        indice_joueur2 = nb_aleatoire2 % nb_joueur;
                    } while (Nb_dispo2(nb_aleatoire2, liste_nombre_possible, indice_equipe1, indice_equipe2) == false);
                    Ajouter_Match_Simple(equipes_participantes[indice_equipe1], equipes_participantes[indice_equipe2], indice_joueur1, indice_joueur2);
                }
            }
            if (type_competition == "double homme" || type_competition == "double femme")
            {
                for (int j = 0; j < (equipes_participantes.Count * nb_joueur) / 4; j++)
                {
                    do
                    {
                        nb_aleatoire1 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe1 = nb_aleatoire1 / nb_joueur;
                        indice_joueur1 = nb_aleatoire1 % nb_joueur;
                        nb_aleatoire3 = indice_equipe1 * nb_joueur;
                        if (nb_aleatoire3 == nb_aleatoire1)
                        {
                            nb_aleatoire3 = nb_aleatoire1 + 1;
                        }
                        if (Nb_dispo_double(nb_aleatoire1, liste_nombre_possible) != -1)
                        {
                            while (Nb_dispo_double(nb_aleatoire3, liste_nombre_possible) == -1)
                            {
                                nb_aleatoire3++;
                                if (nb_aleatoire3 == nb_aleatoire1)
                                {
                                    nb_aleatoire3 = nb_aleatoire3 + 1;
                                }
                            }
                        }
                    } while (Nb_dispo_double(nb_aleatoire1, liste_nombre_possible) == -1);
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire3, liste_nombre_possible)] = -1;
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire1, liste_nombre_possible)] = -1;
                    do
                    {
                        nb_aleatoire2 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe2 = nb_aleatoire2 / nb_joueur;
                        indice_joueur2 = nb_aleatoire2 % nb_joueur;
                        nb_aleatoire4 = indice_equipe2 * nb_joueur;
                        if (nb_aleatoire4 == nb_aleatoire2)
                        {
                            nb_aleatoire4 = nb_aleatoire2 + 1;
                        }
                        if (Nb_dispo_double(nb_aleatoire2, liste_nombre_possible) != -1)
                        {
                            while (Nb_dispo_double(nb_aleatoire4, liste_nombre_possible) == -1)
                            {
                                nb_aleatoire4++;
                                if (nb_aleatoire4 == nb_aleatoire2)
                                {
                                    nb_aleatoire4 = nb_aleatoire4 + 1;
                                }
                            }
                        }
                    } while (Nb_dispo_double(nb_aleatoire2, liste_nombre_possible) == -1 || indice_equipe1 == indice_equipe2);
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire4, liste_nombre_possible)] = -1;
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire2, liste_nombre_possible)] = -1;
                    Ajouter_Match_Double(equipes_participantes[indice_equipe1], equipes_participantes[indice_equipe2], indice_joueur1, indice_joueur2, nb_aleatoire3 % nb_joueur, nb_aleatoire4 % nb_joueur);
                }
            }
            if (type_competition == "equipe homme" || type_competition == "equipe femme")
            {
                //Random match_double = new Random();
                //int nb_match_double = match_double.Next(1, ((Equipe_participante.Count * nb_joueur) / 4)+1);
                int nb_match_double = aleatoire.Next(1, ((Equipe_participante.Count * nb_joueur) / 4) + 1);
                int nb_match_simple = ((Equipe_participante.Count * nb_joueur) - (nb_match_double * 4)) / 2;
                int compteur;
                for (int j = 0; j < nb_match_double; j++)
                {
                    do
                    {
                        compteur = 0;
                        nb_aleatoire1 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe1 = nb_aleatoire1 / nb_joueur;
                        indice_joueur1 = nb_aleatoire1 % nb_joueur;
                        nb_aleatoire3 = indice_equipe1 * nb_joueur;
                        if (nb_aleatoire3 == nb_aleatoire1)
                        {
                            nb_aleatoire3 = nb_aleatoire1 + 1;
                        }
                        if (Nb_dispo_double(nb_aleatoire1, liste_nombre_possible) != -1)
                        {
                            while ((Nb_dispo_double(nb_aleatoire3, liste_nombre_possible) == -1)&&(compteur<=nb_joueur))
                            {
                                nb_aleatoire3++;
                                if (nb_aleatoire3 == nb_aleatoire1)
                                {
                                    nb_aleatoire3 = nb_aleatoire3 + 1;
                                }
                                compteur++;
                            }
                        }
                    } while (Nb_dispo_double(nb_aleatoire1, liste_nombre_possible) == -1);
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire3, liste_nombre_possible)] = -1;
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire1, liste_nombre_possible)] = -1;
                    do
                    {
                        compteur = 0;
                        nb_aleatoire2 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe2 = nb_aleatoire2 / nb_joueur;
                        indice_joueur2 = nb_aleatoire2 % nb_joueur;
                        nb_aleatoire4 = indice_equipe2 * nb_joueur;
                        if (nb_aleatoire4 == nb_aleatoire2)
                        {
                            nb_aleatoire4 = nb_aleatoire2 + 1;
                        }
                        if (Nb_dispo_double(nb_aleatoire2, liste_nombre_possible) != -1)
                        {
                            while ((Nb_dispo_double(nb_aleatoire4, liste_nombre_possible) == -1)&& (compteur <= nb_joueur))
                            {
                                nb_aleatoire4++;
                                if (nb_aleatoire4 == nb_aleatoire2)
                                {
                                    nb_aleatoire4 = nb_aleatoire4 + 1;
                                }
                                compteur++;
                            }
                        }
                    } while (Nb_dispo_double(nb_aleatoire2, liste_nombre_possible) == -1 || indice_equipe1 == indice_equipe2);
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire4, liste_nombre_possible)] = -1;
                    liste_nombre_possible[Nb_dispo_double(nb_aleatoire2, liste_nombre_possible)] = -1;
                    Ajouter_Match_Double(equipes_participantes[indice_equipe1], equipes_participantes[indice_equipe2], indice_joueur1, indice_joueur2, nb_aleatoire3 % nb_joueur, nb_aleatoire4 % nb_joueur);
                }
                for (int j = 0; j < nb_match_simple; j++)
                {
                    do
                    {
                        nb_aleatoire1 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe1 = nb_aleatoire1 / nb_joueur;
                        indice_joueur1 = nb_aleatoire1 % nb_joueur;
                    } while (Nb_dispo1(nb_aleatoire1, liste_nombre_possible) == false);
                    do
                    {
                        nb_aleatoire2 = aleatoire.Next(0, liste_nombre_possible.Count);
                        indice_equipe2 = nb_aleatoire2 / nb_joueur;
                        indice_joueur2 = nb_aleatoire2 % nb_joueur;
                    } while (Nb_dispo2(nb_aleatoire2, liste_nombre_possible, indice_equipe1, indice_equipe2) == false);
                    Ajouter_Match_Simple(equipes_participantes[indice_equipe1], equipes_participantes[indice_equipe2], indice_joueur1, indice_joueur2);
                }
            }
        }

        public bool Equals(Competition other) // 2compet egales si meme nom, dates, niveau et tranche age
        {
            return ((this.nom_de_evenement == other.nom_de_evenement) && (this.date_debut_evenement == other.date_debut_evenement) && (this.date_fin_evenement == other.date_fin_evenement) && (this.niveau_france == other.niveau_france) && (this.tranche_age == other.tranche_age));
        }
        
        






    }


}
