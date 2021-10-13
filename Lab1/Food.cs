using System;

namespace Lab1
{
    public class Food
    {
        private Coordinates[] _positionArray = new Coordinates[10] {null, null, null, null, null, null, null, null, null, null};
        //private int _numOfArray;
        
        public Coordinates[] PositionArray
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

        public Coordinates PositionSelection()
        {
            for (int i = 0; i < 9; i++)
            {
                _positionArray[i + 1] = _positionArray[i];
            }

            _positionArray[0].X = NormalDistribution.NextNormal();
            _positionArray[0].Y = NormalDistribution.NextNormal();
            
            return _positionArray[0];
        }

        public void DeleteFood(int numOfArray)
        {
            _positionArray[numOfArray] = null;
        }

        public Coordinates NearestPiece(Coordinates position)
        {
            int minDistance = Int32.MaxValue;
            int minDistanceNum = 0;
            for (int i = 0; i < 10; i++)
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