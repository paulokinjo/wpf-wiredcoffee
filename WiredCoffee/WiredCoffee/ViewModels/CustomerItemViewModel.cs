namespace WiredCoffee.ViewModels;
using WiredCoffee.Models;

public class CustomerItemViewModel : ValidationViewModelBase
{
   public string FirstName
   {
      get => Model.FirstName;
      set
      {
         Model.FirstName = value;
         RaisePropertyChanged();
         if (string.IsNullOrEmpty(Model.FirstName))
         {
            AddError("Firstname is required");
         }
         else
         {
            ClearErrors();
         }
      }
   }
   public string LastName
   {
      get => Model.LastName;
      set
      {
         Model.LastName = value;
         RaisePropertyChanged();
         if (string.IsNullOrEmpty(Model.LastName))
         {
            AddError("Lastname is required");
         }
         else
         {
            ClearErrors();
         }
      }
   }
   public bool IsDeveloper { get => Model.IsDeveloper; set { Model.IsDeveloper = value; RaisePropertyChanged(); } }

   public Customer Model { get; }
   public int Id => Model.Id;
   public CustomerItemViewModel(Customer customer) => Model = customer;
}
