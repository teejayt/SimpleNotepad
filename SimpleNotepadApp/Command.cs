using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotepadApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    namespace Databinding
    {
        public class Command : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;
            public event EventHandler CanExecuteChanged;

            public Command(Action execute, Func<bool> canExecute = null)
            {
                if (execute == null)
                {
                    throw new ArgumentNullException("execute");
                }

                _execute = execute;
                _canExecute = canExecute ?? (() => true);
            }

            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                try
                {
                    return _canExecute();
                }
                catch
                {
                    return false;
                }
            }

            public void Execute(object parameter)
            {
                if (!CanExecute(parameter))
                {
                    return;
                }

                try
                {
                    _execute();
                }
                catch
                {
                    Debugger.Break();
                }
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
