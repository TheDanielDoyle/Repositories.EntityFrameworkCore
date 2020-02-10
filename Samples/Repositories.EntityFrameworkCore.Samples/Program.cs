using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.EntityFrameworkCore.Samples.Data;
using Repositories.EntityFrameworkCore.Samples.Data.Queries;
using Repositories.EntityFrameworkCore.Samples.Models;

namespace Repositories.EntityFrameworkCore.Samples
{
    internal class Program
    {
        private static readonly Guid _pyrastaPearId = Guid.NewGuid();

        private static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            await RunAsync(host);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices);
        }

        private static async Task RunAsync(IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IUnitOfWork context = scope.ServiceProvider.GetService<IUnitOfWork>();
                await AddFruitsAsync(context);
                await context.SaveChangesAsync();
                await WriteFruitCountsAsync(context);
                await WriteFruitsAsync(context);

                Console.ReadKey();
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<IUnitOfWork, UnitOfWork>((provider, options) =>
            {
                options.UseInMemoryDatabase("Sample");
                options.UseInternalServiceProvider(provider);
            });
        }

        private static async Task AddFruitsAsync(IUnitOfWork context)
        {
            await context.Apples.AddAsync(new Apple("Cortland"));
            await context.Apples.AddAsync(new Apple("Opal"));
            await context.Apples.AddAsync(new Apple("Winesnap"));

            await context.Bananas.AddRangeAsync(new[]
            {
                new Banana("Burro"),
                new Banana("Cavendish"),
                new Banana("Lady Finger")
            });

            await context.Oranges.AddRangeAsync(new[]
            {
                new Orange("Blood"),
                new Orange("Jaffa"),
                new Orange("Valencia"),
                new Orange("Blood")
            });

            await context.Pears.AddRangeAsync(new[]
            {
                new Pear(Guid.NewGuid(), "Callery"),
                new Pear(_pyrastaPearId, "Pyrasta"),
                new Pear(Guid.NewGuid(), "Seckel")
            });
        }

        private static async Task WriteFruitsAsync(IUnitOfWork context)
        {
            Console.WriteLine("Retrieving Pyrasta Pear");
            Pear pyrastaPear = await context.Pears.FindByIdAsync(_pyrastaPearId.ToString());
            Console.WriteLine($"\tType: {pyrastaPear.Type} Id {pyrastaPear.Id}");

            Console.WriteLine("Retrieving Blood Oranges.");
            IEnumerable<Orange> bloodOranges = await context.Oranges.QueryAsync(o => o.Type == "Blood");
            foreach (Orange orange in bloodOranges.ToList())
            {
                Console.WriteLine($"\tType: {orange.Type} Id: {orange.Id}");
            }

            Console.WriteLine("Retrieving Cortland Apples.");
            IEnumerable<Apple> cortlandApples = await context.Apples.QueryAsync(new CortlandApplesQuery());
            foreach (Apple apple in cortlandApples.ToList())
            {
                Console.WriteLine($"\tType: {apple.Type} Id: {apple.Id}");
            }

            Console.WriteLine("Retrieving Favourite Bananas.");
            FavouriteBananaTypes favouriteBananaTypes = new FavouriteBananaTypes("Burro", "Lady Finger");
            IEnumerable<Banana> favouriteBananas = await context.Bananas.QueryAsync(new LadyFingerBananasQuery(favouriteBananaTypes));
            foreach (Banana banana in favouriteBananas.ToList())
            {
                Console.WriteLine($"\tType: {banana.Type} Id: {banana.Id}");
            }
        }

        private static async Task WriteFruitCountsAsync(IUnitOfWork context)
        {
            Console.WriteLine("Counting Blood Oranges.");
            long bloodOrangeCount = await context.Oranges.CountQueryAsync(o => o.Type == "Blood");
            Console.WriteLine($"No. Blood Oranges: {bloodOrangeCount}");

            Console.WriteLine("Counting Cortland Apples.");
            long cortlandApples = await context.Apples.CountQueryAsync(new CortlandApplesQuery());
            Console.WriteLine($"No. Cortland Apples: {cortlandApples}");

            Console.WriteLine("Retrieving Favourite Bananas.");
            FavouriteBananaTypes favouriteBananaTypes = new FavouriteBananaTypes("Burro", "Lady Finger");
            IEnumerable<Banana> favouriteBananas = await context.Bananas.QueryAsync(new LadyFingerBananasQuery(favouriteBananaTypes));
            foreach (Banana banana in favouriteBananas.ToList())
            {
                Console.WriteLine($"\tType: {banana.Type} Id: {banana.Id}");
            }
        }
    }
}
