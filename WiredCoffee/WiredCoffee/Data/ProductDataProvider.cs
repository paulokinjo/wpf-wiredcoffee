namespace WiredCoffee.Data;

using System.Collections.Generic;
using System.Threading.Tasks;
using WiredCoffee.Models;

public interface IProductDataProvider
{
   Task<IEnumerable<Product>> GetAllAsync();
}
public class ProductDataProvider : IProductDataProvider
{
   public async Task<IEnumerable<Product>> GetAllAsync()
   {
      await Task.Delay(1000);
      return new List<Product>
      {
         new() {Name = "Product1", Description="Description1"},
         new() {Name = "Product2", Description="Description2"},
         new() {Name = "Product3", Description="Description3"},
      };
   }
}
