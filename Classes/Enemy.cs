using System;

namespace Darkest_Fighters.Classes;

public class Enemy : Player
{
    private readonly Random _rng;

    public Enemy(string name, int health, int mana, int attackPower, int healPower)
        : base(name, health, mana, attackPower, healPower)
    {
        _rng = new Random();
    }

    public virtual int Attack(Player target)
    {
        var damage = AttackPower;
        var criticalChance = _rng.Next(1, 101); // Generate random number between 1 and 100
        if (criticalChance <= 20) // 20% chance of critical hit
        {
            damage *= 2;
        }
        target.TakeDamage(damage);
        return damage;
    }
}