using System;
using System.Collections.Generic;

namespace KingsGambitExtended
{
    public delegate void AttackEventHandler();
    public delegate void UnitDiedEventHandler(object sender, EventArgs e);

    public class King
    {
        public string Name { get; private set; }
        public event AttackEventHandler UnderAttack;

        public King(string name)
        {
            Name = name;
        }

        public void Attack()
        {
            Console.WriteLine("King " + Name + " is under attack!");
            if (UnderAttack != null)
                UnderAttack();
        }
    }

    public abstract class Soldier
    {
        public string Name { get; private set; }
        protected int HitPoints;
        public event UnitDiedEventHandler Died;

        protected Soldier(string name, int hitPoints)
        {
            Name = name;
            HitPoints = hitPoints;
        }

        public void TakeHit()
        {
            HitPoints--;
            if (HitPoints <= 0)
            {
                OnDied();
            }
        }

        protected void OnDied()
        {
            if (Died != null)
                Died(this, EventArgs.Empty);
        }

        public abstract void Respond();
    }
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name, 3) { }

        public override void Respond()
        {
            Console.WriteLine("Royal Guard " + Name + " is defending!");
        }
    }
    public class Footman : Soldier
    {
        public Footman(string name) : base(name, 2) { }

        public override void Respond()
        {
            Console.WriteLine("Footman " + Name + " is panicking!");
        }
    }
    public class SoldiersCollection
    {
        private List<Soldier> guards = new List<Soldier>();
        private List<Soldier> footmen = new List<Soldier>();
        private King king;

        public SoldiersCollection(King king)
        {
            this.king = king;
        }

        public void AddRoyalGuard(RoyalGuard guard)
        {
            guards.Add(guard);
            king.UnderAttack += guard.Respond;
            guard.Died += RemoveSoldier;
        }

        public void AddFootman(Footman footman)
        {
            footmen.Add(footman);
            king.UnderAttack += footman.Respond;
            footman.Died += RemoveSoldier;
        }

        private void RemoveSoldier(object sender, EventArgs e)
        {
            Soldier s = sender as Soldier;
            if (s == null) return;

            king.UnderAttack -= s.Respond;

            if (s is RoyalGuard)
                guards.Remove(s);
            else if (s is Footman)
                footmen.Remove(s);
        }

        public void Kill(string name)
        {
            for (int i = 0; i < guards.Count; i++)
            {
                if (guards[i].Name == name)
                {
                    guards[i].TakeHit();
                    return;
                }
            }
            for (int i = 0; i < footmen.Count; i++)
            {
                if (footmen[i].Name == name)
                {
                    footmen[i].TakeHit();
                    return;
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);

            string[] guardsNames = Console.ReadLine().Split(' ');
            string[] footmenNames = Console.ReadLine().Split(' ');

            SoldiersCollection soldiers = new SoldiersCollection(king);

            foreach (var name in guardsNames)
                soldiers.AddRoyalGuard(new RoyalGuard(name));

            foreach (var name in footmenNames)
                soldiers.AddFootman(new Footman(name));

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] parts = input.Split(' ');

                if (parts[0] == "Attack" || parts[0] == "Атакувати")
                {
                    king.Attack();
                }
                else if (parts[0] == "Kill")
                {
                    string nameToKill = parts[1];
                    soldiers.Kill(nameToKill);
                }

                input = Console.ReadLine();
            }
        }
    }
}
