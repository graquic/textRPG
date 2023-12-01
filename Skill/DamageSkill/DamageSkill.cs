using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public abstract class DamageSkill : Skill
    {
        protected int dmg;
        protected int costMp;

        public int Dmg { get { return dmg; } }
        public int CostMp { get { return costMp; }}

        public abstract void UseSkill(Player player, Monster monster);
    }
}
