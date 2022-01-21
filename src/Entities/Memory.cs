using System.Text.Json;

public record Memory(string Name, string Text)
{
    public override string? ToString() => JsonSerializer.Serialize(this);
}