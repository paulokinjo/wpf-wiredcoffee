namespace WiredCoffee;

using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WiredCoffee.Data;
using WiredCoffee.ViewModels;

public partial class App : Application
{
   public ServiceProvider ServiceProvider { get; }
   public App()
   {
      IServiceCollection services = ConfigureServices(new ServiceCollection());
      ServiceProvider = services.BuildServiceProvider();
   }

   protected override void OnStartup(StartupEventArgs e)
   {
      base.OnStartup(e);
      MainWindow mainWindow = ServiceProvider.GetService<MainWindow>();
      mainWindow?.Show();
   }

   private static IServiceCollection ConfigureServices(ServiceCollection services) =>
      services.AddTransient<MainWindow>()
              .AddTransient<MainViewModel>()
              .AddTransient<CustomersViewModel>()
              .AddTransient<ProductsViewModel>()
              .AddTransient<ICustomerDataProvider, CustomerDataProvider>()
              .AddTransient<IProductDataProvider, ProductDataProvider>();

}
