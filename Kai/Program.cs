using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using Kai.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace Kai
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ServiceCollection services = ConfigureServices();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var startForm = serviceProvider.GetRequiredService<IngredientsForm>();
            Application.Run(startForm);
        }

        static ServiceCollection ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<IIngredientsRepository>(_ => new IngredientsRepository()); // TODO: REMOVE THIS LINE AFTER RE-ENABLING THE TXT REPOSITORY

            //if (ConfigurationManager.AppSettings["repositoryType"] == "txt")
            //    services.AddTransient<IIngredientsRepository>(_ => new IngredientsTxtRepository());
            //else
            //    services.AddTransient<IIngredientsRepository>(_ => new IngredientsRepository());

            services.AddTransient<IngredientsForm>();

            return services;
        }
    }
}