using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor {


    ///<summary>
    ///Allows the "Autoupdate" and "Generate" buttons to work for the MapGenerator script in the Unity Editor.
    ///</summary>
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)                  //If a setting is changed, call mapGen.GenerateMap
            {
                mapGen.GenerateMap();               
            }
        }

        if(GUILayout.Button("Generate")) {          //If the "Generate" button is pushed, call mapGen.GenerateMap
            mapGen.GenerateMap();
        }
    }
}
