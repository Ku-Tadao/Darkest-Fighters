﻿using System;
using System.Collections.Generic;

namespace Darkest_Fighters.Classes;

internal class Enemies
{
    // List of enemy names and it's rarity
    public List<string> EpicEnemies { get; } = new()
    {
        "Chemtech Drake", "Cloud Drake", "Hextech Drake", "Infernal Drake", "Mountain Drake", "Ocean Drake",
        "Baron Nashor", "Elder Dragon", "Rift Herald"
    };

    public List<string> RareEnemies { get; } = new()
    {
        "Ancient Krug", "Blue Sentinel", "Crimson Raptor",
        "Greater Murk Wolf", "Gromp", "Red Brambleback"
    };

    public List<string> UncommonEnemies { get; } = new()
        { "Crimson Raptor", "Gromp", "Murk Wolf", "Red Brambleback", "Small Golem", "Wolf" };

    public List<string> CommonEnemies { get; } = new() { "Murk Wolf", "Small Golem", "Wolf" };

    private readonly Random _rng = new Random();

    // Returns a random enemy name
    public List<string> RandomEnemies()
    {
        // Generate a random number between 0 and 100
        int randomNumber = _rng.Next(0, 101);

        // If the random number is between 0 and 10, return one random epic enemy
        if (randomNumber <= 10)
        {
            return new List<string> { EpicEnemies[_rng.Next(EpicEnemies.Count)] };
        }
        // If the random number is between 11 and 30, return one random rare enemy
        else if (randomNumber <= 30)
        {
            return new List<string> { RareEnemies[_rng.Next(RareEnemies.Count)] };
        }
        // If the random number is between 31 and 60, return two random uncommon enemies if possible
        else if (randomNumber <= 60)
        {
            // Check if there are at least two uncommon enemies remaining
            if (UncommonEnemies.Count >= 2)
            {
                // Get two random indexes
                int index1 = _rng.Next(UncommonEnemies.Count);
                int index2 = _rng.Next(UncommonEnemies.Count);

                // Make sure the indexes are different
                while (index1 == index2)
                {
                    index2 = _rng.Next(UncommonEnemies.Count);
                }

                // Get the two enemies at the specified indexes
                string enemy1 = UncommonEnemies[index1];
                string enemy2 = UncommonEnemies[index2];


                // Return the two enemies
                return new List<string> { enemy1, enemy2 };
            }
        }
        // If the random number is between 61 and 100, return two random common enemies if possible
        else if (randomNumber <= 100)
        {
            // Check if there are at least two common enemies remaining
            if (CommonEnemies.Count >= 2)
            {
                // Get two random indexes
                int index1 = _rng.Next(CommonEnemies.Count);
                int index2 = _rng.Next(CommonEnemies.Count);

                // Make sure the indexes are different
                while (index1 == index2)
                {
                    index2 = _rng.Next(CommonEnemies.Count);
                }

                // Get the two enemies at the specified indexes
                string enemy1 = CommonEnemies[index1];
                string enemy2 = CommonEnemies[index2];

                // Return the two enemies
                return new List<string> { enemy1, enemy2 };
            }
        }

        return null;
    }
}