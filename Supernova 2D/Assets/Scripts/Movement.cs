using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float speed;
    private int attack;
    private MCHandler mc;
    [SerializeField] private AnimationStateChanger animationStateChanger;
    protected Rigidbody2D rb;
    [SerializeField] private Transform body;
    
    // Start is called before the first frame update
    void Awake()
    {
        mc = GetComponent<MCHandler>();
        rb = GetComponent<Rigidbody2D>();

        speed = mc.speed;
        attack = mc.attack;

    }

    public void MoveRB(Vector3 vel)
    {
        rb.velocity = vel * speed;
        if (vel.magnitude > 0)
        {
            if (animationStateChanger.currentState.Equals("Idle")) animationStateChanger.ChangeAnimationState("Walk");

            if (vel.x > 0)
            {
                body.localScale = new Vector3(1, 1, 1);
            } else if (vel.x < 0)
            {
                body.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (animationStateChanger.currentState.Equals("Walk")) animationStateChanger.ChangeAnimationState("Idle");
        }
    }
}
