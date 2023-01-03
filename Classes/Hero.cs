using System;
using System.Windows;

namespace Darkest_Fighters.Classes;

public class Hero : Player
{
    public Hero(string name, int health, int mana, int attackPower, int healPower)
        : base(name, health, mana, attackPower, healPower)
    {
    }

    public virtual int Attack(AttackType attackType, Player target)
    {
        var damage = 0;
        switch (attackType)
        {
            case AttackType.Normal:
                damage = AttackPower;
                break;
            case AttackType.Magic:
                if (Mana >= 10)
                {
                    damage = AttackPower * 2;
                    Mana -= 10;
                }
                else
                {
                    MessageBox.Show("Not enough mana for magic attack!");
                }

                break;
            case AttackType.Critical:
                if (Mana >= 20)
                {
                    damage = AttackPower * 3;
                    Mana -= 20;
                }
                else
                {
                    MessageBox.Show("Not enough mana for critical attack!");
                }

                break;
            case AttackType.Poison:
                if (Mana >= 5)
                {
                    target.TakeDamage(AttackPower);
                    Mana -= 5;
                    // Start a timer or some other mechanism to apply poison damage over time
                }
                else
                {
                    MessageBox.Show("Not enough mana for poison attack!");
                }

                break;
            case AttackType.Heal:
                if (Mana >= 10)
                {
                    Health += HealPower;
                    Mana -= 10;
                }
                else
                {
                    MessageBox.Show("Not enough mana to heal!");
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
        }

        return damage;
    }

    public virtual int Attack(Player target)
    {
        return Attack(AttackType.Normal, target);
    }

    public virtual int Heal()
    {
        return HealPower;
    }
}