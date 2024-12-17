using Microsoft.Maui.Controls;
using EnhancedNotepad.Models;
using EnhancedNotepad.Data;
using System;
using System.Collections.Generic;
using System.Linq; // Add this directive for LINQ
using System.Threading.Tasks;

namespace EnhancedNotepad
{
    public partial class MainPage : ContentPage
    {
        private readonly NotesDatabase _database;

        public MainPage(NotesDatabase database)
        {
            InitializeComponent();
            _database = database;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadNotesAsync();
        }

        private async Task LoadNotesAsync()
        {
            NotesCollectionView.ItemsSource = await _database.GetNotesAsync();
        }

        async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var notes = await _database.GetNotesAsync();
            NotesCollectionView.ItemsSource = string.IsNullOrWhiteSpace(e.NewTextValue)
                ? notes
                : notes.Where(n => n.Title.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase) ||
                                   n.Content.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase));
        }

        async void OnCategoryFilterChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var selectedCategory = picker.SelectedItem.ToString();
            var notes = await _database.GetNotesAsync();

            NotesCollectionView.ItemsSource = selectedCategory == "All"
                ? notes
                : notes.Where(n => n.Category == selectedCategory);
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.CommandParameter as Note;
            if (note != null)
            {
                await Navigation.PushAsync(new NoteEntryPage(note, _database));
            }
        }

        async void OnAddNoteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage(new Note(), _database));
        }
    }
}
