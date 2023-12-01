using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public abstract class Item : IComparable<Item>
    {

        protected ItemType id;

        protected string name;

        protected int value;

        public DropItem dropItem;

        public string Name { get { return name; } }
        public int Value { get { return value; }  }
        public ItemType Id { get { return id; } }

        public int CompareTo(Item? other)
        {
            if (this.value < other.value)
                return -1;
            else if (this.value == other.value)
                return 0;
            else
                return 1;
        }
    }
}
