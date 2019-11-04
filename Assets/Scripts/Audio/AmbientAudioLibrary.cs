using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AmbientAudioLibrary : ScriptableObject
{
    public static AmbientAudioLibrary instance;

    public Level level;

#if UNITY_EDITOR
    [MenuItem("Assets/Create/MusicData")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<AmbientAudioLibrary>();
    }
#endif
}

[System.Serializable]
public class Level
{
    public AudioClip dungeon;

    public AudioClip[] random;
}


