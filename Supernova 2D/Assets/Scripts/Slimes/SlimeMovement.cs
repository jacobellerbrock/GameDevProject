using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    private Slime slime;
    private Rigidbody2D rb;
    
    void Awake()
    {
        slime = GetComponent<Slime>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (PlayerInputHandler.paused || slime.health <= 0)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        
        Vector3 vel = new Vector3(transform.localScale.x, 0);
        rb.velocity =  vel * slime.speed;
    }
}
