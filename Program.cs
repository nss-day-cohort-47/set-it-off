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
                int DifficultyInput = 100;
                try
                {
                    DifficultyInput = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, the difficulty level default value will be 100.");
                }
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
                    int Skill = 10;
                    try
                    {
                        Skill = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input, the skill level default value will be 10.");
                    }


                    Console.Write("What is the team member's courage level? ");
                    double Courage = 5.0;
                    try
                    {
                        Courage = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input, the courage level default value will be 5.0");
                    }

                    Member varMember = new Member(MemberName, Skill, Courage);

                    AllMembers.Add(varMember);

                }

                Console.WriteLine("How many trial runs? ");
                int trialRuns = 5;
                try
                {
                    trialRuns = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, the default number of trial runs will be 5.");
                }



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

                    foreach (var member in AllMembers)
                    {
                        if (member.Courage < 5.0)
                        {
                            Console.WriteLine($"{member.Name} doesn't seem courageous enough for this job.");
                        }
                    }

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
                Console.WriteLine($"Your chances of success are {SuccessfulTrials * 100 / (SuccessfulTrials + FailedTrials)}% as long as no one gets caught.");
                Console.WriteLine();
                Console.WriteLine("You have seen the trial runs. Would you like to try the real thing? (Y/N)");
                string doRealHeist = Console.ReadLine().ToLower();
                if (doRealHeist == "y")
                {
                    WholeTeamSkillLevel = 0;

                    BankDiffLevel = DifficultyInput;

                    foreach (var member in AllMembers)
                    {
                        if (member.Courage < 5.0)
                        {
                            Console.WriteLine($"{member.Name} was caught.");
                            member.SkillLevel = 0;
                        }
                    }

                    foreach (var member in AllMembers)
                    {
                        WholeTeamSkillLevel += member.SkillLevel;
                    }


                    int luck = new Random().Next(-10, 11);

                    Console.WriteLine();

                    BankDiffLevel += luck;

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
