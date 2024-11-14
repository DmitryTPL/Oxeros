using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class GenerateBindingsWindow : BaseCodeGenWindow
{
    public enum Binding
    {
        Animation
    }

    [MenuItem("Generate/Bindings")]
    private static void Init()
    {
        GetWindow(typeof(GenerateBindingsWindow), false, "Create New Bindings To State Machine States").Show();
    }

    private bool _animations;

    private Dictionary<Binding, bool> _bindingSelections;

    protected override void AdditionalUiElements()
    {
        if (_bindingSelections == null)
        {
            InitBindings();
        }

        GUILayout.Space(10);

        GUILayout.Label("Bindings:");

        _bindingSelections![Binding.Animation] = GUILayout.Toggle(_bindingSelections[Binding.Animation], "Animation");

        GUILayout.Space(10);
    }

    private void InitBindings()
    {
        _bindingSelections = new Dictionary<Binding, bool>();

        foreach (var value in Enum.GetValues(typeof(Binding)))
        {
            _bindingSelections.Add((Binding)value, true);
        }
    }

    protected override void GenerateAssets(string path)
    {
        if (IsInSeparateFolder)
        {
            path = Directory.CreateDirectory(Path.Combine(path, Name)).FullName;
        }

        var data = File.ReadAllText(Path.Combine(Application.dataPath, "Scripts/Editor/Bindings/Templates.json"));

        var templates = JsonConvert.DeserializeObject<Dictionary<string, ScriptData>>(data);

        var selectedBindings = _bindingSelections.Where(b => b.Value).Select(b => b.Key.ToString()).ToList();

        foreach (var template in templates)
        {
            var bindingType = template.Key.Split('_');

            if (selectedBindings.Contains(bindingType[0]))
            {
                CreateScript(path, template.Value);
            }
        }

        Debug.Log("Bindings created");
    }
}