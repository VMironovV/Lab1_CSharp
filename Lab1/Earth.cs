using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Earth
    {
        public void Life()
        {
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm();
            worms.Add(worm);
            FileWriter.OpenFile();
            for (int i = 0; i < 100; i++)
            {
                FoodGenerator.GenerateFood(worms);
                for (int a = 0; a < worms.Count; a++)
                {
                    WormLogic.WormAction(worms, worms[a]);
                }

                for (int a = 0; a < worms.Count; a++)
                {
                    if (worms[a].Vitality < 1)
                    {
                        worms.RemoveAt(a);
                    }
                }
            }

            FileWriter.CloseFile();
        }
    }
}