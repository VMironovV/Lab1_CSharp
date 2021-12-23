using System.Collections.Generic;

namespace Lab1
{
    public class FoodGenerator
    {
        public void GenerateFood(Food food)
        {
            Coordinates coordinates;
            do
            {
                coordinates = GenerateCoordinates();
            } while (CoordinatesCheck(food, coordinates.X, coordinates.Y));

            PositionSelection(food, coordinates.X, coordinates.Y);
        }
        
        public void GenerateFood(Food food, int x, int y)
        {
            if (CoordinatesCheck(food, x, y))
            {
                PositionSelection(food, x, y);
            }
        }

        public Coordinates GenerateCoordinates()
        {
            Coordinates coordinates = new Coordinates();
            coordinates.X = NormalDistribution.NextNormal();
            coordinates.Y = NormalDistribution.NextNormal();
            return coordinates;
        }
        
        public void PositionSelection(Food food, int x, int y)
        {
            int end = food.PositionArray.Count;
            for (int i = end - 1; i > -1; i--)
            {
                if (i + 1 == end)
                {
                    food.PositionArray.Add(food.PositionArray[i]);
                }
                else
                {
                    food.PositionArray[i + 1] = food.PositionArray[i];
                }
            }

            if (food.PositionArray.Count > 10)
            {
                food.PositionArray.RemoveAt(10);
            }

            Coordinates coordinates = new Coordinates();
            coordinates.X = NormalDistribution.NextNormal();
            coordinates.Y = NormalDistribution.NextNormal();
            if (food.PositionArray.Count == 0)
            {
                food.PositionArray.Add(coordinates);
            }
            else
            {
                food.PositionArray[0] = coordinates;
            }
        }
        
        public bool CoordinatesCheck(Food food, int x, int y)
        {
            for (int i = 0; i < food.PositionArray.Count; i++)
            {
                if (food.PositionArray[i] != null && food.PositionArray[i].X == x && food.PositionArray[i].Y == y)
                {
                        return true;
                }
                
            }
            return false;
        }
    }
}