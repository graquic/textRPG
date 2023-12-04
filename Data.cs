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

        public int[,] map;

        public Player player;

        public int[] playerLevelTable;

        public Dictionary<SkillType, Skill> skillDic;

        public bool isStage1Finished;



        // 몬스터
        public List<Monster> monstersLV1;
        public List<Monster> monstersLV2;


        // 아이템

        // 인벤토리   <<  모두 Init에서 초기화

        public void Init()
        {
            player = new Player();
            monstersLV1 = new List<Monster>();
            monstersLV2 = new List<Monster>();

            skillDic = new Dictionary<SkillType, Skill>() { {SkillType.HellFire, new HellFire() } };


            playerLevelTable = new int[10]
            {100, 300, 500, 700, 900, 1100, 1300, 1500, 1700, 2000};
        }

        public void LoadLevel1()
        {
            map = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            

            player.pos = new Position(2, 2);

            Slime slime = new Slime();
            slime.pos = new Position(9,9);
            monstersLV1.Add(slime);

            Slime slime2 = new Slime();
            slime2.pos = new Position(9, 10);
            monstersLV1.Add(slime2);

            Slime slime3 = new Slime();
            slime3.pos = new Position(11, 11);
            monstersLV1.Add(slime3);

            Snake snake1 = new Snake();
            snake1.pos = new Position(7, 7);
            monstersLV1.Add(snake1);

            Snake snake2 = new Snake();
            snake2.pos = new Position(2, 13);
            monstersLV1.Add(snake2);

        }

        public void LoadLevel2()
        {
            map = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0},
                { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            player.pos = new Position(2, 13);

            Snake snake1 = new Snake();
            snake1.pos = new Position(3, 3);
            monstersLV2.Add(snake1);

            Snake snake2 = new Snake();
            snake2.pos = new Position(5, 8);
            monstersLV2.Add(snake2);

            Snake snake3 = new Snake();
            snake1.pos = new Position(11, 7);
            monstersLV2.Add(snake3);

            Snake snake4 = new Snake();
            snake2.pos = new Position(12, 12);
            monstersLV2.Add(snake4);

            
        }

        public Monster GetMonsterInPosition(Position pos)
        {
            foreach(Monster monster in monstersLV1)
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
            if(monstersLV1.Count == 0)
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
