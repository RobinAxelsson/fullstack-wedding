using System.Text.Json;
using Microsoft.Azure.Cosmos.Table;

public record GuestDto(string Name, int Age, string MyPreferedLanguage, string ClosestTo, string[] Hobbies, string Relation);
public class Guest : TableEntity
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? MyPreferedLanguage { get; set; }
    public string? ClosestTo { get; set; }
    public string? Relation { get; set; }
    public string[] Hobbies { get; set; }
    public Guest(GuestDto guestDto)
    {
        RowKey = Guid.NewGuid().ToString("d");
        PartitionKey = guestDto.MyPreferedLanguage ?? "english";
        Name = guestDto.Name;
        Age = guestDto.Age;
        MyPreferedLanguage = guestDto.MyPreferedLanguage;
        ClosestTo = guestDto.ClosestTo;
        Hobbies = guestDto.Hobbies;
        Relation = guestDto.Relation;
    }

    public override string? ToString() => JsonSerializer.Serialize(this);
}
