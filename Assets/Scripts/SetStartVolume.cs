using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
        }
        else
            Debug.LogWarning("No music manager found in Start Scene, can't set volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
