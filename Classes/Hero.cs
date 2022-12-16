using System;
using System.Collections.Generic;

namespace Darkest_Fighters.Classes;

internal class Hero
{
    
    private readonly Random _rng = new Random();

    public Hero(string? heroType, int maxHealthPoints, Enemies enemies)
    {
        MaxHealthPoints = maxHealthPoints;
        Enemies = enemies;
        switch (heroType)
        {
            case "Bruiser":
                HealthPoints = _rng.Next(18, 25);
                AttackDamage = _rng.Next(5, 15);
                AttackResist = _rng.Next(5, 15);
                break;
            case "Assassin":
                HealthPoints = _rng.Next(5, 15);
                AttackDamage = _rng.Next(3, 20);
                AttackResist = _rng.Next(0, 10);
                break;
            case "Tank":
                HealthPoints = _rng.Next(15, 40);
                AttackDamage = _rng.Next(1, 10);
                AttackResist = _rng.Next(10, 25);
                break;
        }
        Level = 1;
        ExperiencePoints = 0;
        Gold = 0;
    }

    // List of enemy characters that belong to this Hero instance
    public List<Character> Characters { get; } = new List<Character>();

    // The Enemies object to which this Hero object belongs
    public Enemies Enemies { get; set; }

    // The current health points of the hero.
    public int HealthPoints { get; set; }

    // The maximum health points of the hero.
    public int MaxHealthPoints { get; }


    // The amount of damage the hero can deal to enemies.
    public int AttackDamage { get; private set; }

    // The hero's resistance to damage from enemy attacks.
    public int AttackResist { get; private set; }

    // The current level of the hero.
    public int Level { get; private set; }

    // The current experience points of the hero.
    public int ExperiencePoints { get; private set; }

    // The amount of gold that the hero currently has.
    public int Gold { get; private set; }

    public void AddExperiencePoints(int experiencePoints)
    {
        ExperiencePoints += experiencePoints;
        int levelUpExperience = Level * 100;
        while (ExperiencePoints >= levelUpExperience)
        {
            Level++;
            levelUpExperience = Level * 100;
        }
    }

    public int GetAttackResist()
    {
        return AttackResist;
    }

    public int GetLevel()
    {
        return Level;
    }



    public int GetExperiencePoints()
    {
        return ExperiencePoints;
    }

    public int GetAttackDamage()
    {
        return AttackDamage;
    }


    public int GetHealthPoints()
    {
        return HealthPoints;
    }


    public void AddGold(int gold)
    {
        Gold += gold;
    }


    public void Attack(Character enemy)
    {
        enemy.TakeDamage(AttackDamage);
    }

    public void Heal(int healing)
    {
        HealthPoints = Math.Min(HealthPoints + healing, MaxHealthPoints);
    }


    private void LevelUp()
    {
        int levelUpExperiencePoints = Level * 1000;
        if (ExperiencePoints >= levelUpExperiencePoints)
        {
            ExperiencePoints -= levelUpExperiencePoints;
            Level++;
        }
    }

    public void TakeDamage(int damage)
    {
        HealthPoints -= Math.Max(damage - AttackResist, 0);
    }


    public void Attack(Enemies enemies)
    {
        foreach (Character enemy in enemies.Characters)
        {
            int damage = AttackDamage - enemy.Armor;
            if (damage > 0)
            {
                enemy.Health -= damage;
            }
        }
    }


}