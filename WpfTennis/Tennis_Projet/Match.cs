using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class abstract mere des deux type de match possible
    /// </summary>
    public abstract class Match
    {
        Equipe_Competition equipe1;
        Equipe_Competition equipe2;
        string type_match;

        public Match()
        {

        }
        public Match(Equipe_Competition equipe1, Equipe_Competition equipe2,string type)
        {
            this.equipe1 = equipe1;
            this.equipe2 = equipe2;
            this.type_match = type;
        }
        public string Type_match
        {
            get { return this.type_match; }
        }
        



    }
}
