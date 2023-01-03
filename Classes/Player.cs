namespace Darkest_Fighters.Classes;

public abstract class Player
{
    public enum AttackType
    {
        Normal,
        Magic,
        Critical,
        Poison,
        Heal
    }

    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int AttackPower { get; set; }
    public int HealPower { get; set; }

    protected Player(string name, int health, int mana, int attackPower, int healPower)
    {
        Name = name;
        Health = health;
        Mana = mana;
        AttackPower = attackPower;
        HealPower = healPower;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}