using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public abstract class Consumption : Item , ICountable , IUseable
    {
        protected int effect;

        protected int itemCount;

        public int Effect { get { return effect; } }

        public abstract int GetItemCount();

        public abstract void AddItemCount();

        public abstract void DecreaseItemCount();

        public abstract void Use();

        public abstract void PrintEffect();

    }
}
