using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote_Clone.ViewModel.Commands
{
    //This will work on user click on REGISTER button
    public class RegisterCommand : ICommand
    {
        public LoginVM Vm { get; set; }

        public RegisterCommand(LoginVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO:Create a new User
        }

        public event EventHandler CanExecuteChanged;
    }
}
