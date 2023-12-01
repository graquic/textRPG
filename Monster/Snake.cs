using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace textRPG
{
    public class Snake : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;

        public List<Position> path;

        public Snake()
        {
            icon = 'S';
            name = "뱀";
            currentHP = maxHP = 15;
            damage = 5;

            def = 2;

            rewardExp = 100;
        }
        public override void MoveAction()
        {
            moveTurn++;

            Direction dir;

            int yDiff = Math.Abs(Data.Instance.player.pos.y - this.pos.y);
            int xDiff = Math.Abs(Data.Instance.player.pos.x - this.pos.x);

            if (yDiff < 6 && xDiff < 6 ) // 플레이어 인식거리
            {
                if(moveTurn < 2)
                {
                    return;
                }
                else
                {
                    dir = FindPath.Instance.PathFinding(Data.Instance.map, this.pos, Data.Instance.player.pos, path);
                    Move(dir);

                    moveTurn = 0;
                }

            }

            else // 인식거리가 아니면 반응 느림
            {
                if (moveTurn < 5)
                {
                    return;
                }
                else
                {
                    int randomNumber = random.Next(0, 4);

                    Move((Direction)randomNumber);

                    moveTurn = 0;
                }
            }

        }

        public override void DropItem()
        {
            Console.WriteLine("파란 포션이 드랍되었습니다");

            Data.Instance.player.inventory.AddItem(new BluePotion());
        }


    }
}
