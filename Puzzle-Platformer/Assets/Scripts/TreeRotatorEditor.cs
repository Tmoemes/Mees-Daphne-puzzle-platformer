using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeRotator))]
public class TreeRotatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TreeRotator randomizer = (TreeRotator)target;

        if (GUILayout.Button("Randomize Child Rotation"))
        {
            randomizer.RotateTrees();
        }
    }
}