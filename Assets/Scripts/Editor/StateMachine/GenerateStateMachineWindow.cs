using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class GenerateStateMachineWindow : EditorWindow
{
    private struct ScriptData
    {
        public string[] Usings { get; set; }
        public string RelativeDirectory { get; set; }
        public string[] Content { get; set; }
        public string DataType { get; set; }
        public string Type { get; set; }
        public string[] Inheritances { get; set; }
        public string[] Attributes { get; set; }
    }

    public const string Tab = "    ";

    [MenuItem("StateMachine/Create New")]
    private static void Init()
    {
        GetWindow(typeof(GenerateStateMachineWindow), false, "Create New State Machine").Show();
    }

    private string _name;
    private string _namespace;

    private List<System.Func<string, string>> _replacements;

    private void OnGUI()
    {
        if (_replacements == null)
        {
            InitReplacements();
        }

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        var content = new GUIContent("State Machine Namespace:");

        GUILayout.Label(content, new GUIStyle(GUI.skin.label)
        {
            margin = new RectOffset(10, 0, 0, 0)
        });

        _namespace = EditorGUILayout.TextField(_namespace);

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();

        content = new GUIContent("State Machine Type:");

        GUILayout.Label(content, new GUIStyle(GUI.skin.label)
        {
            margin = new RectOffset(10, 0, 0, 0)
        });

        _name = EditorGUILayout.TextField(_name);

        GUILayout.Space(10);

        if (GUILayout.Button("Create") && !string.IsNullOrEmpty(_name))
        {
            var directoryPath = EditorUtility.OpenFolderPanel("State Machine Root", "Assets/Scripts", "");

            if (!string.IsNullOrEmpty(directoryPath))
            {
                GenerateAssets(directoryPath);

                AssetDatabase.Refresh();
            }
        }

        GUILayout.EndHorizontal();
    }

    private void InitReplacements()
    {
        _replacements = new List<System.Func<string, string>>
        {
            line => line.Replace("$NAME$", _name)
        };
    }

    private void GenerateAssets(string path)
    {
        var directory = Directory.CreateDirectory(Path.Combine(path, _name));

        var data = File.ReadAllText(Path.Combine(Application.dataPath, "Scripts/Editor/StateMachine/Templates.json"));

        var templates = JsonConvert.DeserializeObject<Dictionary<string, ScriptData>>(data);

        foreach (var template in templates)
        {
            CreateScript(directory.FullName, template.Value);
        }

        Debug.Log("Created");
    }

    private void CreateScript(string path, ScriptData data)
    {
        var directory = Directory.CreateDirectory(Path.Combine(path, data.RelativeDirectory));

        var script = GetScriptInsideNamespace(data);

        SaveScript(data, directory.FullName, script);
    }

    private string GetScriptInsideNamespace(ScriptData data)
    {
        var script = new StringBuilder();

        foreach (var @using in data.Usings)
        {
            script.AppendLine($"using {@using};");
        }

        if (data.Usings.Length > 0)
        {
            script.AppendLine();
        }

        script.AppendLine($"namespace {_namespace}");
        script.AppendLine($"{{");

        AppendScript(data, script);

        script.Append($"}}");

        return script.ToString();
    }

    private void AppendScript(ScriptData data, StringBuilder script)
    {
        if (data.Attributes.Length > 0)
        {
            AppendLine(Tab, $"[{ProcessReplacements(string.Join(", ", data.Attributes))}]", script);
        }

        AppendLine(Tab, CreateDataType(data), script);
        AppendLine(Tab, $"{{", script);

        foreach (var line in data.Content)
        {
            AppendLine($"{Tab}{Tab}", $"{ProcessReplacements(line)}", script);
        }

        AppendLine(Tab, $"}}", script);
    }

    private void AppendLine(string prefix, string line, StringBuilder script)
    {
        script.AppendLine($"{prefix}{line}");
    }

    private string CreateDataType(ScriptData data)
    {
        return $"public {data.DataType} {GetTypeName(data)}{(data.Inheritances.Length > 0 ? " : " + ProcessReplacements(string.Join(", ", data.Inheritances)) : "")}";
    }

    private string GetTypeName(ScriptData data)
    {
        return $"{ProcessReplacements(data.Type)}";
    }

    private void SaveScript(ScriptData data, string directory, string content)
    {
        File.WriteAllText(Path.Combine(directory, $"{GetTypeName(data)}.cs"), content);
    }

    private string ProcessReplacements(string line)
    {
        return _replacements.Aggregate(line, (current, replacement) => replacement(current));
    }
}