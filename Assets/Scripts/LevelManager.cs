using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float autoLoadNextLevelAfter = 2f;

    private void Start()
    {
        StartCoroutine(LoadNextLevel());
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level Load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(autoLoadNextLevelAfter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
