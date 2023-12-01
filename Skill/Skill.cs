using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class Skill
    {
        protected int needLv;
        protected SkillType skillType;

        protected int currentSkillLevel;
        protected int maxSkillLevel;

        public static List<Skill> precedingSkill;

        public int NeedLv { get { return needLv; } }
        public SkillType SkillType { get { return skillType; } }
        public int CurrentSkillLevel { get {  return currentSkillLevel; } }
        public int MaxSkillLevel { get { return maxSkillLevel; } }

        public void AddSkillLevel()
        {
            currentSkillLevel++;
        }

    }
}
