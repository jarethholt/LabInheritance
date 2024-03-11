namespace Exercise4;

public class InvalidSongException : ArgumentException
{
    private static string _message = "Invalid song.";

    public InvalidSongException()
        : base(message: _message) {}

    public InvalidSongException(string? paramName)
        : base(message: _message, paramName: paramName) {}
}
