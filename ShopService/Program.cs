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

            // �������� � ��������� ��������
            var serviceCollection = new ServiceCollection();

            // ���������� �������� ��� ������-������
            serviceCollection.AddBusinessLogicLayer(configuration);

            // ���������� �������� ��� ������� � ������
            serviceCollection.AddDataAccessLayer(configuration);

            try
            {
                // ��������� ���������� ApplicationDbContext �� ������-����������
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