using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class Data
    {
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }
        private Data() { }

        public bool[,] map;

        public Player player;

        public int[] playerLevelTable;

        public bool isStage1Finished;

        

        // 몬스터
        public List<Monster> monsters;



        // 아이템

        // 인벤토리   <<  모두 Init에서 초기화

        public void Init()
        {
            player = new Player();
            monsters = new List<Monster>();


            playerLevelTable = new int[10]
            {100, 300, 500, 700, 900, 1100, 1300, 1500, 1700, 2000};
        }

        public void LoadLevel1()
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                { false, true,  false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  true,   true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false,  true,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false, false, false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  true,   true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  true,   true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}
            };

            player.pos = new Position(2, 2);

            Slime slime = new Slime();
            slime.pos = new Position(9,9);
            monsters.Add(slime);

            Slime slime2 = new Slime();
            slime2.pos = new Position(9, 10);
            monsters.Add(slime2);

            Slime slime3 = new Slime();
            slime3.pos = new Position(11, 11);
            monsters.Add(slime3);

            Snake snake1 = new Snake();
            snake1.pos = new Position(7, 7);
            monsters.Add(snake1);

            Snake snake2 = new Snake();
            snake2.pos = new Position(2, 13);
            monsters.Add(snake2);

        }

        public Monster GetMonsterInPosition(Position pos)
        {
            foreach(Monster monster in monsters)
            {
                if(pos.x == monster.pos.x && pos.y == monster.pos.y)
                {
                    return monster;
                }
            }

            return null;
        }

        public void CheckRemainMonster()
        {
            if(monsters.Count == 0)
            {
                isStage1Finished = true;
            }
            else
            {
                isStage1Finished = false;
            }
        }
    }
}
