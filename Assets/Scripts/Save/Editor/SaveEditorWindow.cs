using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections;
using System;
using System.Linq;

public class SaveEditorWindow : EditorWindow {

    [MenuItem("Edit/Save")]
    public static void Init() {
        SaveManager.Init();
        GetWindow<SaveEditorWindow>("Save Editor");
    }

    private void OnGUI() {
        GUILayout.Label("Lumina Save Editor v0.1\n");

        FieldInfo[] fields = typeof(Save).GetFields();
        foreach (FieldInfo field in fields) {
            GUILayout.Label(field.Name + " (" + field.FieldType.Name + ")");
            
            if (field.FieldType.Name.Contains("Dictionary"))
                GUILayout.Label("Dictionaries are not implemented for display yet.");
            else if (field.FieldType.Name.Contains("List") || field.FieldType.IsArray)
                OnListGUI(field);
            else if (field.FieldType == typeof(bool))
                OnBoolGUI(field);
            else
                OnTextAreaGUI(field);
        }

        if (GUILayout.Button("Save"))
            SaveManager.Save();

        if (GUILayout.Button("Reset")) {
            SaveManager.save = new();
            SaveManager.Save();
        }
    }

    private void OnListGUI(FieldInfo field) {
        IEnumerable enumerable = field.GetValue(SaveManager.save) as IEnumerable;
        int i = 1;
        foreach (object obj in enumerable.OfType<object>()) {
            GUILayout.Label("\t" + i + " " + obj.GetType().Name + " - " + obj.ToString());
            i++;
        }

        GUILayout.Label("\tCan not edit type " + field.FieldType.Name + "!");
    }

    private void OnBoolGUI(FieldInfo field) {
        field.SetValue(SaveManager.save, GUILayout.Toggle((bool)field.GetValue(SaveManager.save), ""));
    }

    private void OnTextAreaGUI(FieldInfo field) {
        string str = GUILayout.TextField(field.GetValue(SaveManager.save).ToString());

        if (field.FieldType == typeof(string)) field.SetValue(SaveManager.save, str);
        else if (field.FieldType == typeof(int)) field.SetValue(SaveManager.save, int.Parse(str));
        else if (field.FieldType == typeof(double)) field.SetValue(SaveManager.save, double.Parse(str));
        else if (field.FieldType == typeof(float)) field.SetValue(SaveManager.save, float.Parse(str));
        else if (field.FieldType == typeof(short)) field.SetValue(SaveManager.save, short.Parse(str));
        else if (field.FieldType == typeof(long)) field.SetValue(SaveManager.save, long.Parse(str));
        else if (field.FieldType == typeof(byte)) field.SetValue(SaveManager.save, byte.Parse(str));
        else {
            GUILayout.Label("Error: unrecognized type " + field.FieldType.Name);
        }
    }
}