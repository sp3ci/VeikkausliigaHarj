using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarjVeikLiiga
{
    public class Team
    {
        public int Id;
        public string Name;
        public string FullName;
        public string LogoUrl;

        public string GetName()
        {
            if (FullName.Length > 7)
            {
                return Name;
            }
            return FullName;
        }
    }
}
