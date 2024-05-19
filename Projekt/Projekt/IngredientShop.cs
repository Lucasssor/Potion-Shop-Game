using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class IngredientShop
    {

        public static int  userBalance = 150;

        Random random = new Random();

        Dictionary<Storage.IngredientType, int> ingredients = new Dictionary<Storage.IngredientType, int>();

        
        Storage.IngredientType[] keys = (Storage.IngredientType[])Enum.GetValues(typeof(Storage.IngredientType));

        public void GenerateShop()
        {
            foreach (var key in keys)
            {
                int rnd = random.Next(1, 5);
                ingredients.Add(key, rnd);
            }
            foreach (var kvp in ingredients)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        public void DisplayIngredients()
        {
            
            Console.WriteLine("Available Ingredients in the Shop:");
            foreach (var item in ingredients)
            {
                Console.WriteLine($"{item.Key} - quantity: {item.Value} - Price: {GetIngredientPrice(item.Key)}");
            }
        }

        public void BuyIngredient(Storage.IngredientType ingredientType)
        {
            
            int ingredientPrice = GetIngredientPrice(ingredientType);

            if (userBalance >= ingredientPrice && ingredients.ContainsKey(ingredientType) && ingredients[ingredientType] > 0)
            {              
                userBalance -= ingredientPrice;
               
                ingredients[ingredientType]--;
                
                Storage.storage[ingredientType]++;

                Console.WriteLine($"You bought {ingredientType} for {ingredientPrice} gold. Your new balance: {userBalance} gold.");
            }
            else if (userBalance < ingredientPrice && ingredients[ingredientType] <= 0)
            {
                Console.WriteLine("Unable to buy the ingredient. Not enough gold and the ingredient is not available.");               
            }
            else if (userBalance < ingredientPrice)
            {
                Console.WriteLine("Not enough gold to buy the ingredient.");
            }
            else if (!ingredients.ContainsKey(ingredientType) || ingredients[ingredientType] <= 0)
            {
                Console.WriteLine("The ingredient is not available.");
            }
            
        }
        public int GetIngredientPrice(Storage.IngredientType ingredientType)
        {

            switch (ingredientType)
            {
                case Storage.IngredientType.root_of_mandrake:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 8;
                    }
                    else
                        return 4;

                case Storage.IngredientType.unicorn_horn:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 15;
                    }
                    else
                        return 8;                   
                case Storage.IngredientType.dragon_scale:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 10;
                    }
                    else
                        return 5;
                case Storage.IngredientType.wing_of_bat:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 6;
                    }
                    else
                        return 3;
                    
                case Storage.IngredientType.arctic_moss:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 8;
                    }
                    else
                        return 4;                  
                case Storage.IngredientType.fang_of_snake:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 20;
                    }
                    else
                        return 10;
                    
                case Storage.IngredientType.golden_seed:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 14;
                    }
                    else
                        return 7;
                case Storage.IngredientType.black_pearl:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 12;
                    }
                    else
                        return 6;
                case Storage.IngredientType.white_mushroom:
                    if (ingredients[ingredientType] < 5)
                    {
                        return 14;
                    }
                    else
                        return 7;                 
                default:
                    return 0;
            }
        }
        public void RestockIngredients()
        {
            int restockPrice = 50;

            if (userBalance >= restockPrice)
            {
                foreach (var ingredientType in ingredients.Keys)
                {
                    ingredients[ingredientType] += 3;
                }

                userBalance -= restockPrice;

                Console.WriteLine($"Ingredients restocked for {restockPrice} gold. Your new balance: {userBalance} gold.");
            }
            else
            {
                Console.WriteLine("Not enough gold to restock ingredients.");
            }
        }
        public int GetBalance()
        {
            return userBalance;
        }

    }
}
