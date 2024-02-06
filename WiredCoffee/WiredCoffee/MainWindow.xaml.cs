namespace WiredCoffee;

using System.Windows;
using WiredCoffee.ViewModels;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
   internal MainViewModel ViewModel { get; }

   public MainWindow(MainViewModel viewModel)
   {
      InitializeComponent();
      ViewModel = viewModel;
      DataContext = ViewModel;
      Loaded += OnMainWindowLoaded;
   }

   private async void OnMainWindowLoaded(object sender, RoutedEventArgs e) => await ViewModel.LoadAsync();
}
