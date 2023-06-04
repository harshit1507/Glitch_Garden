using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing Clip: " + thisLevelMusic);

        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
