using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{

    private MCHandler mc;
    
    [SerializeField] private Movement movement;
    [SerializeField] private Attack attack;
    [SerializeField] private AnimationStateChanger changer;
    [SerializeField] private FireSword fireSword;

    [SerializeField] private Text PauseMenu;
    public static bool paused;

    private void Awake()
    {
        mc = GetComponent<MCHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9)) Pause();

        if (paused) return;
        if (mc.health <= 0) return;
        
        if (Input.GetKeyDown(KeyCode.Q)) CardManager.singleton.ChangeSelected(-1);
        if (Input.GetKeyDown(KeyCode.E)) CardManager.singleton.ChangeSelected(1);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) attack.DoAttack(mc.attack);
        
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton1)) fireSword.Cast();
        
        //cheats
        if (Input.GetKeyDown(KeyCode.Backspace)) CardManager.singleton.DrawCard();

        if (Input.GetKeyDown(KeyCode.Return)) mc.Hurt(mc.attack);
    }

    private void FixedUpdate()
    {

        if (paused) return;

        if (mc.health <= 0)
        {
            movement.MoveRB(Vector3.zero);
            return;
        }
        
        Vector3 vel = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0) vel.y = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0) vel.y = -1;
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0) vel.x = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0) vel.x = 1;
        
        movement.MoveRB(vel);
    }

    private void Pause()
    {
        paused = !paused;
        if (paused)
        {
            PauseMenu.enabled = true;
        }
        else
        {
            PauseMenu.enabled = false;
        }
    }
}
