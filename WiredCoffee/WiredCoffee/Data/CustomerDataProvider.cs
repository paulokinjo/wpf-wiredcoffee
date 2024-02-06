namespace WiredCoffee.Data;

using System.Collections.Generic;
using System.Threading.Tasks;
using WiredCoffee.Models;

public interface ICustomerDataProvider
{
   Task<IEnumerable<Customer>?> GetAllAsync();
}

public class CustomerDataProvider : ICustomerDataProvider
{
   public async Task<IEnumerable<Customer>?> GetAllAsync()
   {
      await Task.Delay(100);
      return new List<Customer>
      {
         new Customer { Id = 1, FirstName = "Paulo", LastName = "Kinjo", IsDeveloper = true },
         new Customer { Id = 2, FirstName = "Aline", LastName = "Ferreira", IsDeveloper = false }
      };
   }
}
