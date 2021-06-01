using System;

namespace Heist
{
    public class Member
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public double Courage { get; set; }


        public Member(string name, int skillLevel, double courage)
        {
            Name = name;
            SkillLevel = skillLevel;
            Courage = courage;
        }
    }


}