using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Plan your heist!");
            bool isAddingMembers = true;
            List<Member> AllMembers = new List<Member>();
            while (isAddingMembers)
            {
                Console.Write("Enter a team member's name: ");
                string MemberName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(MemberName))
                {
                    isAddingMembers = false;
                    break;
                }

                Console.Write("What is the team member's skill level? ");
                int Skill = int.Parse(Console.ReadLine());

                Console.Write("What is the team member's courage level? ");
                double Courage = double.Parse(Console.ReadLine());

                Member varMember = new Member(MemberName, Skill, Courage);

                AllMembers.Add(varMember);

            }

            int BankDiffLevel = 100;

            int WholeTeamSkillLevel = 0;

            foreach (var member in AllMembers)
            {
                WholeTeamSkillLevel += member.SkillLevel;
            }

            if (WholeTeamSkillLevel >= BankDiffLevel)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("You're going to prison");
            }


        }
    }
}
