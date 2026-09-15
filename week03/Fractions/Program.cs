using System;


class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirement: Library of scriptures
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Nephi", 3, 7),
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
            ),
            new Scripture(
                new Reference("Doctrine and Covenants", 6, 36),
                "Look unto me in every thought; doubt not, fear not."
            )
        };

        // Pick a scripture at random
        Random random = new Random();
        Scripture selectedScripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            // Hide 3 random words per step
            selectedScripture.HideRandomWords(3);
        }

        // Show the final state with all words hidden before exiting
        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("All words are hidden. Program ended.");
    }
}