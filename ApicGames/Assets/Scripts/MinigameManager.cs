using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    /*-------- GENERAL --------*/
    int minigTotal = 3;

    /*-------- CLOTHES --------*/
    public Button[] cloth;
    int clothCounter = 0;
    public GameObject alertCloth;
    public GameObject mgCloth;

    /*-------- BARRA --------*/
    public PlayerStatusUI playerStatusUI;

    public int MaxFelicidad { get; private set; }
    public int FelicicdadActual { get; private set; }
    public float FelicidadRango { get { return (float)FelicicdadActual / (float)MaxFelicidad; } }

    void MakeHappy(int felicidad)
    {
        FelicicdadActual += felicidad;
        FelicicdadActual = Mathf.Clamp(FelicicdadActual, 0, MaxFelicidad);
        playerStatusUI.SetHealth(FelicidadRango);
    }

    public void destroyCloth(int buttonIndex)
    {
        Destroy(cloth[buttonIndex].gameObject);
        clothCounter = clothCounter + 1;
    }

    void Start()
    {
        /*-------- CLOTHES --------*/
        for (int i = 0; i < cloth.Length; i++)
        {
            int closureIndex = i; 
            cloth[closureIndex].onClick.AddListener(() => destroyCloth(closureIndex));
        }

        /*-------- BARRA --------*/
        MaxFelicidad = 100;
    }

    void Update()
    {
        /*-------- CLOTHES --------*/
        //Si se clickan todas las prendas, se cierra la interfaz, se elimina el alert y se aumenta la barra
        if (clothCounter == cloth.Length)
        {
            mgCloth.SetActive(false);
            Destroy(alertCloth.gameObject);

            MakeHappy(10);

            clothCounter = 0; //Lo igualamos a 0 para que no entre en el bucle más veces
        }
    }
}
