using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote_Clone.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesVM Vm;

        public NewNoteCommand(NotesVM vm)
        {
            Vm = vm;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: Create new Note
        }

        public event EventHandler CanExecuteChanged;
    }
}
