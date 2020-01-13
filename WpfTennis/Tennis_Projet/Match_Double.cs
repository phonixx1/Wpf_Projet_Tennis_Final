using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Match_Double: Match
    {
        int indice_joueur1_equipe1;  
        int indice_joueur1_equipe2;
        int indice_joueur2_equipe1;
        int indice_joueur2_equipe2;
        Equipe_Competition equipe1;
        Equipe_Competition equipe2;
        string type_match;
        public Match_Double()
        {

        }
        public Match_Double(Equipe_Competition equipe1, Equipe_Competition equipe2, int indice_joueur1_equipe1, int indice_joueur1_equipe2, int indice_joueur2_equipe1, int indice_joueur2_equipe2, string type_match)  : base(equipe1, equipe2,type_match)
        {
            this.indice_joueur1_equipe1 = indice_joueur1_equipe1;
            this.indice_joueur1_equipe2 = indice_joueur1_equipe2;
            this.indice_joueur2_equipe1 = indice_joueur2_equipe1;
            this.indice_joueur2_equipe2 = indice_joueur2_equipe2;
            this.equipe1 = equipe1;
            this.equipe2 = equipe2;
            this.type_match = type_match;
        }
        public void Ajout_point2(Membre gagnant1, Membre gagnant2, Equipe_Competition equipe_gagnante)
        {
            gagnant1.Ajouter_Victore_Double();
            gagnant2.Ajouter_Victore_Double();
            equipe_gagnante.Points_Equipe = equipe_gagnante.Points_Equipe + 2;
        }
        public Equipe_Competition Equipe1
        {
            get { return this.equipe1; }
        }
        public Equipe_Competition Equipe2
        {
            get { return this.equipe2; }
        }
        public int Indice_joueur1_equipe1
        {
            get { return this.indice_joueur1_equipe1; }
        }
        public int Indice_joueur1_equipe2
        {
            get { return this.indice_joueur1_equipe2; }
        }
        public int Indice_joueur2_equipe1
        {
            get { return this.indice_joueur2_equipe1; }
        }
        public int Indice_joueur2_equipe2
        {
            get { return this.indice_joueur2_equipe2; }
        }


    }
}
