namespace Exercise4;

public readonly struct Song
{
    private readonly string _artistName = default!;
    public readonly string ArtistName
    {
        get => _artistName;
        init
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();
            _artistName = value;
        }
    }

    private readonly string _songName = default!;
    public readonly string SongName
    {
        get => _songName;
        init
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidSongNameException();
            _songName = value;
        }
    }

    private readonly int _songMinutes;
    public readonly int SongMinutes
    {
        get => _songMinutes;
        init
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            _songMinutes = value;
        }
    }

    private readonly int _songSeconds;
    public readonly int SongSeconds
    {
        get => _songSeconds;
        init
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            _songSeconds = value;
        }
    }
    
    public Song(string artistName, string songName, int songMinutes, int songSeconds)
    {
        ArtistName = artistName;
        SongName = songName;
        SongMinutes = songMinutes;
        SongSeconds = songSeconds;
    }

    public Song(string songData)
    {
        string[] data = songData.Split(';');
        if (data.Length != 3)
            throw new ArgumentException(
                message: "Must provide 3 pieces of data separated by ';'");
        string[] subdata = data[2].Split(':');
        if (subdata.Length != 2)
            throw new ArgumentException(
                message: "Must provide the song length in '<m>:<s>' format");
        if (!int.TryParse(subdata[0], out int songMinutes))
            throw new ArgumentException(
                message: $"Could not parse '{subdata[0]}' as an integer");
        if (!int.TryParse(subdata[1], out int songSeconds))
            throw new ArgumentException(
                message: $"Could not parse '{subdata[1]}' as an integer");
        ArtistName = data[0];
        SongName = data[1];
        SongMinutes = songMinutes;
        SongSeconds = songSeconds;
    }

    public readonly string SongLength => $"{SongMinutes}:{SongSeconds}";

    public override string ToString()
        => $"{ArtistName};{SongName};{SongLength}";
    
    public int TotalSeconds => SongMinutes*60 + SongSeconds;
    
}

public class Playlist
{
    private readonly List<Song> _songs = [];

    public void Add(Song song) => _songs.Add(song);
    public void Add(string artistName, string songName, int songMinutes, int songSeconds)
        => _songs.Add(new Song(artistName, songName, songMinutes, songSeconds));
    public void Add(string songData)
        => _songs.Add(new Song(songData));
    
    public int Length => _songs.Count;
    
    public string TotalTime
    {
        get
        {
            int seconds = _songs.Select(song => song.TotalSeconds).Sum();
            int hours = seconds / 3600;
            seconds -= 3600 * hours;
            int minutes = seconds / 60;
            seconds -= 60 * minutes;
            return $"{hours}h {minutes}m {seconds}s";
        }
    }
}


public class Program
{
    static void Main()
    {
        Playlist playlist = new();
        int numSongs = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < numSongs; i++)
        {
            try
            {
                string songData = Console.ReadLine()!;
                playlist.Add(songData);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine($"Songs added: {playlist.Length}");
        Console.WriteLine($"Playlist length: {playlist.TotalTime}");
    }
}
