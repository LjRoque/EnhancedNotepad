using Microsoft.Maui.Controls;
using EnhancedNotepad.Models;
using EnhancedNotepad.Data;
using System;

namespace EnhancedNotepad
{
    public partial class NoteEntryPage : ContentPage
    {
        private readonly NotesDatabase _database;

        public NoteEntryPage(Note note, NotesDatabase database)
        {
            InitializeComponent();
            BindingContext = note;
            _database = database;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.DateCreated = DateTime.Now;

            if (note.ReminderDate.HasValue && note.ReminderTime.HasValue)
            {
                var reminderDateTime = note.ReminderDate.Value.Date + note.ReminderTime.Value;
                if (reminderDateTime > DateTime.Now)
                {
                    await DisplayAlert("Reminder Set", $"Reminder set for {reminderDateTime}", "OK");
                }
            }

            await _database.SaveNoteAsync(note);

          

            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await _database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}
