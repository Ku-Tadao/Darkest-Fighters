using System;

namespace Darkest_Fighters.Classes;

internal class Hero
{
    
    private readonly Random _rng = new Random();

    public Hero(string? heroType)
    {
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



    // The current health points of the hero.
    public int HealthPoints { get; private set; }

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
}