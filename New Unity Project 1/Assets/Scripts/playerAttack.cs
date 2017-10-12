﻿using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackedCd = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;
	// Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
	
	void Update ()
    {
	    if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackedCd;
            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if (attackTimer>0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Attacking", attacking);
	}
}
