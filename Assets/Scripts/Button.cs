using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Button : MonoBehaviour
{
    [SerializeField] private GameObject defenderPrefab;
    [SerializeField] private TextMeshProUGUI costText;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    // Start is called before the first frame update
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText)
        {
            Debug.LogWarning(name + " has no cost text.");
        }

        costText.text = defenderPrefab.GetComponent<Defenders>().GetStarCost().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
