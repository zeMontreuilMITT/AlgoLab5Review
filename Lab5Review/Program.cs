// prompt user for adding songs to playlist

bool runApp = true;
int nextSongIndex = 0;
int nowPlayingIndex = 0;
Queue<string> songQueue = new Queue<string>();

while (runApp)
{
    if(songQueue.Count > 0)
    {
        Console.WriteLine($"Next song '{songQueue.ElementAtOrDefault(nextSongIndex)}");
    }

    // Display Main menu
    Console.Write($"\nChoose an option:\n1. Add a song to your playlist\n2. Play the next song in your playlist\n3. Skip the next song\n4. Rewind one song\n5. Exit\n>");

    char userInput = Console.ReadKey().KeyChar;

    if (Char.IsNumber(userInput))
    {
        int userInputNumber = Int32.Parse(userInput.ToString());

        switch (userInputNumber)
        {
            case 1:
                // add song
                string newTitle = "";

                while (String.IsNullOrEmpty(newTitle))
                {
                    Console.WriteLine("\nPlease enter a song title.");
                    newTitle = Console.ReadLine();
                }

                songQueue = AddSongToQueue(newTitle, songQueue);

                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"\n'{userInputNumber}' is not a valid choice. Please select a choice from the menu.");
                break;
        }

    } else
    {
        Console.WriteLine("\nPlease enter a valid number input.");
    }
}

Queue<string> AddSongToQueue(string songTitle, Queue<string> songQueue)
{
    songQueue.Enqueue(songTitle);
    Console.WriteLine($"{songTitle} added to your playlist.");
    return songQueue;
}