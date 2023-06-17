using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defenderParent;
    
    // [SerializeField] Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        // myCamera = Camera.main;
        defenderParent = GameObject.Find("Defenders");

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
        defender.transform.parent = defenderParent.transform;
        // print(SnapToGrid(CalculateWorldPointOfMouseClick()));
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
