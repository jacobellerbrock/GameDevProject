using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContainer : MonoBehaviour
{
    public HashSet<Collider2D> colliders = new HashSet<Collider2D>();

    public HashSet<Collider2D> GetColliders()
    {
        return colliders;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag.Equals("Hitbox")) colliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.tag.Equals("Hitbox")) colliders.Remove(other);
    }
}
