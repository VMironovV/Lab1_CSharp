using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace Lab1
{
    public class Earth : IHostedService
    {
        private FileWriter _fileWriter;
        private FoodGenerator _foodGenerator;
        private WormLogic _wormLogic;
        private NameGenerator _nameGenerator;
        private Food _food;

        public Earth(FileWriter fileWriter, FoodGenerator foodGenerator, WormLogic wormLogic, NameGenerator nameGenerator, Food food)
        {
            _fileWriter = fileWriter;
            _foodGenerator = foodGenerator;
            _wormLogic = wormLogic;
            _nameGenerator = nameGenerator;
            _food = food;

        }
        public void Life()
        {
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(_fileWriter, _nameGenerator);
            worms.Add(worm);
            _fileWriter.OpenFile();
            for (int i = 0; i < 100; i++)
            {
                _foodGenerator.GenerateFood(_food);
                for (int a = 0; a < worms.Count; a++)
                {
                    _wormLogic.WormAction(worms, worms[a], _nameGenerator, _food);
                }

                for (int a = 0; a < worms.Count; a++)
                {
                    if (worms[a].Vitality < 1)
                    {
                        worms.RemoveAt(a);
                    }
                }
            }

            _fileWriter.CloseFile();
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