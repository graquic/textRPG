using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game) 
        { 

        }

        public override void Render()
        {
            PrintInventory();
        }

        public override void Update()
        {
            Console.ReadLine();
        }

        private void PrintInventory()
        {
            bool[,] map = Data.Instance.map;

            StringBuilder sb = new StringBuilder();

            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(i == 0 || i == map.GetLength(0) -1 )
                    {
                        sb.Append("==");
                    }

                    else if (j == 0 || j == map.GetLength(1) - 1)
                    {
                        sb.Append("|");
                    }

                    else
                    {
                        sb.Append("  ");
                    }
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());

            PrintAllItem();
        }

        public void PrintAllItem()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("[현재 인벤토리 목록]");

            if (Data.Instance.player.inventory.itemSet.Count > 0)
            {
                foreach (Item item in Data.Instance.player.inventory.itemSet)
                {
                    int itemCount = 0;
                    int loopCount = 0;

                    for (int i = 0; i < Data.Instance.player.inventory.itemList.Count; i++)
                    {
                        if (item == Data.Instance.player.inventory.itemList[i]) // item과 i번째에 있는 요소가 같은 클래스인지를 비교
                        {
                            itemCount++;
                        }
                    }

                    Console.SetCursorPosition(3, 3 + loopCount);
                    Console.Write($"{item.Name} : {itemCount}");

                    loopCount += 2;

                }
            }

            else
            {
                Console.SetCursorPosition(3, 3);
                Console.Write("아이템이 존재하지 않습니다");
            }

            

        }
    }
}
