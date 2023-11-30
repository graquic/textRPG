using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base (game)
        {

        }
        public override void Render()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("1. 게임 시작");
            stringBuilder.AppendLine("2. 게임 종료");
            stringBuilder.Append("메뉴를 선택하세요.");

            Console.Write(stringBuilder.ToString());
        }


        public override void Update()
        {
            string input = Console.ReadLine();

            int command;

            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    // 게임 입장.
                    Console.WriteLine("게임을 시작합니다.");
                    Thread.Sleep(500);

                    game.GameStart();

                    break;
                case 2:
                    // 게임 종료.
                    game.GameOver();
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    break;
            }
        }



    }
}
