using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class NewSkinWindow : EditorWindow
{
    static Skin currentSkin;
    static List<Skin> playerSkins;

    private const string FileDirectoryPath = "Skin System/Skins/";

    public static void ShowWindow(Skin skin, ref List<Skin> skinsList)
    {
        currentSkin = skin;
        playerSkins = skinsList;
        GetWindow<NewSkinWindow>("New Skin");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create New Skin");

        GUILayout.Space(4);
        currentSkin.skinName = EditorGUILayout.TextField("Skin Name", currentSkin.skinName);

        GUILayout.Space(4);
        currentSkin.skinObject = (GameObject) EditorGUILayout.ObjectField("Skin Object", currentSkin.skinObject, typeof(GameObject), false);

        GUILayout.Space(4);
        currentSkin.skinIcon = (Sprite) EditorGUILayout.ObjectField("Skin Icon", currentSkin.skinIcon, typeof(Sprite), false);

        GUILayout.Space(4);
        currentSkin.joyIcon = (Sprite) EditorGUILayout.ObjectField("Joystick Icon", currentSkin.joyIcon, typeof(Sprite), false);

        GUILayout.Space(4);
        currentSkin.locked = EditorGUILayout.Toggle("Is Locked", currentSkin.locked);

        GUILayout.Space(1);
        currentSkin.defaultLockState = EditorGUILayout.Toggle("Default Lock State", currentSkin.defaultLockState);

        GUILayout.Space(4);
        currentSkin.cost = EditorGUILayout.IntField("Cost", currentSkin.cost);


        if (GUILayout.Button("Create"))
        {
            playerSkins.Add(currentSkin);

            string FileName = currentSkin.skinName + " Skin.asset";

            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Application.dataPath, FileDirectoryPath));

            AssetDatabase.CreateAsset(currentSkin, "Assets/" + FileDirectoryPath + FileName);

            Close();
        }
    }
}
