using System;
using System.IO;

namespace Lab1
{
    public class Worm
    {
        private string _name;
        private int[] _position;
        private StreamWriter _file;
        
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
        public int[] Position
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
            _position = new int[2] {0, 0};
        }

        public int[] MoveToRight()
        {
            _position[0] = _position[0] + 1;
            WriteCoordinatesToFile();
            return _position;
        }
        
        public int[] MoveToLeft()
        {
            _position[0] = _position[0] - 1;
            WriteCoordinatesToFile();
            return _position;
        }
        public int[] MoveToUp()
        {
            _position[1] = _position[1] + 1;
            WriteCoordinatesToFile();
            return _position;
        }
        public int[] MoveToDown()
        {
            _position[1] = _position[1] - 1;
            WriteCoordinatesToFile();
            return _position;
        }
        
        public int[] Nothing()
        {
            WriteCoordinatesToFile();
            return _position;
        }

        public void WriteCoordinatesToConsole()
        {
            Console.WriteLine("Worms:[" + _name + "(" + _position[0] + "," + _position[1] + ")]");
        }
        
        public void WriteCoordinatesToFile()
        {
            _file.WriteLine("Worms:[" + _name + "(" + _position[0] + "," + _position[1] + ")]");
        }

        public void OpenFile()
        {
            _file = new StreamWriter("C:/Users/Vladimir/RiderProjects/Lab1_CSharp/Lab1/coordinates.txt", false);
        }
        public void CloseFile()
        {
            _file.Close();
        }

        
    }
}