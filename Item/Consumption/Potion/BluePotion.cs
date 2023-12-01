﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG;

namespace TextRPG
{
    public class BluePotion : Potion
    {
        public BluePotion()
        {
            this.name = "파란 포션";
            this.value = 15;
            this.effect = 10;
            this.itemCount = 1;

            this.id = ItemType.BluePotion;

            this.dropItem = new DropItem(20, ItemType.BluePotion);
        }

        public override void Use()
        {
            int nextMP = Data.Instance.player.currentMP + effect;

            if (nextMP >= Data.Instance.player.maxMP)
            {
                Data.Instance.player.currentMP = Data.Instance.player.maxMP;
            }

            else
            {
                Data.Instance.player.currentMP = nextMP;
            }
        }

        public override int GetItemCount()
        {
            return this.itemCount;
        }

        public override void AddItemCount()
        {
            ++itemCount;
        }
    }
}
