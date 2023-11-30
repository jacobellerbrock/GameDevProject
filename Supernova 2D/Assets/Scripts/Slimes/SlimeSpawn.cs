using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlimeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject slime;
    public int spawns;

    private void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {

        StartCoroutine(SpawnSlime());
        
        IEnumerator SpawnSlime()
        {
            bool dirtyflag = false;
            while (true)
            {
                Vector3 position = new Vector3(Random.Range(0, 2) == 0 ? -8.8f : 8.8f, Random.Range(-4.3f, 4.3f), 0);
                Instantiate(slime, position, Quaternion.identity);
                if (spawns >= 100) dirtyflag = true;
                if (!dirtyflag) spawns++;
                yield return new WaitForSeconds(1f/spawns * 10);
            }
        }
    }
}
