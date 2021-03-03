using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote_Clone.ViewModel.Commands
{
    //This will work on user click on LOGIN button
    public class LoginCommand : ICommand
    {
        public LoginVM Vm { get; set; }
        public LoginCommand(LoginVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
