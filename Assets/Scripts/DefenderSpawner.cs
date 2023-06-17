using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenderParent;

    private StarDisplay starDisplay;
    
    // [SerializeField] Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        // myCamera = Camera.main;
        CheckAndCreateParent();
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void CheckAndCreateParent()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }
    
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        if (!defender)
        {
            Debug.Log("Please select a defender first from the selection.");
            return;
        }
        int defenderCost = defender.GetComponent<Defenders>().GetStarCost();
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn.");
        }
        
        // print(SnapToGrid(CalculateWorldPointOfMouseClick()));
    }

    private void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        GameObject myDefender = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        myDefender.transform.parent = defenderParent.transform;
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        // float mouseX = Input.mousePosition.x;
        // float mouseY = Input.mousePosition.y;
        // float distanceFromCamera = Input.mousePosition.z;
        //
        // Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        // Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        // return worldPos;
        
        
        return new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(newX, newY);
    }
}
