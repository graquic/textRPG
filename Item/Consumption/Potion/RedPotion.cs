using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG;

namespace TextRPG
{
    public class RedPotion : Potion
    {
        public RedPotion()
        {
            this.name = "빨간 포션";
            this.value = 10;
            this.effect = 20;
            this.itemCount = 3;

            this.id = ItemType.RedPotion;

            this.dropItem = new DropItem(30, ItemType.RedPotion);
        }

        public override void Use()
        {
            int nextHP = Data.Instance.player.currentHP + effect;

            if( nextHP >= Data.Instance.player.maxHP ) 
            {
                Data.Instance.player.currentHP = Data.Instance.player.maxHP;
            }

            else
            {
                Data.Instance.player.currentHP = nextHP;
            }
        }

        public override void PrintEffect()
        {
            Console.Write($"체력이 {effect}만큼 회복되었습니다. 현재 체력은 {Data.Instance.player.currentHP}입니다");
        }

        public override int GetItemCount()
        {
            return this.itemCount;
        }

        public override void AddItemCount()
        {
            ++itemCount;
        }

        public override void DecreaseItemCount()
        {
            --itemCount;
        }
    }
}
