using System;
using System.Collections.Generic;

namespace hungryNinja
{
    public class Ninja
    {
        private int calorieIntake;
        public int calorieLimit;
    public List<Food> FoodHistory;
     
    // add a constructor
    public Ninja(int CalorieIntake)
    {
        calorieIntake = CalorieIntake;
        calorieLimit = 1200;
        this.FoodHistory = new List<Food>();
    }
     
    // add a public "getter" property called "IsFull"
    public bool IsFull {
        get {
            return calorieIntake >= calorieLimit;
        }
    }
     
    // build out the Eat method
    public void Eat(Food item)
     {
            Console.WriteLine($"Ninja is about to each {item.Name}");
            if(this.IsFull)
            {
                Console.WriteLine($"Ninja is full");
            }
            else
            {
                this.calorieIntake += item.Calories;
                this.FoodHistory.Add(item);
                Console.WriteLine($"The Ninja ate {item.Name}");
            }
        }
    }
}