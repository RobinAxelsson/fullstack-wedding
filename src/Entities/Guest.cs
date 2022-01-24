using System.Text.Json;
using Microsoft.Azure.Cosmos.Table;

public record GuestDto(string Name, int Age, string MyPreferedLanguage, string ClosestTo, string Hobbies, string Relation, string SpecialFood);
public class Guest : TableEntity
{
    public Guest(){}
    public string Name { get; set; }
    public int Age { get; set; }
    public string MyPreferedLanguage { get; set; }
    public string ClosestTo { get; set; }
    public string Relation { get; set; }
    public string Hobbies { get; set; }
    public string SpecialFood { get; set; }
    public Guest(GuestDto guestDto)
    {
        RowKey = Guid.NewGuid().ToString("d");
        PartitionKey = guestDto.MyPreferedLanguage ?? "eng";
        Name = guestDto.Name;
        Age = guestDto.Age;
        MyPreferedLanguage = guestDto.MyPreferedLanguage ?? "eng";
        ClosestTo = guestDto.ClosestTo;
        Hobbies = guestDto.Hobbies;
        Relation = guestDto.Relation;
        SpecialFood = guestDto.SpecialFood;
    }
    public GuestDto ExtractDto() => new GuestDto(Name, Age, MyPreferedLanguage, ClosestTo, Hobbies, Relation, SpecialFood);
    public override string? ToString() => JsonSerializer.Serialize(this);
}
