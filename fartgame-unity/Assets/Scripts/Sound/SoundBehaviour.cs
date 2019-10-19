using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundBehaviour : MonoBehaviour
{
    public List<SoundCollection> SoundCollections;

    private AudioSource[] audioSources;
    private int currentAudioSourceIndex;

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void PlaySound(string id)
    {
        var collection = GetCollection(id);
        PlayClip(collection.GetRandomSound());
    }

    private void PlayClip(AudioClip clip)
    {
        audioSources[currentAudioSourceIndex].PlayOneShot(clip);

        ++currentAudioSourceIndex;
        if (currentAudioSourceIndex >= audioSources.Length)
        {
            currentAudioSourceIndex = 0;
        }
    }

    private SoundCollection GetCollection(string id)
    {
        foreach (var c in SoundCollections)
        {
            if (c.Id == id) return c;
        }

        return null;
    }
}
