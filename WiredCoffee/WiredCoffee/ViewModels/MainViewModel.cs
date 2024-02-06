namespace WiredCoffee.ViewModels;

using System.Threading.Tasks;
using WiredCoffee.Commands;

public class MainViewModel : ViewModelBase
{
   private ViewModelBase? selectedViewModel;
   public ViewModelBase? SelectedViewModel { get => selectedViewModel; set { selectedViewModel = value; RaisePropertyChanged(); } }
   public CustomersViewModel CustomersViewModel { get; }
   public ProductsViewModel ProductsViewModel { get; }

   public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
   {
      CustomersViewModel = customersViewModel;
      ProductsViewModel = productsViewModel;
      SelectedViewModel = customersViewModel;

      SelectViewModelCommand = new DelegateCommand(SelectViewModel);
   }

   public DelegateCommand SelectViewModelCommand { get; }

   public override async Task LoadAsync()
   {
      if (SelectedViewModel is not null)
      {
         await SelectedViewModel.LoadAsync();
      }
   }
   private async void SelectViewModel(object? parameter)
   {
      SelectedViewModel = parameter as ViewModelBase;
      await LoadAsync();
   }
}
