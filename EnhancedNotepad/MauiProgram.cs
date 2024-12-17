using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using EnhancedNotepad.Data; // Add this directive to include NotesDatabase
using System.IO;

namespace EnhancedNotepad
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
            builder.Services.AddSingleton<NotesDatabase>(s => ActivatorUtilities.CreateInstance<NotesDatabase>(s, dbPath));

            return builder.Build();
        }
    }
}
