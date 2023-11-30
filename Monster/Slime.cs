using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace textRPG
{
    public class Slime : Monster
    {
        // 매 업데이트 마다 랜덤방향으로 이동.

        private Random random = new Random();
        private int moveTurn = 0;

        public Slime()
        {
            name = "슬라임";
            currentHP = maxHP = 10;
            damage = 2;
            rewardExp = 50;

            dropItemDic = new Dictionary<ItemType, Item>() 
            { {ItemType.RedPotion, new RedPotion() }, {ItemType.BluePotion, new BluePotion() } };

            dropList = new List<ItemType>() { ItemType.RedPotion, ItemType.BluePotion };

        }

        public override void MoveAction()
        {
            moveTurn++;

            if(moveTurn < 3)
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

        public override void DropItem()
        {
            Console.WriteLine("빨간 포션이 드랍되었습니다.");

            Data.Instance.player.inventory.AddItem(new RedPotion());
        }

    }
}
