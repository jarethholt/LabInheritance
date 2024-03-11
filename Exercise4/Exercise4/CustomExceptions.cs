namespace Exercise4;

public class InvalidSongException(string? message = null, string? paramName = null)
    : ArgumentException(
        message: message ?? "Invalid song.",
        paramName: paramName) {}

public class InvalidArtistNameException()
    : InvalidSongException(
        message: "Artist name should be between 3 and 20 symbols.",
        paramName: "ArtistName") {}

public class InvalidSongNameException()
    : InvalidSongException(
        message: "Song name should be between 3 and 20 symbols.",
        paramName: "SongName") {}

public class InvalidSongLengthException(string? paramName = null)
    : InvalidSongException(
        message: "Invalid song length.",
        paramName: paramName ?? "SongLength") {}
