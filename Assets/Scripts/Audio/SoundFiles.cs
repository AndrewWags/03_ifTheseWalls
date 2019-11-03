#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class AudioDataAsset
{
    [MenuItem("Assets/Create/AudioData")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<AudioData>();
    }
}
#endif