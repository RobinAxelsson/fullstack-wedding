using System.Text.Json;
public record Song
(
    string? Artist,
    string? Title,
    string? Wisherer
)
{
    public override string? ToString() => JsonSerializer.Serialize(this);
}

public record Memory(string Name, string Text)
{
    public override string? ToString() => JsonSerializer.Serialize(this);
}