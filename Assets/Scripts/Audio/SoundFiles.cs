#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class SfxLibraryAsset
{
    [MenuItem("Assets/Create/SfxLibrary")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<SfxLibrary>();
    }
}
#endif