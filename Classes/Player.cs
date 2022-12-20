using System;

namespace Darkest_Fighters.Classes;

public class Player
{
    // Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public virtual int DefenseTurnsRemaining { get; set; }

    // Constructor
    public Player(string name, int maxHealth, int attack, int defense, int speed)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Attack = attack;
        Defense = defense;
        Speed = speed;
    }

    // Methods
    // Method to handle taking damage
    public virtual void TakeDamage(int damage)
    {
        // If the player is defending, reduce the damage it takes by its defense stat
        if (this.DefenseTurnsRemaining > 0)
        {
            damage -= this.Defense;
        }

        // Ensure that the player takes at least 1 point of damage
        damage = Math.Max(damage, 1);

        this.Health -= damage;
        if (this.Health < 0)
        {
            this.Health = 0;
        }
    }

public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}