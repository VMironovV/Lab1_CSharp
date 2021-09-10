namespace Lab1
{
    public class Worm
    {
        private int[] position;

        public Worm()
        {
            position = new int[2] {0, 0};
        }

        public int[] getPosition()
        {
            return position;
        }

        public void setPosition( int[] position)
        {
            this.position = position;
        }
    }
}