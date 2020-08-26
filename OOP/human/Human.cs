namespace human
{
    public class Human
    {
        // Fields for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int health;
     
    // add a public "getter" property to access health
    public int Health
    {
        get { return health; }
    }
     
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        health = 100;
    }

     
    // Add a constructor to assign custom values to all fields
    public Human(string name, int strength, int intelligence, int dexterity, int Health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        health = Health;
    }


     
    // Build Attack method
    public int Attack(Human target)
    {
        target.health = target.health - (5*this.Strength);
        return target.health;

        
    }
    }
}