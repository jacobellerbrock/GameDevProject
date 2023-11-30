using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenu;
    
    private void Start()
    {
        optionsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Board");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
