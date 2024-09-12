using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using Kai.UI;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System;

namespace Kai
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ServiceCollection services = ConfigureServices();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            //var startForm = serviceProvider.GetRequiredService<IngredientsForm>();
            //var startForm = serviceProvider.GetRequiredService<RecipesForm>();
            var startForm = serviceProvider.GetRequiredService<FrozenMealsForm>();
            Application.Run(startForm);
        }

        static ServiceCollection ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<IIngredientsRepository>(_ => new IngredientsRepository());
            services.AddTransient<IIngredientTypesRepository>(_ => new IngredientTypesRepository());
            services.AddTransient<IRecipesRepository>(_ => new RecipesRepository());
            services.AddTransient<IRecipeTypesRepository>(_ => new RecipeTypesRepository());
            services.AddTransient<IFrozenMealsRepository>(_ => new FrozenMealsRepository());
            services.AddTransient<IFrozenMealTypesRepository>(_ => new FrozenMealTypesRepository());

            services.AddTransient<IngredientsForm>();
            services.AddTransient<IngredientTypesForm>();
            services.AddTransient<RecipesForm>();
            services.AddTransient<RecipeTypesForm>();
            services.AddTransient<FrozenMealsForm>();
            services.AddTransient<FrozenMealTypesForm>();

            return services;
        }
    }
}