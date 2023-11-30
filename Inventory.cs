using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private List<Item> itemList;

        public void AddItem(Item item)
        {
            if(itemList.Count == 0)
            {
                itemList.Add(item);
                return;
            }

            if (item is ICountable countable)
            {

                for (int i = 0; i < itemList.Count; i++)
                {
                    if ((item.ItemType == itemList[i].ItemType))
                    {
                        ICountable temp = (ICountable)itemList[i];
                        temp.AddItemCount(); 

                        return;
                    }
                }
            }
            else
            {
                itemList.Add(item);
            }

        }

        
    }
}
