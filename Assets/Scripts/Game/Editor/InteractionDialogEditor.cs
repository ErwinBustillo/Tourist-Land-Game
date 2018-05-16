using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractionDialog))]
public class InteractionDialogEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        InteractionDialog interactionDialog = target as InteractionDialog;

        if(GUILayout.Button("Add Dialog"))
        {
            interactionDialog.dialogs.Add(new Dialog());
        }
    }
}
