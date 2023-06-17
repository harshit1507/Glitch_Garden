using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileParent;
    [SerializeField] private GameObject gun;
    [SerializeField] private Animator anim;
    [SerializeField] private AttackerSpawner myLaneAttackerSpawner;

    private void Start()
    {
        CheckAndCreateParent();
        anim = GetComponent<Animator>();
        SetMyLaneAttackerSpawner();
    }

    private void CheckAndCreateParent()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        if (myLaneAttackerSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attacker in myLaneAttackerSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void SetMyLaneAttackerSpawner()
    {
        AttackerSpawner[] attackerSpawners = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            if (attackerSpawner.transform.position.y == transform.position.y)
            {
                myLaneAttackerSpawner = attackerSpawner;
                return;
            }
        }
        
        Debug.LogError(name + " can't find spawner in lane");
    }
}
