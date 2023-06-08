// prompt user for adding songs to playlist

bool runApp = true;
int nowPlayingIndex = -1;
int nextSongIndex = 0;
Queue<string> songQueue = new Queue<string>();

while (runApp)
{
    // song1 0 
    // song2 1
    // count = 2
    // nowPlaying = 0
    // next = 1
    
    if(nowPlayingIndex < songQueue.Count && nowPlayingIndex >= 0)
    {
        Console.WriteLine($"Now Playing '{songQueue.ElementAtOrDefault(nowPlayingIndex)}");
    }

    if (nextSongIndex < songQueue.Count)
    {
        Console.WriteLine($"Next Song: {songQueue.ElementAtOrDefault(nextSongIndex)}");
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
                // add new song
                string newTitle = "";

                while (String.IsNullOrEmpty(newTitle))
                {
                    Console.WriteLine("\nPlease enter a song title.");
                    newTitle = Console.ReadLine();
                }

                songQueue = AddSongToQueue(newTitle, songQueue);

                break;
            case 2: 
                // play next song in playlist
                if (songQueue.Count > 0)
                {
                    nowPlayingIndex++;
                    nextSongIndex++;
                    string songTitle = songQueue.ElementAt(nowPlayingIndex);
                    Console.WriteLine($"Now playing {songTitle}.");
                } else if (nowPlayingIndex >= songQueue.Count)
                {
                    Console.WriteLine("No more songs to play in playlist.");
                }
                else
                {
                    Console.WriteLine("No songs in the current playlist.");
                }
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