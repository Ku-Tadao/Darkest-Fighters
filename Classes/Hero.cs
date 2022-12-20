using System;
using System.Collections.Generic;

namespace Darkest_Fighters.Classes;

public class Hero : Player
{
    // Additional properties
    public int Experience { get; set; }
    public int Level { get; set; }

    // Constructor
    public Hero(string name, int maxHealth, int attack, int defense, int speed, int experience, int level)
        : base(name, maxHealth, attack, defense, speed)
    {
        Experience = experience;
        Level = level;
    }


    // Method to level up the hero
    public void LevelUp()
    {
        // Increase the hero's level and stats
        Level++;
        MaxHealth += 10;
        Attack += 2;
        Defense += 2;
        Speed += 1;

        // Fully heal the hero
        Health = MaxHealth;
    }
}
