using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McColliderContainer : MonoBehaviour
{
    public HashSet<Collider2D> colliders = new HashSet<Collider2D>();

    public HashSet<Collider2D> GetColliders()
    {
        return colliders;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag.Equals("Player")) colliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.tag.Equals("Player")) colliders.Remove(other);
    }
}
