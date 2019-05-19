using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_NARIN
{
    abstract class Ability
    {
        public Ability()
        {
        }
        private int reload;
        public int Reload
        {
            get
            {
                return reload;
            }
            set
            {
                reload = value;
                if (reload < 1)
                    reload = 1;
            }
        }
    }
}
