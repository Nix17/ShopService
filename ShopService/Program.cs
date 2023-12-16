using BusinessLogicLayer;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Logging;

namespace ShopService
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Создание и настройка сервисов
            var serviceCollection = new ServiceCollection();

            // Добавление сервисов для бизнес-логики
            serviceCollection.AddBusinessLogicLayer(configuration);

            // Добавление сервисов для доступа к данным
            serviceCollection.AddDataAccessLayer(configuration);

            try
            {
                // Получение экземпляра ApplicationDbContext из сервис-провайдера
                var serviceProvider = serviceCollection.BuildServiceProvider();

                var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                DataAccessLayer.Seed.DatabaseInitializer.SeedAsync(dbContext).Wait();

                var shopCommands = serviceProvider.GetRequiredService<IShopCommands>();

                ApplicationConfiguration.Initialize();
                Application.Run(new Form1(shopCommands));
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}