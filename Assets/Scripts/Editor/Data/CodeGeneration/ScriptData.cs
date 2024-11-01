using System;

[Serializable]
public struct ScriptData
{
    public string[] Usings { get; set; }
    public string RelativeDirectory { get; set; }
    public string[] Content { get; set; }
    public string DataType { get; set; }
    public string Type { get; set; }
    public string[] Inheritances { get; set; }
    public string[] Constraints { get; set; }
    public string[] Attributes { get; set; }
}