using System;
using System.Collections.Generic;
namespace hungryNinja
{
    public class Buffet
    {
        public List<Food> Menu;
        public static Random rand = new Random();
     
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("apple", 1000, false, false),
            new Food("banana", 500, false, true),
            new Food("tuna", 300, true, false ),
            new Food("sushi", 1200, true, true),
            new Food("burger", 1500, false, false),
            new Food("pizza", 750, false, false),
            new Food("kiwi", 100, false, true)

           
        };
    }
     
    public Food Serve()
    {
        return Menu[rand.Next(Menu.Count)];
    }
    }
}