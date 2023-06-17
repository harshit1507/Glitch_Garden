using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float levelSeconds = 100f;
    [SerializeField] private GameObject winLabel;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;

    private LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (Time.timeSinceLevelLoad / levelSeconds);

        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            audioSource.Play();
            StartCoroutine(LoadNextLevel());
            isEndOfLevel = true;
        }
    }

    IEnumerator LoadNextLevel()
    {
        winLabel.SetActive(true);
        yield return audioSource.clip.length;
        levelManager.LoadLevel("Level 2");
    }
}
