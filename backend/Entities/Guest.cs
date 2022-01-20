using System.Text.Json;
using Microsoft.Azure.Cosmos.Table;

public class Guest : TableEntity
{
    public new string? RowKey { get; set; }
    public new string? PartitionKey { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? MyPreferedLanguage { get; set; }

    public Guest(
    string? name,
    int age,
    string? rowkey,
    string? myPreferedLanguage,
    string? closestTo,
    string? partitionKey
,
    string? ClosestTo)
    {
        RowKey = rowkey ?? Guid.NewGuid().ToString("d");
        PartitionKey = myPreferedLanguage;
        Name = name;
        Age = age;
        MyPreferedLanguage = myPreferedLanguage;
        ClosestTo = closestTo;
    }
    public Guest()
    {
    }
    public override string? ToString() => JsonSerializer.Serialize(this);
}
