using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Evernote_Clone.Model;
using Evernote_Clone.ViewModel.Commands;
using Evernote_Clone.ViewModel.Helpers;

namespace Evernote_Clone.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NotesVM()
        {
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNotebooks();
        }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return _selectedNotebook; }
            set
            {
                _selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
            }
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note
            {
                NotebookId = notebookId,
                Title = $"New Note {DateTime.Now.ToString()}",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            DatabaseHelper.Insert(newNote);
            GetNotes();
        }

        public void CreateNoteBook()
        {
            Notebook newNotebook = new Notebook
            {
                Name = "New Notebook",
                // UserId = "1";
            };

            DatabaseHelper.Insert(newNotebook);
            GetNotebooks();
        }

        private void GetNotebooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();
            Notebooks.Clear();
            foreach (var notebook in notebooks)
            {
                Notebooks.Add(notebook);
                //Observable collection a ekleniyor
            }
        }

        private void GetNotes()
        {

            if (SelectedNotebook != null)
            {
                var notes = DatabaseHelper.Read<Note>().Where(x=>x.NotebookId == SelectedNotebook.Id).ToList(); //mevcut notlar burda alınıyor
                Notes.Clear(); //observable collection temizlenecek üzerine eklememesi için  Kendime not : yukarıda olsuturdugun listi temizleme !!!! bi saat debug yaparsın sonra niye gelmiyor diye
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
