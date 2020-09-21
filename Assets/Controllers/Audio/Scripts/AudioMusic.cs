using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "ScriptableObjects/AudioMusic", order = 1)]
public class AudioMusic : ScriptableObject
{
    public AudioClip songToPlay;
}
