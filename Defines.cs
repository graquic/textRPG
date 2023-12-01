using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public struct Position // 플레이어의 위치를 정의
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct DropItem
    {
        public int dropPercent;

        public ItemType i;

        public DropItem(int dropPercent, ItemType item)
        {
            this.dropPercent = dropPercent;
            this.i = item;
        }
    }
    public enum ItemType
    {
        RedPotion,
        BluePotion,
    }

    public enum SkillType
    {
        Fire,
        HellFire,
        Smash
    }

    public enum Direction
    {
        Up = 0, 
        Down = 1, 
        Left = 2, 
        Right = 3,
        None = 9
    }
}
