using System.Text.Json;
using Microsoft.Azure.Cosmos.Table;

public class Guest : TableEntity
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? MyPreferedLanguage { get; set; }
    public string? ClosestTo { get; set; }
    public string? Relation { get; set; }
    public string[] Hobbies { get; set; }

    public Guest(
    string? name,
    int age,
    string? myPreferedLanguage,
    string? closestTo, 
    string[] hobbies,
    string? relation)
    {
        RowKey = Guid.NewGuid().ToString("d");
        PartitionKey = myPreferedLanguage ?? "english";
        Name = name;
        Age = age;
        MyPreferedLanguage = myPreferedLanguage;
        ClosestTo = closestTo;
        Hobbies = hobbies;
        Relation = relation;
    }
    public Guest(){}

    public override string? ToString() => JsonSerializer.Serialize(this);
}
