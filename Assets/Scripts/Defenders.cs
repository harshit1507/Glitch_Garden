using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    [SerializeField] private int starCost = 100;
    
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    private void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
