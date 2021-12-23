using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Food
    {
        private List<Coordinates> _positionArray = new List<Coordinates>();
        //private int _numOfArray;
        
        public List<Coordinates> PositionArray
        {
            get
            {
                return _positionArray;
            }
            set
            {
                _positionArray = value;
            }
            
        }

        public void DeleteFood(Food food, int x, int y)
        {
            for (int i = 0; i < _positionArray.Count; i++)
            {
                if(food.PositionArray[i] != null && _positionArray[i].X == x && _positionArray[i].Y == y)
                {
                    _positionArray[i] = null;
                }
            }
        }
        
        public void DeleteFood(int i)
        {
            _positionArray.RemoveAt(i);
        }

        public Coordinates NearestPiece(Coordinates position)
        {
            int minDistance = Int32.MaxValue;
            int minDistanceNum = 0;
            for (int i = 0; i < _positionArray.Count; i++)
            {
                if (_positionArray[i] != null)
                {
                    int sum = Math.Abs((Math.Abs(_positionArray[i].X) + Math.Abs(_positionArray[i].Y)) - (Math.Abs(position.X) + Math.Abs(position.Y)));
                    if (sum <= minDistance)
                    {
                        minDistance = sum;
                        minDistanceNum = i;
                    }
                }
            }
            return _positionArray[minDistanceNum];
        }
        
        
    }
}