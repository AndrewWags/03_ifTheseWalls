using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SfxLibrary : ScriptableObject {

    public static SfxLibrary instance;

    public UI ui;
    public SFX sfx;

#if UNITY_EDITOR
    [MenuItem("Assets/Create/SfxLibrary")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<SfxLibrary>();
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




