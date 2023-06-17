using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.gameObject.GetComponent<Lizard>())
    //     {
    //         anim.SetTrigger("underAttack");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Lizard>())
        {
            anim.SetBool("underAttackBool", true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Lizard>())
        {
            anim.SetBool("underAttackBool", false);
        }
    }
}
