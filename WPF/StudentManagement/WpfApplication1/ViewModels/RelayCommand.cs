using System;
using System.Windows.Input;

namespace WpfApplication1.ViewModels
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Predicate<object> canexecute;

        public RelayCommand(Action<object> execute, Predicate<object> canexecute)
        {
            if (execute == null)
            {
                throw new NullReferenceException("execute");
            }
            canexecute = this.canexecute;
            execute = this.execute;
        }

        //public RelayCommand(Action<object> execute : this(execute, null))
        //{

        //}

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canexecute == null ? true : canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute.Invoke(parameter);
        }
    }
}
