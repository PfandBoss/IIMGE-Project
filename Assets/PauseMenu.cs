using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject _player;
    public GameObject pauseFirstBtn;

    private CharacterController rb;
    private Quaternion currRot;
    private Quaternion currCamRot;

    private void Start()
    {
        Debug.Log(_player.name);
        rb = _player.GetComponent<CharacterController>();
        currRot = _player.transform.rotation;
        currCamRot = Camera.main.transform.rotation;
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
            currRot = _player.transform.rotation;
            currCamRot = Camera.main.transform.rotation;
        }
       
        if (gameIsPaused)
        {
            _player.transform.rotation = currRot;
            Camera.main.transform.rotation = currCamRot;
        }
    }


    public void Resume()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        rb.enabled = true;
        gameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(pauseFirstBtn);
        
        rb.enabled = false;
        gameIsPaused = true;
    }

    public void QuitToMainMenu()
    {
        pauseMenuUI.SetActive(false);
        rb.enabled = true;
        gameIsPaused = false;
        SceneManager.LoadScene("Main Menu");
    }
    
}
