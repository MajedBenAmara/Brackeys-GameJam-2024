using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;

public partial class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.Mixer != null)
            {
                s.source.outputAudioMixerGroup = s.Mixer;
            }
        }
    }

    void Start()
    {
        Play("Loop");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
        s.source.pitch = s.pitch;
    }

    public void PlayOnUpdate(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        if (!s.source.isPlaying) s.source.Play();
        s.source.pitch = s.pitch;
    }

    public void Pitch(float Pitch)
    {
        foreach (Sound s in sounds)
        {
            if (s.AffectedbyTime)
            {
                s.source.pitch = Pitch;
            }
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}
