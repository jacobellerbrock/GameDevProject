using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Slime : MonoBehaviour
{
    public int health;
    public int attack;
    public int speed;
    
    private Animator animator;
    private AudioSource audioSource;
    private bool dying;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Crystal crystal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Damage(1);
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.Play("Green Death - Animation");
            audioSource.PlayOneShot(clip);
            if (!dying)
            {
                if (Random.Range(0, 100) < 20) Instantiate(crystal, transform.position, Quaternion.identity);
                dying = true;
            }
            Destroy(gameObject, 1.4f);
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        animator.Play("Green Hurt - Animation");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<MCHandler>().Hurt(attack);

        } else if (other.gameObject.tag.Equals("Stage"))
        {
            Transform t = transform;
            Vector3 scale = t.localScale;
            t.localScale = new Vector3(scale.x * -1, scale.y);
        }
    }
}
