namespace Lab1
{
    public class Worm
    {
        private string _name;
        private int[] _position;
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

        public int[] moveToRight()
        {
            _position[0] = _position[0] + 1;
            return _position;
        }
        
        public int[] moveToLeft()
        {
            _position[0] = _position[0] - 1;
            return _position;
        }
        public int[] moveToUp()
        {
            _position[1] = _position[1] + 1;
            return _position;
        }
        public int[] moveToDown()
        {
            _position[1] = _position[1] - 1;
            return _position;
        }
        
        public int[] Nothing()
        {
            return _position;
        }

        
    }
}