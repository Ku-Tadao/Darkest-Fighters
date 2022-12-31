class Hero : Player
{
    // private field for encapsulation
    private int _healPower;

    // get/set method for encapsulation
    public int HealPower
    {
        get { return _healPower; }
        set { _healPower = value; }
    }

    // constructor with default values
    public Hero(int health = 100, int mana = 50, string name = "", double attackPower = 10, int healPower = 20) : base(health, mana, name, attackPower)
    {
        _healPower = healPower;
    }

    // method for healing self
    public void Heal()
    {
        Health += _healPower;
    }

    // method overload for healing self with a custom heal power
    public void Heal(int healPower)
    {
        Health += healPower;
    }
}
