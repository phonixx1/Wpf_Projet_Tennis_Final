using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Competition : Evenement , IEquatable<Competition>
    {
        bool compet_finie = false;
        Club club_organisateur;
        int tranche_age; // on peut participer tant que age >= tranche age pour le cas ou tranche > 18
                         // si tranche d'age <18 on a plein de petite tranche d'age si tranche d'age =11 alors c'est bon si le joueur a 11/12 ans
                         // si tranche d'age =13 alors 13/14 ans 15 ->15/16ans; 17->17/18 ans

        string niveau_france; // region departement national

        int nb_joueur;

        double classement_max;

        string type_competition; // simple homme ; simple femme
                                 // double homme ; double femme
                                 // equipe homme ; equipe femme
                                 // verification a faire au cas où aucune de ces chaine ne soit mise en param
                                 

        List<Equipe_Competition> equipes_participantes;
        List<Match> liste_match;
        List<Membre> joueur_a_deja_joue=null;  //stock les joueurs qui ont deja joué (car un joueur ne peut jouer qu'une fois par compet)
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

        public bool Compet_finie
        {
            get { return compet_finie; }
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
        public int Nb_Joueur
        {
            get { return nb_joueur; }
        }
        public string TypeCompetition
        {
            get { return this.type_competition; }
        }
       public bool Ajouter_Equipe(Equipe_Competition equipe_Aajouter) // return true si l'equipe a ete ajouter false sinn
        {
            bool ajout_reussi=false;
            if(this==equipe_Aajouter.Competition_engagee && equipe_Aajouter.Composition_Equipe.Count == nb_joueur)
            {
                ajout_reussi = true;
            }

            return ajout_reussi;
        }
        /*
        public void Ajouter_Match_Simple(Equipe_Competition equipe1, Equipe_Competition equipe2, int indice_joueur_equipe1, int  indice_joueur_equipe2)
        {
            //bool type_match_adapte = Type_Match_adapte(1);
            //bool joueur1_dispo = Joueur_dispo(equipe1,indice_joueur_equipe1);
            //bool joueur2_dispo = Joueur_dispo(equipe2, indice_joueur_equipe2);
            //if (joueur1_dispo == true && joueur2_dispo == true && type_match_adapte == true)
            //{
                liste_match.Add(new Match_Simple(equipe1, equipe2, indice_joueur_equipe1, indice_joueur_equipe2));
            //}
        }
        public void Ajouter_Match_Double(Equipe_Competition equipe1, Equipe_Competition equipe2, int indice_joueur1_equipe1, int indice_joueur1_equipe2, int indice_joueur2_equipe1, int indice_joueur2_equipe2)
        {
            liste_match.Add(new Match_Double(equipe1, equipe2, indice_joueur1_equipe1, indice_joueur1_equipe2,indice_joueur2_equipe1,indice_joueur2_equipe2));  
        }
        public bool Type_Match_adapte(int type_match) //1 pour match simple, 2 pour match double
        {
            bool type_match_adapte = true;
            if (type_competition != "equipe homme" || type_competition != "equipe femme")
            {
                if (type_match == 1)
                {
                    if (type_competition == "double homme" || type_competition == "double femme")
                    {
                        type_match_adapte = false;
                    }
                }
                if (type_match == 2)
                {
                    if (type_competition == "simple homme" || type_competition == "simple femme")
                    {
                        type_match_adapte = false;
                    }
                }
            }
            return type_match_adapte;
        }
        public int Generer_aleatoire(int a, int b)
        {
            Random aleatoire = new Random();
            int nb_aleatoire = aleatoire.Next(a,b);
            return nb_aleatoire;
        }
        public int[] Creation_tab_indice_joueurs_aleatoire(Random aleatoire)
        {
            int[] tab_aleatoire = new int[nb_joueur];
            int[] tab_indice_indispo = new int[nb_joueur];
            for (int k = 0; k < tab_indice_indispo.Length; k++)
            {
                tab_indice_indispo[k] = -1;
            }
            int indice_aleatoire = 10;
            for (int i = 0; i < nb_joueur; i++)
            {
                int dispo = 1;
                while (dispo != 0)
                {
                    indice_aleatoire = aleatoire.Next(0, nb_joueur );
                    for (int j = 0; j < nb_joueur; j++)
                    {
                        if (tab_indice_indispo[j] == indice_aleatoire)
                        {
                            dispo += 1;
                        }
                    }
                    dispo = dispo - 1;
                }
                tab_indice_indispo[i] = indice_aleatoire;
                tab_aleatoire[i] = indice_aleatoire;
            }
            for (int m = 0; m < tab_aleatoire.Length; m++)
            {
                Console.Write("=" + tab_aleatoire[m]);
            }
            Console.WriteLine("---");
            return tab_aleatoire;
        }
        //public Equipe_Competition Lancement_Compet()
        //{
            //for (int i = 0; i < liste_match.Count; i++)
            //{
                //Ajout_Point
           // }
       // }
        public bool Joueur_dispo(Equipe_Competition equipe, int indice_joueur_equipe)
        {
            bool joueur_dispo = true;
            for (int i = 0; i < joueur_a_deja_joue.Count; i++)
            {
                if (equipe.Composition_Equipe[indice_joueur_equipe] == joueur_a_deja_joue[i])
                {
                    joueur_dispo = false; 
                }
            }
            return joueur_dispo;
        }
        public void Creation_Liste_Match2()
        {
            List < int > liste_nombre_restants = new List<int>();
            for (int i = 0; i<equipes_participantes.Count * nb_joueur ;i++)
            {
                liste_nombre_restants.Add(i);
                Console.WriteLine(liste_nombre_restants[i]);
            }

        }
        public void Creation_Liste_Match()
        {
           // Console.WriteLine("a");
            int[,] matrice_indices_joueur = new int [equipes_participantes.Count, nb_joueur];
            Random aleatoire = new Random();
            for (int i = 0; i < equipes_participantes.Count; i++)
            {
               // Console.WriteLine("b");
                int[] tab_indice_aleatoire = Creation_tab_indice_joueurs_aleatoire(aleatoire);
                for (int j = 0; j<nb_joueur; j++)
                {
                   // Console.WriteLine("c");
                    matrice_indices_joueur[i, j] = tab_indice_aleatoire[j];
                }
            }
            if (type_competition == "simple homme" || type_competition == "simple femme")
            {
               //Console.WriteLine("d");
               for (int i = 0; i<matrice_indices_joueur.GetLength(0); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < matrice_indices_joueur.GetLength(1); j++)
                    {
                        Console.Write("-" + matrice_indices_joueur[i, j]);
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < matrice_indices_joueur.GetLength(0) ; i++)
                {
                    for (int j = i; j < matrice_indices_joueur.GetLength(1) ; j++)
                    {
                       // Console.WriteLine(equipes_participantes[i].Capitaine.Nom);
                       // Console.WriteLine(equipes_participantes[j].Capitaine.Nom);
                        Console.WriteLine(matrice_indices_joueur[i, j] + " = " + matrice_indices_joueur[j, i]);
                        Ajouter_Match_Simple(equipes_participantes[i], equipes_participantes[j], matrice_indices_joueur[i, j], matrice_indices_joueur[j, i]);
                        Console.WriteLine("Match x");
                       // Console.WriteLine(":" + i);
                    }
                }
            }
            if (type_competition == "double homme" || type_competition == "double femme")  //A tester
            {
                Console.WriteLine("d");
                for (int i = 0; i < equipes_participantes.Count; i++)
                {
                    for (int j = i + 1; j < nb_joueur; j++)
                    {
                        //Console.WriteLine(equipes_participantes[i].Capitaine.Nom);
                        //Console.WriteLine(equipes_participantes[j].Capitaine.Nom);
                        Console.WriteLine(matrice_indices_joueur[i, j] + " = " + matrice_indices_joueur[j, i]);
                        Console.WriteLine(matrice_indices_joueur[i, j+1] + " = " + matrice_indices_joueur[j, i+1]);
                        Console.WriteLine("-----");
                        Ajouter_Match_Double(equipes_participantes[i], equipes_participantes[j], matrice_indices_joueur[i, j], matrice_indices_joueur[j, i],matrice_indices_joueur[i,j+1],matrice_indices_joueur[j,i+1]);
                        //Console.WriteLine(":" + i);
                    }
                }
            }
            if (type_competition == "equipe homme" || type_competition == "equipe femme")
            {
                //for (int i = 0; i<)
            }
        }
        public int[] Calcul_nb_match(int nb_joueur)
        {
            int[] nb_match = new int[2];
            while(nb_match[0] + nb_match[1] < nb_joueur - 1)
            {
                int choix = Generer_aleatoire(1, 3);
                if (choix == 1)
                {
                    nb_match[0] = nb_match[0] + 1;
                }
                if (choix == 2)
                {
                    nb_match[1] = nb_match[1] + 2;
                }
            }
            while(nb_match[0] + nb_match[1] != nb_joueur)
            {
                nb_match[0] = nb_match[0] + 1;
            }
            return nb_match;
        }
        public int Nb_matchs_double(int nb_joueur,int nb_equipes_participantes)
        {
            Random aleatoire = new Random();
            int nb_match_double = aleatoire.Next(1, nb_joueur * nb_equipes_participantes / 2);
            return nb_match_double;
        }
        #region equals et operaator
        
        public override bool Equals(object obj)
        {
            Competition other = (Competition)obj;
            return ((this.nom_de_evenement == other.nom_de_evenement) && (this.date_debut_evenement == other.date_debut_evenement) && (this.date_fin_evenement == other.date_fin_evenement) && (this.niveau_france == other.niveau_france) && (this.tranche_age == other.tranche_age));

        }
        public override int GetHashCode() // gethashcode cest l'identite de competition
        {
            string identite;
            identite = this.nom_de_evenement + this.date_debut_evenement + this.date_fin_evenement + this.niveau_france + this.tranche_age;
            return identite.GetHashCode();
        }

        public static bool operator ==(Competition compet1,Competition compet2)
        {
            return compet1.Equals(compet2);
        }
        public static bool operator !=(Competition compet1, Competition compet2)
        {
            return !(compet1.Equals(compet2));
        }*/
        public bool Equals(Competition other) // 2compet egales si meme nom, dates, niveau et tranche age
        {
            return ((this.nom_de_evenement == other.nom_de_evenement) && (this.date_debut_evenement == other.date_debut_evenement) && (this.date_fin_evenement == other.date_fin_evenement)&&(this.niveau_france==other.niveau_france)&&(this.tranche_age==other.tranche_age));
        }
       //#endregion



    


    }


}
