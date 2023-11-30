using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public abstract class Consumption : Item , ICountable
    {
        protected int effect;

        protected int itemCount;

        public int Effect { get { return effect; } }

        public abstract void GetItemCount();

    }
}
