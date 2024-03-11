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
        if (data.Length != 4)
            throw new ArgumentException(
                message: "Must provide 4 pieces of data separated by ';'");
        if (!int.TryParse(data[2], out int songMinutes))
            throw new ArgumentException(
                message: $"Could not parse '{data[2]}' as an integer");
        if (!int.TryParse(data[3], out int songSeconds))
            throw new ArgumentException(
                message: $"Could not parse '{data[3]}' as an integer");
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
    
    public string TotalLength()
    {
        int seconds = _songs.Select(song => song.TotalSeconds).Sum();
        int hours = seconds / 3600;
        seconds -= 3600 * hours;
        int minutes = seconds / 60;
        seconds -= 60 * minutes;
        return $"{hours}h{minutes,2}m{seconds,2}s";
    }
}
