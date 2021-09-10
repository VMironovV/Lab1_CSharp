namespace Lab1
{
    public class Worm
    {
        private int[] _position;
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
            _position = new int[2] {0, 0};
        }
    }
}