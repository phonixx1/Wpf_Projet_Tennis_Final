using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Match_Simple : Match
    {
        int indice_joueur_equipe1;
        int indice_joueur_equipe2;
        Equipe_Competition equipe1;
        Equipe_Competition equipe2;
        string type_match;
        public Match_Simple()
        {

        }
        public Match_Simple(Equipe_Competition equipe1,Equipe_Competition equipe2, int indice_joueur_equipe1, int indice_joueur_equipe2, string type_match) :base (equipe1,equipe2,type_match)
        {
            this.indice_joueur_equipe1 = indice_joueur_equipe1;
            this.indice_joueur_equipe2 = indice_joueur_equipe2;
            this.equipe1 = equipe1;
            this.equipe2 = equipe2;
            this.type_match = type_match;
        }
        public void Ajout_point1(Membre gagnant, Equipe_Competition equipe_gagnante)
        {
            gagnant.Ajouter_Victore_Simple();
            equipe_gagnante.Points_Equipe = equipe_gagnante.Points_Equipe + 1;
        }
        public int Indice_joueur_equipe1
        {
            get { return this.indice_joueur_equipe1; }
        }
        public int Indice_joueur_equipe2
        {
            get { return this.indice_joueur_equipe2; }
        }
        public Equipe_Competition Equipe1
        {
            get { return this.equipe1; }
        }
        public Equipe_Competition Equipe2
        {
            get { return this.equipe2; }
        }
    }
}
