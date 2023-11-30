using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireSword : MonoBehaviour, Spell
{
    public GameObject gameObject
    {
        get { return gameObject; }
        set { gameObject = value; }
    }

    public Transform attackPoint;
    public float attackRange = 5f;
    public int attack = 5;
    public LayerMask layerMask;

    public AnimationStateChanger changer;

    public FireSword(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void Cast()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerMask);

        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<Slime>().Damage(attack);
        }

        changer.ChangeAnimationState("FireSword");
        changer.currentState = "Idle";
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
