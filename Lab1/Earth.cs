using System;

namespace Lab1
{
    public class Earth
    {
        public void Life()
        {
            Worm worm = new Worm();
            worm.OpenFile();
            worm.Nothing();
            for (int i = 0; i < 5; i++)
            {
                worm.MoveToUp();
            }
            for (int i = 0; i < 5; i++)
            {
                worm.MoveToRight();
            }
            for (int i = 0; i < 10; i++)
            {
                worm.MoveToDown();
            }
            for (int i = 0; i < 10; i++)
            {
                worm.MoveToLeft();
            }
            for (int i = 0; i < 10; i++)
            {
                worm.MoveToUp();
            }
            for (int i = 0; i < 5; i++)
            {
                worm.MoveToRight();
            }
            worm.CloseFile();
        }
    }
}