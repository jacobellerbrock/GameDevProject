using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MCHandler : MonoBehaviour
{

    public int health;
    public int maxhealth = 5;
    public int attack = 1;
    public float speed = 1;
    public bool invulnerable = false;

    public Text StatusText;

    [SerializeField] private AnimationStateChanger changer;

    [SerializeField] private McColliderContainer hurtbox;

    [SerializeField] private Text GameOverText;

    private void Start()
    {
        health = maxhealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        // if (hurtbox.GetColliders().Count > 0)
        // {
        //     int maxDamage = Int32.MinValue;
        //     foreach (var collider in hurtbox.GetColliders())
        //     {
        //         if (!collider.tag.Equals("Enemy")) return;
        //         int damage = collider.GetComponent<Slime>().attack;
        //         if (damage > maxDamage) maxDamage = damage;
        //     }
        //     
        //     Hurt(maxDamage);
        // }
    }

    public void Hurt(int damage)
    {
        if (invulnerable) return;
        invulnerable = true;
        changer.ChangeAnimationState("Hurt");
        health -= damage;
    }

    public void Die()
    {
        changer.ChangeAnimationState("Death");
        GetComponent<AudioSource>().Play();

        StartCoroutine(EndGame());

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(1);
            GameOverText.enabled = true;

            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MainMenu");

        }
    }
}
