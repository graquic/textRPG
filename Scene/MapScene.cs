using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            PrintMap();
            PrintInfo();
        }

        public override void Update()
        {
            
            //입력
            ConsoleKeyInfo input = Console.ReadKey();
            ConsoleKey info = input.Key;
            
            // 플레이어 이동
            switch(info)
            {
                case ConsoleKey.UpArrow:
                    Data.Instance.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.Instance.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.Instance.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.Instance.player.Move(Direction.Right);
                    break;
                case ConsoleKey.I:
                    game.OpenInventory();
                    break;
                    

            }

            // 몬스터 이동
            foreach(Monster monster in Data.Instance.monsters)
            {
                monster.MoveAction();
            }

            // 몬스터랑 플레이어가 만나면 전투씬을 호출
            // if(몬스터랑 만난다면) game.StartBattle();

            Monster meetMonster = Data.Instance.GetMonsterInPosition(Data.Instance.player.pos);

            if(meetMonster != null)
            {
                // 플레이어 위치에 몬스터가 있으므로 전투 시작

                game.BattleStart(meetMonster);
            }
        }

        public void GenerateMap()
        {
            Data.Instance.LoadLevel1();
        }

        private void PrintMap()
        {
            Data.Instance.CheckRemainMonster();

            StringBuilder sb = new StringBuilder();

            Data data = Data.Instance;
            for (int y = 0; y < data.map.GetLength(0); y++)
            {
                for (int x = 0; x < data.map.GetLength(1); x++)
                {
                    if(data.map[y, x])
                    {
                        sb.Append(" ");
                    }

                    else
                    {
                        sb.Append('X');
                    }
                }
                sb.AppendLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = ConsoleColor.Green;

            foreach(Monster monster in Data.Instance.monsters)
            {
                Console.SetCursorPosition(monster.pos.x, monster.pos.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(Data.Instance.player.pos.x, Data.Instance.player.pos.y);
            Console.Write(Data.Instance.player.icon);

            Console.ForegroundColor = ConsoleColor.White;

            if (Data.Instance.isStage1Finished) // TODO : 몬스터가 다 처리됐을 경우 다음 맵으로 연결 혹은 다른 조건 생성
            {
                Console.SetCursorPosition(13, 13);
                Console.Write("E");

                //sb.Append("▣");
            }
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(Data.Instance.map.GetLength(1) + 3, 1);
            Console.Write($"LV.{Data.Instance.player.level}");
            
            Console.SetCursorPosition(Data.Instance.map.GetLength(1) + 3, 2);
            Console.Write($"HP : {Data.Instance.player.currentHP} / {Data.Instance.player.maxHP}");

            Console.SetCursorPosition(Data.Instance.map.GetLength(1) + 3, 3);
            Console.Write($"Exp : {Data.Instance.player.exp} / {Data.Instance.player.maxExp}");
        }
    }
}
