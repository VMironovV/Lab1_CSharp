using System;
using System.IO;

namespace Lab1
{
    public class Worm
    {
        private string _name;
        private Coordinates _position;
        private StreamWriter _file;
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
            _name = "John";
            _position = new Coordinates();
            _position.X = 0;
            _position.Y = 0;
            _vitality = 20;

        }

        public Coordinates MoveToRight()
        {
            _position.X = _position.X + 1;
            WriteCoordinatesToFile();
            return _position;
        }
        
        public Coordinates MoveToLeft()
        {
            _position.X = _position.X - 1;
            WriteCoordinatesToFile();
            return _position;
        }
        public Coordinates MoveToUp()
        {
            _position.Y = _position.Y + 1;
            WriteCoordinatesToFile();
            return _position;
        }
        public Coordinates MoveToDown()
        {
            _position.Y = _position.Y - 1;
            WriteCoordinatesToFile();
            return _position;
        }
        
        public Coordinates Nothing()
        {
            WriteCoordinatesToFile();
            return _position;
        }

        public void WriteCoordinatesToConsole()
        {
            Console.WriteLine("Worms:[" + _name + "(" + _position.X + "," + _position.Y + ")]");
        }
        
        public void WriteCoordinatesToFile()
        {
            _file.WriteLine("Worms:[" + _name + "(" + _position.X + "," + _position.Y + ")]");
        }

        public void OpenFile()
        {
            _file = new StreamWriter("C:/Users/Vladimir/RiderProjects/Lab1_CSharp/Lab1/coordinates" + _name + ".txt", false);
        }
        public void CloseFile()
        {
            _file.Close();
        }

        
    }
}