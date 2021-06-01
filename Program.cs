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

            Console.WriteLine(AllMembers.Count);

            foreach (Member memberX in AllMembers)
            {
                Console.WriteLine($"{memberX.Name} has a skill level of {memberX.SkillLevel}, and a courage level of {memberX.Courage}.");
            }

        }
    }
}
