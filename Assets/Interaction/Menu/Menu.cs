using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Menu : MonoBehaviour
{
    public int selectStart = 0;
    public int counter = 0;
    private Image startSelect;
    private Image exitSelect;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startSelect = GameObject.Find("start").GetComponent<Image>();
        exitSelect = GameObject.Find("exit").GetComponent<Image>();
        startSelect.enabled = false;
        exitSelect.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectStart = (selectStart + 1) % 2;
            counter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            selectStart = (selectStart + 1) % 2;
            counter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectStart = (selectStart + 1) % 2;
            counter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectStart = (selectStart + 1) % 2;
            counter = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (selectStart==0)
            {
                StartGame();
            }
            else
            {
                QuitGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectStart==0)
            {
                StartGame();
            }
            else
            {
                QuitGame();
            }
        }
    }

    private void FixedUpdate()
    {
        counter = (counter + 1) % 30;
        if (counter <= 15)
        {
            if (selectStart==0)
            {
                startSelect.enabled = true;
                exitSelect.enabled = false;
            }
            else
            {
                startSelect.enabled = false;
                exitSelect.enabled = true;
            }
        }
        else if (counter >= 15)
        {
            startSelect.enabled = false;
            exitSelect.enabled = false;
        }
    }

    public void StartGame()
    {
        SceneLoad.instance.ContinueStory();
        StartCoroutine(SceneLoad.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}