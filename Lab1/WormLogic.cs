using System.Collections.Generic;

namespace Lab1
{
    public class WormLogic
    {
        public void WormAction(List<Worm> worms, Worm worm, NameGenerator nameGenerator, Food food)
        {
            if (worm.Vitality > 15)
            {
                BirthWormNear(worms, worm, nameGenerator, food);
                worm.EndOfAction();
            }
            else
            {
                Coordinates foodCoordinates = food.NearestPiece(worm.Position);
                MoveWormToFood(worms, worm, foodCoordinates, food);
                worm.EndOfAction();
            }
        }

        public void MoveWormToFood(List<Worm> worms, Worm worm, Coordinates foodCoordinates, Food food)
        {
            if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
            {
                Eat(worm, food);
            }

            if(worm.Position.X < foodCoordinates.X && WormsCoordinatesCheck(worms, worm.Position.X + 1, worm.Position.Y))
            {
                worm.MoveToRight();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm, food);
                }
            }else if(worm.Position.X > foodCoordinates.X && WormsCoordinatesCheck(worms, worm.Position.X - 1, worm.Position.Y))
            {
                worm.MoveToLeft();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm, food);
                }
            }else if(worm.Position.Y < foodCoordinates.Y && WormsCoordinatesCheck(worms,worm.Position.X, worm.Position.Y + 1))
            {
                worm.MoveToUp();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm, food);
                }
            }else if(worm.Position.Y > foodCoordinates.Y && WormsCoordinatesCheck(worms, worm.Position.X, worm.Position.Y - 1))
            {
                worm.MoveToDown();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm, food);
                }
            }
        }

        public void BirthWormNear(List<Worm> worms, Worm worm, NameGenerator nameGenerator, Food food)
        {
            if(CoordinatesCheck(worms,worm.Position.X + 1, worm.Position.Y, food))
            {
                BirthWorm(worms, worm, worm.Position.X + 1, worm.Position.Y, nameGenerator);
            }else if(CoordinatesCheck(worms,worm.Position.X, worm.Position.Y + 1, food))
            {
                BirthWorm(worms, worm, worm.Position.X, worm.Position.Y + 1, nameGenerator);
            }else if(CoordinatesCheck(worms,worm.Position.X - 1, worm.Position.Y, food))
            {
                BirthWorm(worms, worm, worm.Position.X - 1, worm.Position.Y, nameGenerator);
            }else if(CoordinatesCheck(worms,worm.Position.X, worm.Position.Y - 1, food))
            {
                BirthWorm(worms, worm, worm.Position.X, worm.Position.Y - 1, nameGenerator);
            }
        }

        public bool CoordinatesCheck(List<Worm> worms, int x, int y, Food food)
        {
            for (int i = 0; i < worms.Count; i++)
            {
                if (worms[i].Position.X == x && worms[i].Position.Y == y)
                {
                    return false;
                }
            }

            for (int i = 0; i < food.PositionArray.Count; i++)
            {
                if (food.PositionArray[i] != null && food.PositionArray[i].X == x && food.PositionArray[i].Y == y)
                {
                    return false;
                }
                
            }
            return true;
        }
        
        public bool WormsCoordinatesCheck(List<Worm> worms, int x, int y)
        {
            for (int i = 0; i < worms.Count; i++)
            {
                if (worms[i].Position.X == x && worms[i].Position.Y == y)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        public void BirthWorm(List<Worm> worms, Worm worm, int x, int y, NameGenerator nameGenerator)
        {
            Worm newWorm = new Worm(worm.FileWriter, nameGenerator, x, y);
            worms.Add(newWorm);
            worm.Vitality = worm.Vitality - 10;
        }

        public void Eat(Worm worm, Food food)
        {
            worm.Vitality = worm.Vitality + 10;
            food.DeleteFood(food, worm.Position.X, worm.Position.Y);
        }
    }
}