namespace Exercise4;

public class InvalidSongException : ArgumentException
{
    private static readonly string _message = "Invalid song.";

    public InvalidSongException()
        : base(message: _message) {}
    
    public InvalidSongException(string? message)
        : base(message: message) {}
}

public class InvalidArtistNameException: InvalidSongException
{
    private static readonly string _message = "Artist name should be between 3 and 20 symbols";
    
    public InvalidArtistNameException() : base(message: _message) {}
}

public class InvalidSongNameException: InvalidSongException
{
    private static readonly string _message = "Song name should be between 3 and 20 symbols";
    
    public InvalidSongNameException() : base(message: _message) {}
}
