using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace textRPG
{
    public class Inventory 
    {
        public Inventory()
        {
            itemList = new List<Item>() { new RedPotion(), new BluePotion()};
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

        public Item GetItem(int cursorIndex)
        {
            if(cursorIndex < 0 || cursorIndex >= itemList.Count)
            {
                return null;
            }

            else
            {
                return itemList[cursorIndex];
            }
        }

        public int CompareNameUpper(Item a, Item b)
        {
            return String.Compare(a.Name, b.Name);
        }

        public int CompareNameLower(Item a, Item b)
        {
            return -String.Compare(a.Name, b.Name);
        }

        public int CompareValueUpper(Item a, Item b)
        {
            if (a.Value < b.Value)
                return -1;
            else if (a.Value == b.Value)
                return 0;
            else
                return 1;
        }

        public int CompareValueLower(Item a, Item b)
        {
            if (a.Value < b.Value)
                return 1;
            else if (a.Value == b.Value)
                return 0;
            else
                return -1;
        }

    }
}
