using UnityEngine;

[CreateAssetMenu(fileName = "dat_sound_collection", menuName = "Fartgame/Sound Collection", order = 1)]
public class SoundCollection : ScriptableObject
{
    public string Id;
    public AudioClip[] Clips;

    public AudioClip GetRandomSound()
    {
        if (Clips.Length == 0) return null;

        return Clips[Random.Range(0, Clips.Length)];
    }
}
