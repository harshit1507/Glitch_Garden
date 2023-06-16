using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)] [SerializeField] float currentSpeed;
    private GameObject currentTarget;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        // rigidbody2D.isKinematic = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name + " trigger enter.");
    }

    void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
            {
                health.DealDamage(damage);
            }
        }

        Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
        
    }
}
