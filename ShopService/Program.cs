using BusinessLogicLayer;
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
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddBusinessLogicLayer();
            serviceProvider.AddDataAccessLayer(configuration);
            //serviceProvider.BuildServiceProvider();

            try
            {
                // Получение экземпляра ApplicationDbContext из сервис-провайдера
                var dbContext = serviceProvider.BuildServiceProvider().GetRequiredService<ApplicationDbContext>();
                DataAccessLayer.Seed.DatabaseInitializer.SeedAsync(dbContext).Wait();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}