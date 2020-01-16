using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ConsoleApp1
    
{
    /// <summary>
    /// Class la plus complete on a tous les parametres dun membre avec ses proprietes 
    /// certaine fonction comme l'ajout dargent sur un compte ne sont pas utilise car on a pas eu le temps de le mettre sur wpf
    /// on retrouve aussi une delegation pour les tris les focntions de calculs des points dun membre ect
    /// </summary>
    /// 
    public delegate int Comparison(Membre x, Membre y);   // delegation tri 
    public class Membre : Personne,IComparable<Membre>,IEquatable<Membre>, IToString
    {

        double competition = double.NaN; // NaN si pas de compet

        List<Equipe_Competition> equipes=new List<Equipe_Competition>(); // liste des equipes dans lesquelles le joueur est
        List<Cours> liste_cours=new List<Cours>();
        List<Stage> stage=new List<Stage>();
        int argent_total_compte_membre; // l'argent que le membre a mis sur son compte ( ca peut etre pour payer la cotis ou evenements)

        bool cotisastion_payee; // true si payee false sinn

        Club nom_du_club_affilie;// club où le joueur est affilié

        int nb_victoires_simple = 0;
        int nb_victoires_double = 0;


        #region Constructeurs
        public Membre(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance,string numero_telephone, Club nom_du_club,int argent_depart, double competition)
            :base(nom,prenom,sexe,adresse,ville,date_naissance,numero_telephone)
        {
            this.competition = competition;
            this.argent_total_compte_membre = argent_depart;
            this.nom_du_club_affilie = nom_du_club;
            cotisastion_payee = Essai_Paiement_Cotisation();
        }
        public Membre(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance, string numero_telephone, Club nom_du_club, int argent_depart, double competition,bool cotisation)
            : base(nom, prenom, sexe, adresse, ville, date_naissance,numero_telephone)
        {
            this.competition = competition;
            this.argent_total_compte_membre = argent_depart;
            this.nom_du_club_affilie = nom_du_club;
            this.cotisastion_payee = cotisation;
        }
        #endregion

        #region Proprietes
        public string Nom
        {
            get { return this.nom; }
            
        }
        public string Prenom
        {
            get { return this.prenom; }
            
        }
        public string Sexe
        {
            get { return this.sexe; }
            
        }
        public string Adresse
        {
            get { return this.adresse; }
            set
            {
                this.adresse = value;
            }
        }
        public string Ville
        {
            get { return this.ville; }
            set
            {
                this.ville = value;
            }
        }
        public DateTime Date_naissance
        {
            get { return (this.date_naissance.Date); }
                   
        }
        public string Numero_Telephone
        {
            get { return this.numero_telephone; }
            set { this.numero_telephone = value; }
        }
        public Club Club_Affilie
        {
            get { return this.nom_du_club_affilie; }
            set { this.nom_du_club_affilie = value; }
        }
        public int Argent_membre
        {
            get { return argent_total_compte_membre; }
            set
            {
                this.argent_total_compte_membre = value;
            }    
        }
        public double Competition
        {
            get { return this.competition; }
            set
            {
                this.competition = value;
            }     
        }
        public bool Cotisation
        {
            get { return this.cotisastion_payee; }
            set
            {
                this.cotisastion_payee = value;
            }
        }
        public int Nb_Victoires
        {
            get { return this.nb_victoires_double+this.nb_victoires_simple; }
           
        }
        public int Nb_Defaites
        {
            get { return Calcul_nb_defaite(); }
        }
        public int NbPointGagne
        {
            get { return Calcul_points(); }
        }
        public int NbVicSimple
        {
            get
            {
                return this.nb_victoires_simple;
            }
            set
            {
                this.nb_victoires_simple=value;
            }
        }
        public int NbVicDouble
        {
            get
            {
                return this.nb_victoires_double;
            }
            set
            {
                this.nb_victoires_double = value;
            }
        }
        public List<Equipe_Competition> Equipes
        {
            get { return equipes; }
        }
        public List<Stage> Stage
        {
            get { return this.stage; }
        }
        public List<Cours> Liste_cours
        {
            get { return this.liste_cours; }
        }

        #endregion

        public override string ToString()
        {
            if (this.competition == double.NaN)
            {
                return base.ToString() + "appartient au club :" + this.nom_du_club_affilie.ToString() + " et n'est pas classé(e)" + " " + this.sexe;

            }
            else
            {
                return base.ToString() + "appartient au club :" + this.nom_du_club_affilie.ToString() + " et son classement est :" + this.competition + " " + this.sexe;

            }
        }
        
        int Calcul_nb_defaite()
        {
            int nb_match_joue = 0;
            for (int i = 0; i < equipes.Count; i++)
            {
                if (equipes[i].Competition_engagee.Compet_finie == true)
                {
                    nb_match_joue++;
                }
            }
            int nb_defaite = nb_match_joue - nb_victoires_simple - nb_victoires_double;
            return nb_defaite;
        }
        public int Calcul_points()
        {
            int points = nb_victoires_double + nb_victoires_simple * 2;
            return points;
        }
        public void Ajouter_Victore_Simple()
        {
            nb_victoires_simple = nb_victoires_simple + 1;
        }
        public void Ajouter_Victore_Double()
        {
            nb_victoires_double = nb_victoires_double + 1;
        }
        #region Paiement et cotisation
        public bool Essai_Paiement_Cotisation() // return true si la cotis est payé
        // effectue le paiement de la cotisation SI POSSIBLE (i.e s'il ya largent neccessaire sur le compte_total_argent du membre)
        // s'il n'y a pas l'argent bas la cotis et pas payé et largent est laissé tel quel
        {
            bool cotis=true;
            if (!this.cotisastion_payee) // on verifie que la cotis n'est pas payée au cas où pour pas le faire payer 2 fois le pauvre
            {
                cotis=payer_avec_argent_sur_compte(Valeur_Cotisation()); // payer_avec ... return true si payé false sinn
            }
            return cotis;
        }

        int Valeur_Cotisation() 
        // calcul la valeur de la cotisation que le membre doit payer à l'instant present ( i.e si le joueur a pas paye le jour de son inscription
        // et qu'il est devenu majeur ou a change d'adresse entre temps c'est son probleme il avait qu'a payé avant aussi)
        {
            int cotis;
            if (this.competition == double.NaN)// si le joueur ne fait pas de la compet il doit payer moins dc on verifie
            {
                if (this.ville == nom_du_club_affilie.Ville) // prix differetn selon la ville
                {
                    if (this.Calcul_age() >= 18) // prix diff selon lage
                    {
                        cotis = 200;
                    }
                    else
                    {
                        cotis = 130;
                    }
                }
                else
                {
                    if (this.Calcul_age() >= 18)
                    {
                        cotis = 280;
                    }
                    else
                    {
                        cotis = 180;
                    }
                }
            }
            else // cas avec compet
            {
                if (this.ville == nom_du_club_affilie.Ville) 
                {
                    if (this.Calcul_age() >= 18) 
                    {
                        cotis = 220;
                    }
                    else
                    {
                        cotis = 150;
                    }
                }
                else
                {
                    if (this.Calcul_age() >= 18)
                    {
                        cotis = 300;
                    }
                    else
                    {
                        cotis = 200;
                    }
                }
            }
            return cotis;
        }

        public void ajouter_argent_sur_compte(int virement_a_effectuer)// int peut etre >0 ou <0
        // cette fct sert a faire des ajouts sur le compte client
        {
            argent_total_compte_membre += virement_a_effectuer;
        }

        bool payer_avec_argent_sur_compte(int somme_a_payer) // return true si le paiement est effectue false sinn
                                                             // on n'accepte pas les soldes negatifs sur les comptes clients
        {
            bool reusi = true;
            if(argent_total_compte_membre-somme_a_payer>=0) // s'il peut payer
            {
                argent_total_compte_membre -= somme_a_payer;
            }
            else
            {
                reusi = false;
            }
            return reusi;
        }
        #endregion
        
        #region Comparaison
        void Trier_En_Fct_De(List<Membre> listeATrier,string parametre)           /////  UTILISATION delegate pour tri
        {
            Comparison<Membre> compare;
            if (parametre=="nom")
            {
                listeATrier.Sort();
            }
            else if(parametre == "classement")
            {
                compare = new Comparison<Membre>(Comparaison_classement);
                listeATrier.Sort(compare);
            }
            else if(parametre == "sexe")
            {
                compare = new Comparison<Membre>(Comparaison_sexe);
                listeATrier.Sort(compare);
            }
            else if(parametre == "cotisation")
            {
                compare = new Comparison<Membre>(Comparaison_cotisation);
                listeATrier.Sort(compare);
            }

        }
        public int CompareTo(Membre other) //^par nom
        {
            return (this.nom + this.prenom).CompareTo((other.nom + other.prenom));
        }
        public static int Comparaison_classement(Membre s1,Membre s2)// par classement ordre croissant
        {
            return s1.competition.CompareTo(s2.competition);
        }
        public static int Comparaison_sexe(Membre s1, Membre s2)// par sexe
        {
            return (s1.sexe).CompareTo(s2.sexe);
        }
        public static int Comparaison_cotisation(Membre s1, Membre s2)
        {
            return (s1.cotisastion_payee).CompareTo(s2.cotisastion_payee);
        }
        #endregion

        #region equals et override d'egalite
        public  bool Equals(Membre other)
        {
            return base.Equals((Personne)other)&&(this.nom_du_club_affilie == other.nom_du_club_affilie);
        }
         #endregion
        
    }
}
