using SQLite;
using EnhancedNotepad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnhancedNotepad.Data
{
    // Make the class public
    public class NotesDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public NotesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        // Add the DeleteNoteAsync method
        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
