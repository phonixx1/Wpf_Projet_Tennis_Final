using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Personne: IEquatable<Personne>
    {
        protected string nom;
        protected string prenom;
        protected string sexe; // m ou f
        protected DateTime date_naissance;
        protected string adresse;
        protected string ville;
        protected string numero_telephone;

        public Personne(string nom, string prenom, string sexe,string adresse,string ville, DateTime date_naissance,string numeroTel)
        {
            this.prenom = prenom;
            this.nom = nom.ToUpper();
            this.sexe = sexe.ToLower();
            this.adresse = adresse;
            this.ville = ville;
            this.date_naissance = date_naissance;
            this.numero_telephone = numeroTel;
        }
        public int Calcul_age()
        {
            int age;
            if (date_naissance.Month>DateTime.Today.Month)
            {
                age = DateTime.Today.Year - date_naissance.Year;
            }
            else if (date_naissance.Month < DateTime.Today.Month)
            {
                age = DateTime.Today.Year - date_naissance.Year-1;
            }
            else
            {
                if(date_naissance.Day>=DateTime.Today.Day)
                {
                    age = DateTime.Today.Year - date_naissance.Year;
                }
                else
                {
                    age = DateTime.Today.Year - date_naissance.Year - 1;
                }
            }
            return age;
            
        }

        public  bool Equals(Personne other)
        {
            return ((this.nom==other.nom)&&(this.prenom==other.prenom)&&(this.date_naissance==other.date_naissance)&&(this.sexe==other.sexe));
        }

        public override string ToString()
        {
            if (this.sexe == "m")
            {
                return "Mr."+this.nom + " " + this.prenom + " né le " + this.date_naissance.Day + "/" + this.date_naissance.Month + "/" + this.date_naissance.Year + " ";
            }
            else
            {
                return "Mme."+this.nom + " " + this.prenom + " née le " + this.date_naissance.Day+"/" +this.date_naissance.Month+"/"+this.date_naissance.Year+ " ";

            }
        }


    }
}
