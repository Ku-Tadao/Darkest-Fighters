namespace Darkest_Fighters.Classes;

internal class Enemy : Player
{
    // constructor with default values
    public Enemy(int health = 100, int mana = 50, string name = "", double attackPower = 10) : base(health, mana, name, attackPower)
    {
    }
}