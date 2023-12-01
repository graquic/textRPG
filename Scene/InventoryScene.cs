using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Input();
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

                    else if (j == 0)
                    {
                        sb.Append("|");
                    }

                    else if (j == map.GetLength(1) - 1)
                    {
                        sb.Append("  |"); // 임의로 오른쪽 늘려줌
                    }

                    else
                    {
                        sb.Append("  ");
                    }
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());


            Console.SetCursorPosition(0, map.GetLength(0) + 2);
            Console.Write("ESC : 돌아가기 / Enter : 선택 / ");


            PrintAllItem();

        }

        private void PrintAllItem()
        {
            Console.SetCursorPosition(6, 2);
            Console.Write("[현재 인벤토리 목록]");

            if(Data.Instance.player.inventory.itemList.Count > 0)
            {
                int loopCount = 0;

                foreach(Item item in Data.Instance.player.inventory.itemList)
                {
                    if(item is ICountable countable)
                    {
                        Console.SetCursorPosition(6, 3 + loopCount);
                        Console.Write($"{item.Name} : {countable.GetItemCount()}");

                        loopCount += 2;
                        continue;
                    }

                    else
                    {
                        Console.SetCursorPosition(6, 3 + loopCount);
                        Console.Write($"{item.Name}");
                    }
                }
            }
        }

        private void CloseInventory()
        {
            game.Map();
        }

        private void Input()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            ConsoleKey key = input.Key;

            int itemLength = 0;

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    
                    break;
                case ConsoleKey.DownArrow:
                    
                    break;
                case ConsoleKey.Escape:
                    game.Map();
                    break;
                    
            }
            

        }

        private void SetItemCursorPosition()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("=>");
        }
    }
}
