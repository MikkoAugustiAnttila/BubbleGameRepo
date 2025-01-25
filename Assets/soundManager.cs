using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;
    [SerializeField] Sound[] sounds;
    void Awake()
    {
        instance = this;
    }

    public void PlaySound(string id)
    {
        AudioClip clipToPlay = null;
        foreach (Sound sound in sounds)
        {
            if (sound.id == id)
            {
                clipToPlay = sound.clip;
                break;
            }
        }

        if (clipToPlay)
        {
            //Play the clip
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clipToPlay;

            audioSource.pitch = Random.Range(0.85f, 1.15f);
            audioSource.loop = false;
            audioSource.Play();

            Destroy(audioSource, clipToPlay.length);
        }
    }
}

[Serializable] public class Sound
{
    public string id;
    public AudioClip clip;
}
