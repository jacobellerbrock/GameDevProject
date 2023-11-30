using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Crystal : MonoBehaviour
{
    private void Collect(Collider2D other)
    {
        MCHandler mc = other.GetComponent<MCHandler>();
        Text statusText = mc.StatusText;
        
        switch (Random.Range(0, 2))
        {
            case 0:
                mc.health = mc.maxhealth;
                statusText.text = "Fully healed";
                break;
            case 1:
                float speedinc = Random.Range(0.1f, 1f);
                mc.speed += speedinc;
                statusText.text = "Speed increase: +" + speedinc.ToString("0.00");
                break;
            case 2:
                int attackinc = Random.Range(1, 5);
                mc.attack += attackinc;
                statusText.text = "Attack increase: +" + attackinc;
                break;
        }

        statusText.enabled = true;

        StartCoroutine(TextManager());

        IEnumerator TextManager()
        {
            yield return new WaitForSeconds(2);
            statusText.enabled = false;
            Destroy(gameObject);
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;
        Collect(other);
    }
}
