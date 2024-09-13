using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public static SoundMusicManager Instance;

    [SerializeField]
    private GameObject _selectionStage;

    [SerializeField]
    private AudioSource _audioSource, _musicPlayer;

    [SerializeField]
    private AudioClip _cannonBallFire, _combatMusic, _selectStageMusic;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ManageMusic();
    }

    public void PlayCannonBallSFX()
    {
        _audioSource.clip = _cannonBallFire;
        _audioSource.Play();
    }

    private void ManageMusic()
    {
        if (_selectionStage.activeSelf)
        {
            _musicPlayer.clip = _selectStageMusic;
            PlayClip(_musicPlayer);
        }
        else
        {
            _musicPlayer.clip = _combatMusic;
            PlayClip(_musicPlayer);

        }
    }

    private void PlayClip(AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    
}
