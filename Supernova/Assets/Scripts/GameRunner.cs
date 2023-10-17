using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _controller.Update();
    }
}
