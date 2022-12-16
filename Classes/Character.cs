using System;

namespace Darkest_Fighters.Classes
{
    internal class Character
    {
        public Character(string name, string faction, int health, int attackDamage, int armor, Hero hero, string type, int experiencePoints, int id)
        {
            Name = name;
            Faction = faction;
            Health = health;
            AttackDamage = attackDamage;
            Armor = armor;
            Hero = hero;
            Type = type;
            ExperiencePoints = experiencePoints;
            Id = id;
        }


        // The Hero object to which this Character object belongs
        public Hero Hero { get; set; }

        public string Name { get; }
        public string Faction { get; }
        public int Health { get; set; }
        public int AttackDamage { get; }
        public int Armor { get; }
        public string Type { get; }
        public int Id { get; }
        public bool IsDead => Health <= 0;

        // The amount of experience points awarded to the hero when this character is defeated.
        public int ExperiencePoints { get; }
        public int Gold { get; internal set; }

        public void DealDamage(int damage)
        {
            Health -= damage;
        }

        public void Heal(int amount)
        {
            Health += amount;
        }

        public void TakeDamage(int damage)
        {
            Health -= Math.Max(0, damage - Armor);
        }

        public void Defend()
        {
            // Implement defense logic here
        }
    }
}