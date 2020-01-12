using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Match
    {
        Equipe_Competition equipe1;
        Equipe_Competition equipe2;

        public Match(Equipe_Competition equipe1, Equipe_Competition equipe2)
        {
            this.equipe1 = equipe1;
            this.equipe2 = equipe2;
        }


    }
}
