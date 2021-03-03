using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote_Clone.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesVM Vm;

        public NewNotebookCommand(NotesVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: Create new Notebook
        }

        public event EventHandler CanExecuteChanged;
    }
}
