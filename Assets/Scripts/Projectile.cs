using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
        Health health = other.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
