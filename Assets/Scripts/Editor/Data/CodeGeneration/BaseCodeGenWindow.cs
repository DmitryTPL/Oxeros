using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public abstract class BaseCodeGenWindow : EditorWindow
{
    public readonly static string Tab = CodeGenConstants.Tab;

    private List<System.Func<string, string>> _replacements;

    protected string Name { get; set; }
    protected string Namespace { get; set; }
    protected bool IsInSeparateFolder { get; private set; }

    private void OnGUI()
    {
        if (_replacements == null)
        {
            InitReplacements();
        }

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        var content = new GUIContent("Namespace:");

        GUILayout.Label(content, new GUIStyle(GUI.skin.label)
        {
            margin = new RectOffset(10, 0, 0, 0)
        });

        Namespace = EditorGUILayout.TextField(Namespace);

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();

        content = new GUIContent("Name:");

        GUILayout.Label(content, new GUIStyle(GUI.skin.label)
        {
            margin = new RectOffset(10, 0, 0, 0)
        });

        Name = EditorGUILayout.TextField(Name);

        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        
        IsInSeparateFolder = GUILayout.Toggle(IsInSeparateFolder, "Separate folder");

        AdditionalUiElements();

        if (GUILayout.Button("Create") && !string.IsNullOrEmpty(Name))
        {
            var directoryPath = EditorUtility.OpenFolderPanel("Root Directory", "Assets/Scripts", "");

            if (!string.IsNullOrEmpty(directoryPath))
            {
                GenerateAssets(directoryPath);

                AssetDatabase.Refresh();
            }
        }
    }

    protected abstract void GenerateAssets(string directoryPath);

    protected virtual void AdditionalUiElements()
    {
    }

    private void InitReplacements()
    {
        _replacements = new List<System.Func<string, string>>
        {
            line => line.Replace("$NAME$", Name)
        };
    }

    protected void CreateScript(string path, ScriptData data)
    {
        var directory = Directory.CreateDirectory(Path.Combine(path, ProcessReplacements(data.RelativeDirectory)));

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

        script.AppendLine($"namespace {Namespace}");
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

        CreateDataType(data, script);
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

    private void CreateDataType(ScriptData data, StringBuilder script)
    {
        AppendLine(Tab, $"public {data.DataType} {GetTypeName(data)}{(data.Inheritances.Length > 0 ? " : " + ProcessReplacements(string.Join(", ", data.Inheritances)) : "")}",
            script);

        if (data.Constraints.Length > 0)
        {
            foreach (var constraint in data.Constraints)
            {
                AppendLine($"{Tab}{Tab}", $"where {ProcessReplacements(constraint)}", script);
            }
        }
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