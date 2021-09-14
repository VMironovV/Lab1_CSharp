using System;

namespace Lab1
{
    public class Earth
    {
        private const int DAYS = 100;
        public void Life()
        {
            Worm worm = new Worm();
            for (int i = 0; i < DAYS; i++)
            {
                int[] position = worm.Position;
                switch (position[0], position[1])
                {
                    
                    
                }
                
            }
            int[] end = worm.Position;
            Console.WriteLine("Worms: [" + worm.Name + "(" + end[0] + "," + end[1] + ")]");
            end = worm.moveToRight();
            Console.WriteLine("Worms: [" + worm.Name + "(" + end[0] + "," + end[1] + ")]");
        }
    }
}