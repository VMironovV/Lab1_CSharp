using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Lab1
{
    class Program
    {
        /*static void Main(string[] args)
        {
            Earth earth = new Earth();
            earth.Life();
        }*/
        public static void Main(string[] args)

        {

            CreateHostBuilder(args).Build().Run();

        }

 

        public static IHostBuilder CreateHostBuilder(string[] args)

        {

        	

            return Host.CreateDefaultBuilder(args)

                .ConfigureServices((hostContext, services) =>

                {

                    services.AddHostedService<Earth>();
                    

                    services.AddScoped<FileWriter>(); 
                    services.AddScoped<NameGenerator>();
                    services.AddScoped<FoodGenerator>();
                    services.AddScoped<WormLogic>();
                    
                });

        }
    }
}