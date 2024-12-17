using SQLite;
using System;

namespace EnhancedNotepad.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? ReminderDate { get; set; }
        public TimeSpan? ReminderTime { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
