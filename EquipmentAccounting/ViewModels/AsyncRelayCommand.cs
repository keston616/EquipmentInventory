using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EquipmentAccounting.ViewModels
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Action<Exception> _errorHandler;
        private readonly Func<bool> _canExecute;

        public AsyncRelayCommand(Func<Task> execute,
                               Action<Exception> errorHandler = null,
                               Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _errorHandler = errorHandler;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public async void Execute(object parameter)
        {
            try
            {
                await _execute();
            }
            catch (Exception ex)
            {
                _errorHandler?.Invoke(ex);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
