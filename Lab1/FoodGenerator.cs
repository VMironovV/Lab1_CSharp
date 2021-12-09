using System.Collections.Generic;

namespace Lab1
{
    public class FoodGenerator
    {
        public void GenerateFood(List<Worm> worms)
        {
            Coordinates coordinates;
            do
            {
                coordinates = GenerateCoordinates();
            } while (CoordinatesCheck(worms, coordinates.X, coordinates.Y));

            PositionSelection(coordinates.X, coordinates.Y);
        }

        public Coordinates GenerateCoordinates()
        {
            Coordinates coordinates = new Coordinates();
            coordinates.X = NormalDistribution.NextNormal();
            coordinates.Y = NormalDistribution.NextNormal();
            return coordinates;
        }
        
        public void PositionSelection(int x, int y)
        {
            int end = Food.PositionArray.Count;
            for (int i = end - 1; i > -1; i--)
            {
                if (i + 1 == end)
                {
                    Food.PositionArray.Add(Food.PositionArray[i]);
                }
                else
                {
                    Food.PositionArray[i + 1] = Food.PositionArray[i];
                }
            }

            if (Food.PositionArray.Count > 10)
            {
                Food.PositionArray.RemoveAt(10);
            }

            Coordinates coordinates = new Coordinates();
            coordinates.X = NormalDistribution.NextNormal();
            coordinates.Y = NormalDistribution.NextNormal();
            if (Food.PositionArray.Count == 0)
            {
                Food.PositionArray.Add(coordinates);
            }
            else
            {
                Food.PositionArray[0] = coordinates;
            }
        }
        
        public bool CoordinatesCheck(List<Worm> worms, int x, int y)
        {
            for (int i = 0; i < worms.Count; i++)
            {
                if (worms[i].Position.X == y && worms[i].Position.Y == y)
                {
                    return true;
                }
            }

            for (int i = 0; i < Food.PositionArray.Count; i++)
            {
                if (Food.PositionArray[i] != null && Food.PositionArray[i].X == x && Food.PositionArray[i].Y == y)
                {
                        return true;
                }
                
            }
            return false;
        }
    }
}