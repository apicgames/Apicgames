using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    /*-------- GENERAL --------*/
    float timeAlerts = 15.0f;

    /*-------- CLOTHES --------*/
    public Button[] cloth;
    int clothCounter = 0;
    public GameObject alertCloth;
    public GameObject mgCloth;

    public void destroyCloth(int buttonIndex)
    {
        cloth[buttonIndex].gameObject.SetActive(false);
        clothCounter = clothCounter + 1;
    }

    float timeAlertClothes;

    /*-------- LIGHTS --------*/
    public Button[] lights;
    public GameObject alertLights;
    public GameObject mgLights;

    float timeAlertLights;

    //Activo
    public bool[] light_active;

    //Imágenes up down
    public Sprite[] btn_up;
    public Sprite[] btn_down;

    public void changeLight(int buttonIndex)
    { 
        if (light_active[buttonIndex] == true)
        {
            lights[buttonIndex].GetComponent<Image>().sprite = btn_down[buttonIndex];
            light_active[buttonIndex] = false;
        }else if (light_active[buttonIndex] == false)
        {
            lights[buttonIndex].GetComponent<Image>().sprite = btn_up[buttonIndex];
            light_active[buttonIndex] = true;
        }
    }

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

    void Start()
    {
        /*-------- CLOTHES --------*/
        for (int i = 0; i < cloth.Length; i++)
        {
            int closureIndex = i; 
            cloth[closureIndex].onClick.AddListener(() => destroyCloth(closureIndex));

            //RANDOM CLOTHES
            cloth[closureIndex].transform.localPosition = new Vector3(Random.Range(-266f, 267f), -238f, 0.0f);
        }

        /*-------- LIGHTS --------*/
        for (int i = 0; i < lights.Length; i++)
        {
            int closureIndex = i;
            lights[closureIndex].onClick.AddListener(() => changeLight(closureIndex));

            RandomLights();
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
            alertCloth.SetActive(false);

            MakeHappy(10);

            //Los reiniciamos todos
            for (var i = 0; i < cloth.Length; i++)
            {
                cloth[i].gameObject.SetActive(true);

                //RANDOM CLOTHES
                cloth[i].transform.localPosition = new Vector3(Random.Range(-266f, 267f), 70f, 0.0f);
            }

            clothCounter = 0; //Lo igualamos a 0 para que no entre en el bucle más veces

            timeAlertClothes = timeAlerts;
        }

        //TIMER
        timeAlertClothes -= Time.deltaTime;
        if (timeAlertClothes < 0)
        {
            alertCloth.SetActive(true);
        }

        /*-------- LIGHTS --------*/
        //Si se clickan todas las luces, se cierra la interfaz, se elimina el alert y se aumenta la barra
        if (light_active[0] == true && light_active[1] == true && light_active[2] == true && light_active[3] == true && light_active[4] == true && light_active[5] == true)
        {
            alertLights.SetActive(false);
            mgLights.SetActive(false);

            MakeHappy(10);

            //Los reiniciamos todos
            for (var i = 0; i < light_active.Length; i++)
            {
                light_active[i] = false;
            }

            timeAlertLights = timeAlerts;
            RandomLights();
        }

        //TIMER
        timeAlertLights -= Time.deltaTime;
        if (timeAlertLights < 0)
        {
            alertLights.SetActive(true);
        }
    }

    void RandomLights()
    {
        for (var i = 0; i < light_active.Length; i++)
        {
            //RANDOM LIGHTS
            bool active_random = (Random.value > 0.5f);
            light_active[i] = active_random;
            if (active_random == true)
            {
                lights[i].GetComponent<Image>().sprite = btn_up[i];
            }
            else
            {
                lights[i].GetComponent<Image>().sprite = btn_down[i];
            }
        }
    }


}
