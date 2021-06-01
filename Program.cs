using System;

namespace Heist
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Plan your heist!");
            Console.Write("Enter a team member's name: ");
            string MemberName = Console.ReadLine();

            Console.Write("What is the team member's skill level? ");
            int Skill = int.Parse(Console.ReadLine());

            Console.Write("What is the team member's courage level? ");
            double Courage = double.Parse(Console.ReadLine());

            Console.WriteLine($"Your team member's name is {MemberName}, they have a skill level of {Skill} and a courage level of {Courage}.");
        }
    }
}
