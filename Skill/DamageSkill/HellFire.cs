using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG;

namespace textRPG
{
    public class HellFire : DamageSkill
    {
        public HellFire() 
        {
            this.needLv = 2;
            this.costMp = 20;
            this.dmg = 30;

            this.currentSkillLevel = 1;
            this.maxSkillLevel = 5;

            this.skillType = SkillType.HellFire;

            HellFire.precedingSkill = new List<Skill>() { new Fire() }; // 선행 스킬
        }

        public override void UseSkill(Player player, Monster monster)
        {
            if(player.currentMP < this.costMp)
            {
                Console.Write("마나가 부족하여 마법을 사용할 수 없습니다.");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                Console.Write($"플레이어는 {monster.name}에게 헬파이어를 사용했다!. \n {monster.name}는 " +
                    $"{this.dmg * currentSkillLevel}의 데미지를 입었다.");
                monster.currentHP -= this.dmg;
                Thread.Sleep(1000);
                return;
            }
            
        }
    }
}
