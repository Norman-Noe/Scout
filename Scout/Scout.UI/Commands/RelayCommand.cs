using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Scout.UI
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;

        /// <summary>
        /// The event fired when <see cref="CanExecute(object)"/> value is changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            // A relay command can always execute
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// The action to run
        /// </summary>
        private Action<T> mAction;

        /// <summary>
        /// The event fired when <see cref="CanExecute(object)"/> value is changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action<T> action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            // A relay command can always execute
            return true;
        }

        public void Execute(object parameter)
        {
            if (typeof(T).IsEnum)
            {
                mAction((T)(Enum.Parse(typeof(T), parameter.ToString(), true)));
            }
            else
            {
                mAction((T)parameter);
            }
        }
    }
}
