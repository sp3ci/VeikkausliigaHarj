using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarjVeikLiiga
{
    public class Match
    {
        public int Id;
        public DateTime MatchDate;
        public Team HomeTeam;
        public Team AwayTeam;
        public int HomeGoals;
        public int AwayGoals;
    }
}
