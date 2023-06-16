using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (!obj.GetComponent<Defenders>())
        {
            return;
        }
      
        anim.SetBool("isAttacking", true);
        attacker.Attack(obj);
        
    }
}
