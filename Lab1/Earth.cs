using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace Lab1
{
    public class Earth : IHostedService
    {
        public void Life()
        {
            FileWriter fileWriter = new FileWriter();
            FoodGenerator foodGenerator = new FoodGenerator();
            WormLogic wormLogic = new WormLogic();
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(fileWriter);
            worms.Add(worm);
            fileWriter.OpenFile();
            for (int i = 0; i < 100; i++)
            {
                foodGenerator.GenerateFood(worms);
                for (int a = 0; a < worms.Count; a++)
                {
                    wormLogic.WormAction(worms, worms[a]);
                }

                for (int a = 0; a < worms.Count; a++)
                {
                    if (worms[a].Vitality < 1)
                    {
                        worms.RemoveAt(a);
                    }
                }
            }

            fileWriter.CloseFile();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(Life);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask; // _running = false    
        
    }
}