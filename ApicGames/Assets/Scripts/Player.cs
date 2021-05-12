using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStatusUI playerStatusUI;

    public int MaxFelicidad { get; private set; }
    public int FelicicdadActual { get; private set; }
    public float FelicidadRango { get { return (float)FelicicdadActual / (float)MaxFelicidad; } }

    private void Start()
    {
        MaxFelicidad = 100;
    }

    private void Update() //esto es una prueba para ver si funciona
    {

        /*if completamos un minijuego{
         * MakeHappy(10);
         * Debug.Log(FelicidadRango);
         *}
         */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakeHappy(10);
            Debug.Log(FelicidadRango);
        }
    }

    void MakeHappy(int felicidad)
    {
        FelicicdadActual += felicidad;
        FelicicdadActual = Mathf.Clamp(FelicicdadActual, 0, MaxFelicidad);
        playerStatusUI.SetHealth(FelicidadRango);
    }
}