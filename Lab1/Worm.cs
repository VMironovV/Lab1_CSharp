using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    public class Worm
    {
        private string _name;
        private Coordinates _position;
        private int _vitality;

        public int Vitality
        {
            get
            {
                return _vitality;
            }
            set
            {
                _vitality = value;
            }
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
            
        }
        public Coordinates Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
            
        }
        
        public Worm()
        {
            _name = NameGenerator.GenerateName(6);
            _position = new Coordinates();
            _position.X = 0;
            _position.Y = 0;
            _vitality = 10;

        }
        
        public Worm(int x, int y)
        {
            _name = NameGenerator.GenerateName(6);
            _position = new Coordinates();
            _position.X = x;
            _position.Y = y;
            _vitality = 10;

        }

        public Coordinates MoveToRight()
        {
            _position.X = _position.X + 1;
            FileWriter.WriteCoordinatesToFile(_name, _vitality, _position.X, _position.Y);
            return _position;
        }
        
        public Coordinates MoveToLeft()
        {
            _position.X = _position.X - 1;
            FileWriter.WriteCoordinatesToFile(_name, _vitality, _position.X, _position.Y);
            return _position;
        }
        public Coordinates MoveToUp()
        {
            _position.Y = _position.Y + 1;
            FileWriter.WriteCoordinatesToFile(_name, _vitality, _position.X, _position.Y);
            return _position;
        }
        public Coordinates MoveToDown()
        {
            _position.Y = _position.Y - 1;
            FileWriter.WriteCoordinatesToFile(_name, _vitality, _position.X, _position.Y);
            return _position;
        }
        
        public Coordinates Nothing()
        {
            FileWriter.WriteCoordinatesToFile(_name, _vitality, _position.X, _position.Y);
            return _position;
        }

        public void WriteCoordinatesToConsole()
        {
            Console.WriteLine("Worms:[" + _name + "(" + _position.X + "," + _position.Y + ")]");
        }

        public void EndOfAction()
        {
            _vitality = _vitality - 1;
        }

        

        
    }
}