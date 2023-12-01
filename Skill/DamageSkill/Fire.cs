using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace textRPG
{
    public class Fire : DamageSkill
    {
        public Fire()
        {
            this.needLv = 1;
            this.costMp = 20;
            this.dmg = 30;

            this.currentSkillLevel = 1;
            this.maxSkillLevel = 5;

            this.skillType = SkillType.Fire;

            Fire.precedingSkill = new List<Skill>();
        }

        public override void UseSkill(Player player, Monster monster)
        {
            throw new NotImplementedException();
        }
    }
}
