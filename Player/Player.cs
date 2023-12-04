using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class Player
    {
        public char icon = 'P';

        public Position pos;

        // 체력
        public int currentHP;
        public int maxHP;

        // 방어력
        public int def;

        // 마나

        public int currentMP;
        public int maxMP;

        // 적을 잡고 경험치를 얻을 수 있다.
        // 총 경험치
        public int exp;
        public int maxExp;

        // 경험치 단계별로 정리된 테이블이 있을 때
        // 현재 경험치가 몇 레벨의 경험치에 해당하는지 검사하여 레벨을 결정.

        public int skillPoint;


        public int level;

        public int damage;


        // 인벤토리

        public Inventory inventory;

        // 보유 스킬

        public List<Skill> ownedSkill;

        public Player()
        {
            currentHP = 50;
            maxHP = 100;

            currentMP = 20;
            maxMP = 20;

            def = 0;

            exp = 0;
            maxExp = 100;

            skillPoint = 0;

            level = 1;
            damage = 5;

            inventory = new Inventory();
            ownedSkill = new List<Skill>();

        }

        public void Move(Direction dir)
        {
            Position prevPos = pos;

            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }

            if (0 == Data.Instance.map[pos.y, pos.x])
            {
                Data.Instance.player.pos = prevPos;
            }

        }


        public void GainExp(int exp)
        {
            Console.WriteLine($"{exp}의 경험치를 얻었습니다.");
            Thread.Sleep(1000);

            this.exp += exp;

            int level = 0;

            for(int i = 0; i < Data.Instance.playerLevelTable.Length; i++)
            {
                if (this.exp < Data.Instance.playerLevelTable[i])
                {
                    level = i + 1;
                    maxExp = Data.Instance.playerLevelTable[i];
                    break;
                }
            }

            if(this.level != level)
            {
                // 레벨업
                Console.WriteLine($"플레이어의 레벨이 올라 {level}이 되었습니다");
                LevelUp();
                Thread.Sleep(1000);
                this.level = level;
            }
        }

        private void LevelUp()
        {
            this.currentHP += 10;
            this.maxHP += 10;
            Console.WriteLine($"최대체력이 10 증가하여 {this.maxHP}가 되었습니다.");

            this.damage += 3;
            this.def += 1;

            Console.WriteLine($"데미지가 2 증가하여 {this.damage}가 되었습니다.");
        }

    }
}
