namespace WiredCoffee.Commands;

using System;
using System.Windows.Input;

public class DelegateCommand : ICommand
{
   public Action<object?> Run { get; }
   public Func<object?, bool>? CanRun { get; }

   public event EventHandler? CanExecuteChanged;

   public DelegateCommand(Action<object?> run, Func<object?, bool>? canRun = null)
   {
      ArgumentNullException.ThrowIfNull(run, nameof(run));
      Run = run;

      CanRun = canRun;
   }

   public bool CanExecute(object? parameter) => CanRun is null || CanRun(parameter);
   public void Execute(object? parameter) => Run(parameter);
   public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
