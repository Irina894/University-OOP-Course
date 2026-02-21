using System;


public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.") : base(message) { }
}

public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException()
        : base("Artist name should be between 3 and 20 symbols.") { }
}

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException()
        : base("Song name should be between 3 and 30 symbols.") { }
}

public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException()
        : base("Invalid song length.") { }
    public InvalidSongLengthException(string message)
       : base(message) { }
}

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException()
        : base("Song minutes should be between 0 and 14.") { }
}

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException()
        : base("Song seconds should be between 0 and 59.") { }
}

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, string length)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.ParseLength(length);
    }

    public string ArtistName
    {
        get => this.artistName;
        private set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();
            this.artistName = value;
        }
    }

    public string SongName
    {
        get => this.songName;
        private set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException();
            this.songName = value;
        }
    }

    public int Minutes
    {
        get => this.minutes;
        private set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get => this.seconds;
        private set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            this.seconds = value;
        }
    }

    private void ParseLength(string length)
    {
        string[] parts = length.Split(':');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int min) || !int.TryParse(parts[1], out int sec))
            throw new InvalidSongLengthException();

        this.Minutes = min;
        this.Seconds = sec;
    }

    public int TotalSeconds => this.Minutes * 60 + this.Seconds;
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Song> playlist = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                string[] input = Console.ReadLine().Split(';');
                if (input.Length != 3)
                    throw new InvalidSongException();

                string artist = input[0];
                string name = input[1];
                string length = input[2];

                Song song = new Song(artist, name, length);
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        int totalSeconds = 0;
        foreach (var song in playlist)
            totalSeconds += song.TotalSeconds;

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        Console.WriteLine("Songs added:"+playlist.Count);
        Console.WriteLine("Playlist length:"+ hours+"h" +minutes+"m"+seconds+"s");
    }
}
