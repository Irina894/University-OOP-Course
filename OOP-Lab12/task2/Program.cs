using System;
using System.Collections.Generic;

namespace KingsGambit
{
    public delegate void AttackEventHandler();

    public class King
    {
        public string Name { get; private set; }
        public event AttackEventHandler UnderAttack;

        public King(string name)
        {
            Name = name;
        }

        public void OnAttack()
        {
            Console.WriteLine("King " + Name + " is under attack!");
            if (UnderAttack != null)
                UnderAttack();
        }
    }

    public class RoyalGuard
    {
        public string Name { get; private set; }

        public RoyalGuard(string name)
        {
            Name = name;
        }

        public void Respond()
        {
            Console.WriteLine("Royal Guard " + Name + " is defending!");
        }
    }

    public class Footman
    {
        public string Name { get; private set; }

        public Footman(string name)
        {
            Name = name;
        }

        public void Respond()
        {
            Console.WriteLine("Footman " + Name + " is panicking!");
        }
    }

    class Program
    {
        static void Main()
        {
            string kingName = Console.ReadLine();
            string[] guardsNames = Console.ReadLine().Split(' ');
            string[] footmenNames = Console.ReadLine().Split(' ');

            King king = new King(kingName);

            List<RoyalGuard> guards = new List<RoyalGuard>();
            List<Footman> footmen = new List<Footman>();

            foreach (var name in guardsNames)
            {
                RoyalGuard guard = new RoyalGuard(name);
                guards.Add(guard);
                king.UnderAttack += guard.Respond;
            }

            foreach (var name in footmenNames)
            {
                Footman footman = new Footman(name);
                footmen.Add(footman);
                king.UnderAttack += footman.Respond; 
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split(' ');

                if (parts[0] == "Attack")
                {
                    king.OnAttack();
                }
                else if (parts[0] == "Kill")
                {
                    string nameToKill = parts[1];

                    RoyalGuard guardToKill = guards.Find(g => g.Name == nameToKill);
                    if (guardToKill != null)
                    {
                        king.UnderAttack -= guardToKill.Respond;
                        guards.Remove(guardToKill);
                    }
                    else
                    {
                        Footman footmanToKill = footmen.Find(f => f.Name == nameToKill);
                        if (footmanToKill != null)
                        {
                            king.UnderAttack -= footmanToKill.Respond;
                            footmen.Remove(footmanToKill);
                        }
                    }
                }

                input = Console.ReadLine();
        }
        }
    }
}
