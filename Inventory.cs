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

        public List<Item> itemList; // 기존

        // public List<ICountable> countableItemList; // 기존 방식을 사용할 경우 넣을 때와 요소를 출력할 때, 뺄 때 모두 ICountalbe인지 확인해야하는 문제
        // public List<Item> uncountableItemList;

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
                    if ((item.Id == itemList[i].Id))
                    {
                        countable = (ICountable)itemList[i];
                        countable.AddItemCount(); 

                        return;
                    }
                }

                itemList.Add(item);
                return;

            }
            else
            {
                itemList.Add(item);
                return;
            }

        }

        /*public void AddItem2(Item item)
        {
            if( item is ICountable countable)
            {
                
                if(countableItemList.Count > 0)
                {
                    for (int i = 0; i < countableItemList.Count; i++)
                    {
                        if(item.Id == countableItemList[i].Id)
                    }
                }
            }
        }*/

        
    }
}
