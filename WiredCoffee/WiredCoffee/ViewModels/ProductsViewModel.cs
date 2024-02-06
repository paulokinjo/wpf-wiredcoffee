namespace WiredCoffee.ViewModels;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredCoffee.Data;
using WiredCoffee.Models;

public class ProductsViewModel : ViewModelBase
{
   public IProductDataProvider ProductDataProvider { get; }
   public ObservableCollection<Product> Products { get; } = new();
   public ProductsViewModel(IProductDataProvider productDataProvider) => ProductDataProvider = productDataProvider;

   public override async Task LoadAsync()
   {
      if (Products.Any())
         return;

      var products = await ProductDataProvider.GetAllAsync();

      if (products is null || !products.Any())
         return;

      foreach (var product in products)
      {
         Products.Add(product);
      }
   }
}
