using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace textRPG
{
    public class Inventory 
    {
        public Inventory()
        {
            itemList = new List<Item>();
        }

        public List<Item> itemList;

        public int CheckItemCount(Item item)
        {
            int itemCount = 0;

            if(itemList.Count == 0)
            {
                return 0;
            }

            for (int i = 0; i < itemList.Count; i++)
            {
                if(item == itemList[i])
                {
                    itemCount++;
                }
            }

            return itemCount;
        }

        public void AddItem(IMultiple imultiple)
        {
            imultiple.
        }

        
    }
}
