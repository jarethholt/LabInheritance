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

    public readonly string SongLength => $"{SongMinutes}:{SongSeconds}";

    public override string ToString()
        => $"{ArtistName};{SongName};{SongLength}";
    
    public Song(string artistName, string songName, int songMinutes, int songSeconds)
    {
        ArtistName = artistName;
        SongName = songName;
        SongMinutes = songMinutes;
        SongSeconds = songSeconds;
    }

    public Song(string dataLine)
    {
        string[] data = dataLine.Split(';');
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
    
}
