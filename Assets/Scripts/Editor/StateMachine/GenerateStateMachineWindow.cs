using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class GenerateStateMachineWindow : BaseCodeGenWindow
{
    [MenuItem("Generate/StateMachine")]
    private static void Init()
    {
        GetWindow(typeof(GenerateStateMachineWindow), false, "Create New State Machine").Show();
    }

    protected override void AdditionalUiElements()
    {
        GUILayout.Space(10);
    }

    protected override void GenerateAssets(string path)
    {
        if (IsInSeparateFolder)
        {
            path = Directory.CreateDirectory(Path.Combine(path, Name)).FullName;
        }

        var data = File.ReadAllText(Path.Combine(Application.dataPath, "Scripts/Editor/StateMachine/Templates.json"));

        var templates = JsonConvert.DeserializeObject<Dictionary<string, ScriptData>>(data);

        foreach (var template in templates)
        {
            CreateScript(path, template.Value);
        }

        Debug.Log("State machine created");
    }
}