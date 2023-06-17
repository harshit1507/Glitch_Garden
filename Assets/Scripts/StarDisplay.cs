using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starText;
    [SerializeField] private int stars = 100;

    [SerializeField] private bool isTesting = true;

    public enum Status
    {
        SUCCESS,
        FAILURE
    };
    // Start is called before the first frame update
    void Awake()
    {
        if (isTesting)
        {
            PlayerPrefsManager.SetStars(stars);
        }
        stars = PlayerPrefsManager.GetStars();
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    
    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        PlayerPrefsManager.SetStars(stars);
        starText.text = stars.ToString();
    }
}
