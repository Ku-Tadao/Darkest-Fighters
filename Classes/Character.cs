namespace Darkest_Fighters.Classes;

internal class Character
{
    public Character(string name, string faction, int health, int attackDamage, int armor)
    {
        Name = name;
        Faction = faction;
        Health = health;
        AttackDamage = attackDamage;
        Armor = armor;
    }

    public string Name { get; }
    public string Faction { get; }
    public int Health { get; private set; }
    public int AttackDamage { get; }
    public int Armor { get; }

}