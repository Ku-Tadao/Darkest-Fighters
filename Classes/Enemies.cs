using System;
using System.Collections.Generic;

namespace Darkest_Fighters.Classes;

public class Enemy : Player
{
    // Additional properties
    public int Reward { get; set; }
    public string Rarity { get; set; }
    public static readonly List<string> EpicEnemies = new()
    {
        "Chemtech Drake", "Cloud Drake", "Hextech Drake", "Infernal Drake", "Mountain Drake", "Ocean Drake",
        "Baron Nashor", "Elder Dragon", "Rift Herald"
    };
    public static readonly List<string> RareEnemies = new()
    {
        "Ancient Krug", "Blue Sentinel", "Crimson Raptor",
        "Greater Murk Wolf", "Gromp", "Red Brambleback"
    };
    public static readonly List<string> UncommonEnemies = new()
    {
        "Crimson Raptor", "Gromp", "Murk Wolf", "Red Brambleback", "Small Golem", "Wolf"
    };

    // Constructor
    public Enemy( int maxHealth, int attack, int defense, int speed, int reward)
        : base(GetRandomName(), maxHealth, attack, defense, speed, rarity)
    {
        Reward = reward;
        Rarity = rarity;

        // Modify the stats based on the rarity of the enemy
        switch (rarity)
        {
            case "Epic":
                MaxHealth += 50;
                Attack += 5;
                Defense += 5;
                Speed += 5;
                break;
            case "Rare":
                MaxHealth += 25;
                Attack += 3;
                Defense += 3;
                Speed += 3;
                break;
            case "Uncommon":
                MaxHealth += 10;
                Attack += 1;
                Defense += 1;
                Speed += 1;
                break;
        }



        public static string GetRandomName()
    {
        Random random = new();
        int rarityIndex = random.Next(4);
        return rarityIndex switch
        {
            0 => EpicEnemies[random.Next(EpicEnemies.Count)],
            1 => RareEnemies[random.Next(RareEnemies.Count)],
            2 => UncommonEnemies[random.Next(UncommonEnemies.Count)],
            _ => "Goblin"
        };
    }

}