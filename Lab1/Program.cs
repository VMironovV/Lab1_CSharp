using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Worm worm1 = new Worm();
            int[] position = new int[2] {1, 2};
            worm1.Position = position;
            int[] end = worm1.Position;
            Console.WriteLine(end[0]);
            Console.WriteLine(end[1]);
        }
    }
}