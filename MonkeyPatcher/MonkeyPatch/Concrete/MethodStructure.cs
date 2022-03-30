using System.Text.Json.Serialization;

namespace MonkeyPatch.MonkeyPatch.Concrete;

internal class MethodStructure
{
    internal MethodStructure(string key, int depth, int stackPosition)
    {
        Key = key;
        Depth = depth;
        StackPosition = stackPosition;
    }



    public string Signature { get; set; }
    public string? Owner { get; set; }
    public int Depth { get; set; }
    public int StackPosition { get; set; }
    public string? ReturnType { get; set; }
    [JsonIgnore]
    public Delegate Action { get; set; }
    [JsonIgnore]
    public bool IsDetoured { get; set; }
    [JsonIgnore]
    public string Key { get; set; }

    [JsonIgnore]
    public List<MethodStructure> SubNodes { get; set; } = new();
   
    [JsonIgnore]
    public List<MethodStructure> SuperNodes { get; set; } = new();
    public List<int> Indexes { get; set; } = new();
}