using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public abstract class Item
    {

        protected ItemType itemType;

        protected string name;

        protected int value;

        public DropItem dropItem;

        public string Name { get { return name; } }
        public int Value { get { return Value; } }
        

        public abstract void Use();

    }
}
