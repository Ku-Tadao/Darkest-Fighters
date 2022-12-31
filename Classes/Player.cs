﻿class Player
{
    // private fields for encapsulation
    private int _health;
    private int _mana;
    private string _name;
    private double _attackPower;
    private bool _isAlive;

    // get/set methods for encapsulation
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int Mana
    {
        get { return _mana; }
        set { _mana = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public double AttackPower
    {
        get { return _attackPower; }
        set { _attackPower = value; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    // constructor with default values
    public Player(int health = 100, int mana = 50, string name = "", double attackPower = 10)
    {
        _health = health;
        _mana = mana;
        _name = name;
        _attackPower = attackPower;
        _isAlive = true;
    }

    // method for attacking another player
    public void Attack(Player target)
    {
        target.Health -= (int)_attackPower;
        if (target.Health <= 0)
        {
            target.IsAlive = false;
        }
    }

    // method overload for attacking another player with a custom attack power
    public void Attack(Player target, double attackPower)
    {
        target.Health -= (int)attackPower;
        if (target.Health <= 0)
        {
            target.IsAlive = false;
        }
    }
}