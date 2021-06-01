using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main()
        {
            bool replayHeist = true;
            while (replayHeist)
            {
                Console.WriteLine("Plan your heist!");
                bool isAddingMembers = true;
                List<Member> AllMembers = new List<Member>();
                Console.Write("Set the bank's difficulty level: ");
                int DifficultyInput = int.Parse(Console.ReadLine());
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

                Console.WriteLine("How many trial runs? ");

                int trialRuns = int.Parse(Console.ReadLine());

                int BankDiffLevel = DifficultyInput;

                int WholeTeamSkillLevel = 0;

                int SuccessfulTrials = 0;

                int FailedTrials = 0;

                for (int x = trialRuns; x > 0; x--)
                {

                    WholeTeamSkillLevel = 0;

                    BankDiffLevel = DifficultyInput;

                    foreach (var member in AllMembers)
                    {
                        WholeTeamSkillLevel += member.SkillLevel;
                    }

                    int luck = new Random().Next(-10, 11);

                    Console.WriteLine();

                    BankDiffLevel += luck;

                    Console.WriteLine($"The team's combined skill level is {WholeTeamSkillLevel}");
                    Console.WriteLine($"The team's bank difficulty level is {BankDiffLevel}");

                    if (WholeTeamSkillLevel >= BankDiffLevel)
                    {
                        Console.WriteLine("Trial succeeded");
                        SuccessfulTrials++;
                    }
                    else
                    {
                        Console.WriteLine("Trial failed");
                        FailedTrials++;
                    }

                }
                Console.WriteLine();
                Console.WriteLine($"You had {SuccessfulTrials} successes, and {FailedTrials} failures.");
                Console.WriteLine();
                Console.WriteLine("You have seen the trial runs. Would you like to try the real thing? (Y/N)");
                string doRealHeist = Console.ReadLine().ToLower();
                if (doRealHeist == "y")
                {
                    if (WholeTeamSkillLevel >= BankDiffLevel)
                    {
                        Console.WriteLine("Your Heist Was A Success!");
                    }
                    else
                    {
                        Console.WriteLine("You're going to prison");
                    }
                }
                else
                {
                    Console.WriteLine("You backed out of the heist...");
                }

                Console.WriteLine("Would you like to play again? (Y/N): ");

                string replayAnswer = Console.ReadLine().ToLower();

                if (replayAnswer == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Restarting");
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                }

            }
        }
    }
}
