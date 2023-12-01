using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG;

namespace TextRPG
{
    public class SkillScene : Scene
    {
        public int cursorIndex = 0;
        int cursorPos;


        public SkillScene(Game game) : base(game) 
        {

        }

        public override void Render()
        {
            PrintUI();
        }

        public override void Update()
        {
            Input();
        }

        private void PrintUI()
        {
            bool[,] map = new bool[16, 16];

            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1)
                    {
                        sb.Append("==");
                    }

                    else if (j == 0)
                    {
                        sb.Append("|");
                    }

                    else if (j == map.GetLength(1) - 1)
                    {
                        sb.Append("  |"); 
                    }

                    else
                    {
                        sb.Append("  ");
                    }
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());

            Console.SetCursorPosition(3, 3);
            SetItemCursorPosition(cursorIndex);
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
                    CloseSkill();
                    break;
                default:
                    break;
                

            }
            cursorIndex = (cursorIndex + maxIdx) % maxIdx;
        }

        private void SetItemCursorPosition(int cursorIndex)
        {
            cursorPos = (3 + (2 * cursorIndex)) % Data.Instance.map.GetLength(0);

            Console.SetCursorPosition(3, cursorPos);
            Console.Write("=>");
        }

        private void Init()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("=>");
        }

        private void CloseSkill()
        {
            game.Map();
        }
    }
}
