using System.Collections.Generic;

namespace Lab1
{
    public class WormLogic
    {
        public void WormAction(List<Worm> worms, Worm worm)
        {
            if (worm.Vitality > 15)
            {
                BirthWormNear(worms, worm);
                worm.EndOfAction();
            }
            else
            {
                Coordinates foodCoordinates = Food.NearestPiece(worm.Position);
                MoveWormToFood(worms, worm, foodCoordinates);
                worm.EndOfAction();
            }
        }

        public void MoveWormToFood(List<Worm> worms, Worm worm, Coordinates foodCoordinates)
        {
            if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
            {
                Eat(worm);
                worm.Nothing();
            }else if(worm.Position.X < foodCoordinates.X && WormsCoordinatesCheck(worms, worm.Position.X + 1, worm.Position.Y))
            {
                worm.MoveToRight();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm);
                }
            }else if(worm.Position.X > foodCoordinates.X && WormsCoordinatesCheck(worms, worm.Position.X - 1, worm.Position.Y))
            {
                worm.MoveToLeft();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm);
                }
            }else if(worm.Position.Y < foodCoordinates.Y && WormsCoordinatesCheck(worms,worm.Position.X, worm.Position.Y + 1))
            {
                worm.MoveToUp();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm);
                }
            }else if(worm.Position.Y > foodCoordinates.Y && WormsCoordinatesCheck(worms, worm.Position.X, worm.Position.Y - 1))
            {
                worm.MoveToDown();
                if (worm.Position.X == foodCoordinates.X && worm.Position.Y == foodCoordinates.Y)
                {
                    Eat(worm);
                }
            }
        }

        public void BirthWormNear(List<Worm> worms, Worm worm)
        {
            if(CoordinatesCheck(worms,worm.Position.X + 1, worm.Position.Y))
            {
                BirthWorm(worms, worm, worm.Position.X + 1, worm.Position.Y);
            }else if(CoordinatesCheck(worms,worm.Position.X, worm.Position.Y + 1))
            {
                BirthWorm(worms, worm, worm.Position.X, worm.Position.Y + 1);
            }else if(CoordinatesCheck(worms,worm.Position.X - 1, worm.Position.Y))
            {
                BirthWorm(worms, worm, worm.Position.X - 1, worm.Position.Y);
            }else if(CoordinatesCheck(worms,worm.Position.X, worm.Position.Y - 1))
            {
                BirthWorm(worms, worm, worm.Position.X, worm.Position.Y - 1);
            }
        }

        public bool CoordinatesCheck(List<Worm> worms, int x, int y)
        {
            for (int i = 0; i < worms.Count; i++)
            {
                if (worms[i].Position.X == y && worms[i].Position.Y == y)
                {
                    return false;
                }
            }

            for (int i = 0; i < Food.PositionArray.Count; i++)
            {
                if (Food.PositionArray[i] != null && Food.PositionArray[i].X == x && Food.PositionArray[i].Y == y)
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
                if (worms[i].Position.X == y && worms[i].Position.Y == y)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        public void BirthWorm(List<Worm> worms, Worm worm, int x, int y)
        {
            Worm newWorm = new Worm(worm.FileWriter, x, y);
            worms.Add(newWorm);
            worm.Vitality = worm.Vitality - 10;
        }

        public void Eat(Worm worm)
        {
            worm.Vitality = worm.Vitality + 10;
            Food.DeleteFood(worm.Position.X, worm.Position.Y);
        }
    }
}