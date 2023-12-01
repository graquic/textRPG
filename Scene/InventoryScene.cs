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
        public int cursorIndex = 0;
        int cursorPos;

        bool isNameUpper;
        bool isValueUpper;
        public InventoryScene(Game game) : base(game) 
        {
            
        }

        public override void Render()
        {
            PrintInventory();
            SetItemCursorPosition(cursorIndex);
        }

        public override void Update()
        {
            Input();
        }

        private void PrintInventory()
        {
            bool[,] map = new bool[16,16] ;

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
            Console.Write("Q : 이름순 정렬 / W : 값어치순 정렬 / E : 돌아가기 / Enter : 선택 / ↓ : 아래 이동 / ↑ : 위 이동");


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

            const int maxIdx = 5;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    ++cursorIndex;
                    SetItemCursorPosition(cursorIndex);
                    break;
                case ConsoleKey.UpArrow:
                    --cursorIndex;
                    SetItemCursorPosition(cursorIndex);
                    break;
                case ConsoleKey.E:
                    CloseInventory();
                    break;
                case ConsoleKey.Enter:
                    UseItem(cursorIndex);
                    break;
                case ConsoleKey.Q: // 이름순 정렬
                    if(isNameUpper)
                    {
                        Data.Instance.player.inventory.itemList.Sort(Data.Instance.player.inventory.CompareNameUpper);
                        isNameUpper = !isNameUpper;
                        break;
                    }
                    Data.Instance.player.inventory.itemList.Sort(Data.Instance.player.inventory.CompareNameLower);
                    isNameUpper = !isNameUpper;
                    break;
                case ConsoleKey.W: // 값어치순 정렬
                    if(isValueUpper)
                    {
                        Data.Instance.player.inventory.itemList.Sort(Data.Instance.player.inventory.CompareValueUpper);
                        isValueUpper = !isValueUpper;
                        break;
                    }
                    Data.Instance.player.inventory.itemList.Sort(Data.Instance.player.inventory.CompareValueLower);
                    isValueUpper = !isValueUpper;
                    break;
                default:
                    return;
                    
            }

            cursorIndex = (cursorIndex + maxIdx) % maxIdx; // TODO : 범위 안을 유지할 수 있게 하는 모듈러 연산 ★★★★★★★★★★★★★★
        }


        private void SetItemCursorPosition(int cursorIndex)
        {
            cursorPos = ( 3 + (2 * cursorIndex) ) % Data.Instance.map.GetLength(0);

            Console.SetCursorPosition(3, cursorPos);
            Console.Write("=>");
        }

        private void UseItem(int cursorIndex) // 일단 사용 구현 
        {
            if (Data.Instance.player.inventory.GetItem(cursorIndex) == null )
            { return; }
                
            
            if (Data.Instance.player.inventory.itemList[cursorIndex] is ICountable countable)
            {
                countable.DecreaseItemCount();

                if (Data.Instance.player.inventory.itemList[cursorIndex] is IUseable useable)
                {
                    cursorPos = (3 + (2 * cursorIndex)) % Data.Instance.map.GetLength(0);

                    useable.Use();

                    Console.SetCursorPosition(Data.Instance.map.GetLength(1) + 20, cursorPos);
                    useable.PrintEffect();

                    Thread.Sleep(1000);
                }


                if (countable.GetItemCount() <= 0)
                {
                    Data.Instance.player.inventory.itemList.RemoveAt(cursorIndex);
                }

                
            }

            
        }

        
    }
}
