using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Evernote_Clone.Model;

namespace Evernote_Clone.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesVM Vm { get; set; }

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
            Vm.CreateNoteBook();
        }

        public event EventHandler CanExecuteChanged;
    }
}
