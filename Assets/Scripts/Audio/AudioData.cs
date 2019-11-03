using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AudioData : ScriptableObject {

    public static AudioData instance;

    public UI ui;
    public SFX sfx;

#if UNITY_EDITOR
    [MenuItem("Assets/Create/AudioData")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<AudioData>();
    }
#endif
}

[System.Serializable]
public class SFX
{
    public AudioClip[] eat;
    public AudioClip[] movementStart;
    public AudioClip[] movementStop;
}

[System.Serializable]
public class VO
{
    public AudioClip[] grunts;
}

[System.Serializable]
public class UI
{
    public AudioClip select;
    public AudioClip confirm;
    public AudioClip cancel;

}




