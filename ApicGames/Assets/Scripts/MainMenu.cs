using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() //He creado esta función para asignarsela al botón "Empezar" cuando se pulsa.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Lo que hace es cargar la siguiente escena a esta, y esa escena es el juego como tal. Se puede ver el orden de las escenas en "Unity->File->Build Settings".
        //SceneManager.LoadScene("Main_scene");

    }
    public void QuitGame()//Esta funcioón se encarga de quitar el juego cuando se pulsa
    {
        Debug.Log("Quitting..."); //Para yo comprobar que se quita cuando le doy he creado este mensaje para la consola
        Application.Quit(); //y esto es lo que hace que se quite
    }
}
