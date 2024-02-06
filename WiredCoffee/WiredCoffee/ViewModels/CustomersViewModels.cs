namespace WiredCoffee.ViewModels;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredCoffee.Commands;
using WiredCoffee.Data;
using WiredCoffee.Models;
public class CustomersViewModel : ViewModelBase
{
   public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
   public ICustomerDataProvider CustomerDataProvider { get; }
   public DelegateCommand AddCommand { get; }
   public DelegateCommand MoveNavigationCommand { get; }
   public DelegateCommand DeleteCommand { get; }

   private NavigationSide navigationSide;
   public NavigationSide NavigationSide { get => navigationSide; private set { navigationSide = value; RaisePropertyChanged(); } }
   private CustomerItemViewModel? selectedCustomer;
   public CustomerItemViewModel? SelectedCustomer
   {
      get => selectedCustomer;
      set
      {
         selectedCustomer = value;
         RaisePropertyChanged();
         RaisePropertyChanged(nameof(IsCustomerSelected));
         DeleteCommand.RaiseCanExecuteChanged();
      }
   }

   public bool IsCustomerSelected => SelectedCustomer is not null;
   public CustomersViewModel(ICustomerDataProvider customerDataProvider)
   {
      CustomerDataProvider = customerDataProvider;
      AddCommand = new DelegateCommand(Add);
      MoveNavigationCommand = new DelegateCommand(MoveNavigation);
      DeleteCommand = new DelegateCommand(Delete, CanDelete);
   }

   public override async Task LoadAsync()
   {
      if (Customers.Any())
      {
         return;
      }

      var customers = await CustomerDataProvider.GetAllAsync();
      if (customers is null)
      {
         return;
      }

      foreach (var customer in customers)
      {
         Customers.Add(new CustomerItemViewModel(customer));
      }
   }

   private void Add(object? parameter)
   {
      var customer = new Customer { FirstName = "New" };
      var customerItem = new CustomerItemViewModel(customer);
      Customers.Add(customerItem);
      SelectedCustomer = customerItem;
   }
   private void MoveNavigation(object? parameter) => NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;

   private void Delete(object? parameter)
   {
      if (SelectedCustomer is not null)
      {
         Customers.Remove(SelectedCustomer);
      }

      SelectedCustomer = null;
   }

   private bool CanDelete(object? parameter) => SelectedCustomer is not null;
}

public enum NavigationSide
{
   Left,
   Right
}
