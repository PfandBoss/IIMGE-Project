using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject _player;

    private CharacterController rb;
    private Quaternion currRot;

    private void Start()
    {
        Debug.Log(_player.name);
        rb = _player.GetComponent<CharacterController>();
        currRot = Camera.main.transform.rotation;
    }


    public void EnterMenu()
    {
        
        
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        
    }
    

    private void Update()
    {
        
        if (!gameIsPaused)
        {
            currRot = Camera.main.transform.rotation;
        }
       
        if (gameIsPaused)
        {
            Camera.main.transform.rotation = currRot;
        }
    }


    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        rb.enabled = true;
        gameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        rb.enabled = false;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
