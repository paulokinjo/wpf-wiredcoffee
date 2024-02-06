namespace WiredCoffee.ViewModels;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
{
   private readonly Dictionary<string, List<string>> errorsByPropertyName = new();
   public bool HasErrors => errorsByPropertyName.Any();

   public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

   protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e) => ErrorsChanged?.Invoke(this, e);

   public IEnumerable GetErrors(string? propertyName) =>
      propertyName is not null && errorsByPropertyName.ContainsKey(propertyName) ?
      errorsByPropertyName[propertyName] :
      Enumerable.Empty<string>();

   protected void AddError(string error, [CallerMemberName] string? propertyName = null)
   {
      if (propertyName is null)
         return;

      if (!errorsByPropertyName.ContainsKey(propertyName))
      {
         errorsByPropertyName[propertyName] = new();
      }

      if (!errorsByPropertyName[propertyName].Contains(error))
      {
         errorsByPropertyName[propertyName].Add(error);
         OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
         RaisePropertyChanged(nameof(HasErrors));
      }
   }

   protected void ClearErrors([CallerMemberName] string? propertyName = null)
   {
      if (propertyName is null)
         return;

      if (errorsByPropertyName.ContainsKey(propertyName))
      {
         errorsByPropertyName.Remove(propertyName);
         OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
         RaisePropertyChanged(nameof(HasErrors));
      }
   }
}
