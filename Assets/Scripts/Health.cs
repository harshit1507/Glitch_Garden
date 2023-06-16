using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;
   
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
