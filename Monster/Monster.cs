using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public abstract class Monster
    {
        public char icon = 'M';
        public Position pos;

        public Dictionary<ItemType, Item> dropItemDic;

        public List<ItemType> dropList;

        // 이름

        public string name;

        // 체력

        public int currentHP;
        public int maxHP;

        public int def;

        public int damage;

        public int rewardExp;

        // TODO : 방어력 구현

        // public float defence;

        

        public abstract void MoveAction();

        public abstract void DropItem();

        protected virtual void Move(Direction dir) // TODO : 원래는 가상함수x
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

            if (Data.Instance.map[pos.y, pos.x] == 0)
            {
                pos = prevPos;
            }
        }
    }
}
