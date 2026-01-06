using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] GameObject juego;
    [SerializeField] GameObject subMenu;
    [SerializeField] Rigidbody2D pelota;

    bool isPaused = false;

    Vector2 pelotaVelocidadGuardada;
    float pelotaAngularVelocidadGuardada;

    void Start()
    {
        if (juego != null)
        {
            juego.SetActive(true);
        }

        if (subMenu != null)
        {
            subMenu.SetActive(false);
        }

        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                ReturnGame();
            else
                GameMenu();
        }
    }

    public void StartPVP()
    {
        PlayerPrefs.SetInt("botPlaying", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Juego");
    }

    public void StartPVE()
    {
        PlayerPrefs.SetInt("botPlaying", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Juego");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void GameMenu()
    {
        if (pelota != null)
        {
            pelotaVelocidadGuardada = pelota.linearVelocity;
            pelotaAngularVelocidadGuardada = pelota.angularVelocity;
        }

        Time.timeScale = 0f;
        isPaused = true;

        if (juego != null)
        {
            juego.SetActive(false);
        }

        if (subMenu != null)
        {
            subMenu.SetActive(true);
        }
    }

    public void ReturnGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (juego != null)
        {
            juego.SetActive(true);
        }

        if (subMenu != null)
        {
            subMenu.SetActive(false);
        }

        if (pelota != null)
        {
            pelota.linearVelocity = pelotaVelocidadGuardada;
            pelota.angularVelocity = pelotaAngularVelocidadGuardada;
        }
    }
}