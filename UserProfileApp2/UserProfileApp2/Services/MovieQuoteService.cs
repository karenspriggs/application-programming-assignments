using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserProfileApp2.Services
{
    public class MovieQuoteService
    {
        // Referenced from https://www.imdb.com/list/ls054689899/
        public static string[] MovieQuotes = new string[]
        {
            "Here's looking at you, kid. - Casablanca",
            "I'm going to make him an offer he can't refuse. - The Godfather",
            "You're gonna need a bigger boat. - JAWS",
            "I love the smell of napalm in the morning. - Apocalypse Now",
            "Here's Johnny! - The Shining",
            "Mama always said life was like a box of chocolates. You never know what you're gonna get. - Forrest Gump",
            "A census taker once tried to test me. I ate his liver with some fava beans and a nice Chianti. - The Silence of the Lambs",
            "I'll be back. - The Terminator",
            "Love means never having to say you're sorry. - Love Story",
            "I'll get you, my pretty, and your little dog too! - The Wizard of Oz",
            "Get your stinking paws off me, you damned dirty ape. - Planet of the Apes"
        };

        // Return the quote stored at the randomly generated index
        public static string GetRandomQuote()
        {
            var random = new Random();
            return MovieQuotes[random.Next(MovieQuotes.Length)];
        }
    }
}