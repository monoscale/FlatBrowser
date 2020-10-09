using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatBrowser.Windows {
    public class RelayCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        private Action targetExecuteMethod;
        private Func<bool> targetCanExecuteMethod;

        public RelayCommand(Action action) : this(action, null) { }
        public RelayCommand(Action action, Func<bool> predicate) {
            targetExecuteMethod = action;
            targetCanExecuteMethod = predicate;
        }

        public bool CanExecute(object parameter) {
            if (targetCanExecuteMethod != null) {
                return targetCanExecuteMethod();
            }
            return true;
        }

        public void Execute(object parameter) {
            targetExecuteMethod();
        }
    }
}
