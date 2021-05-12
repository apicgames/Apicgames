using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //Pulsamos ESM -> si el juego está en pausa se continua y viceversa
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume() //Continuar es: 
    {
        pauseMenuUI.SetActive(false); //desactivar el menu de pausa
        Time.timeScale = 1f; //hacer correr el tiempo
        GameIsPaused = false; //decir que el juego no está en pausa
        //
    }
    void Pause() //Pausa es:
    {
        pauseMenuUI.SetActive(true); //activar el menu de pausa
        Time.timeScale = 0f; //pausar el tiempo de juego
        GameIsPaused = true; //decir que el juego está en pausa
        //descativar audio del juego o minijjuegos

    }
    public void LoadMenu() //Cargar el menú
    {
        Debug.Log("Loading game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }
    public void QuitGame() //Quitar el juego
    {
        Debug.Log("Quitting game...");
        Application.Quit();

    }
}
