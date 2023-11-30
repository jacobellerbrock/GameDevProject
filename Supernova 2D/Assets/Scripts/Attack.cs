using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] AnimationStateChanger changer;
    [SerializeField] Transform hitbox;
    [SerializeField] private float range = 2f;
    [SerializeField] private LayerMask enemyLayers;

    public void DoAttack(int damage)
    {
        changer.ChangeAnimationState("LightAttackAnimation");
        
        foreach (var collider in Physics2D.OverlapCircleAll(hitbox.position, range, enemyLayers))
        {
            collider.GetComponent<Slime>().Damage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (hitbox == null) return;
        Gizmos.DrawWireSphere(hitbox.position, range);
    }
}
