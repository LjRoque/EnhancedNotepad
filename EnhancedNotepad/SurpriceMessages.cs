using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancedNotepad
{
    public static class SurpriseMessages
    {
        private static readonly List<string> Messages = new List<string>
    {
        "Did you know? Honey never spoils.",
        "Fun Fact: Octopuses have three hearts.",
        "Quote: 'The only limit to our realization of tomorrow is our doubts of today.' - Franklin D. Roosevelt",
        "Joke: Why don't scientists trust atoms? Because they make up everything!",
        "Surprise! You just unlocked a hidden message. Keep writing!"
    };

        public static string GetRandomMessage()
        {
            var random = new Random();
            int index = random.Next(Messages.Count);
            return Messages[index];
        }
    }

}
