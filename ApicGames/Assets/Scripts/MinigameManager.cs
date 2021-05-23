using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    /*-------- GENERAL --------*/
    float timeAlerts = 12.0f;
    public Button[] alertButton;

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

        light_active[0] = false;
        lights[0].GetComponent<Image>().sprite = btn_down[0];
    }

    /*-------- PUZZLE --------*/
    public Image[] piece;
    public GameObject alertPuzzle;
    public GameObject mgPuzzle;

    float timeAlertPuzzle;

    public Button[] pieceButton;
    public Button[] pieceEmpty;

    //Genera 4 valores random distintos entre ellos
    int randomPiece1;
    int randomPiece2;
    int randomPiece3;
    int randomPiece4;

    void GetRandom(int min, int max)
    {
        randomPiece1 = Random.Range(min, max);

        randomPiece2 = Random.Range(min, max);
        while (randomPiece2 == randomPiece1)
        {
            randomPiece2 = Random.Range(min, max);
        }

        randomPiece3 = Random.Range(min, max);
        while (randomPiece3 == randomPiece1 || randomPiece3 == randomPiece2)
        {
            randomPiece3 = Random.Range(min, max);
        }

        randomPiece4 = Random.Range(min, max);
        while (randomPiece4 == randomPiece1 || randomPiece4 == randomPiece2 || randomPiece4 == randomPiece3)
        {
            randomPiece4 = Random.Range(min, max);
        }

        piece[randomPiece1].enabled = false;
        piece[randomPiece2].enabled = false;
        piece[randomPiece3].enabled = false;
        piece[randomPiece4].enabled = false;

        pieceEmpty[0].transform.localPosition = piece[randomPiece1].transform.localPosition;
        pieceEmpty[1].transform.localPosition = piece[randomPiece2].transform.localPosition;
        pieceEmpty[2].transform.localPosition = piece[randomPiece3].transform.localPosition;
        pieceEmpty[3].transform.localPosition = piece[randomPiece4].transform.localPosition;

        pieceButton[0].GetComponent<Image>().sprite = piece[randomPiece1].sprite;
        pieceButton[0].GetComponent<Image>().SetNativeSize();
        pieceButton[1].GetComponent<Image>().sprite = piece[randomPiece2].sprite;
        pieceButton[1].GetComponent<Image>().SetNativeSize();
        pieceButton[2].GetComponent<Image>().sprite = piece[randomPiece3].sprite;
        pieceButton[2].GetComponent<Image>().SetNativeSize();
        pieceButton[3].GetComponent<Image>().sprite = piece[randomPiece4].sprite;
        pieceButton[3].GetComponent<Image>().SetNativeSize();
    }

    int whichPiece;

    void puzzlePieceBgn(int valuePieceInitial)
    {
        whichPiece = valuePieceInitial;
        if (whichPiece == 0)
        {
            pieceButton[0].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            pieceButton[1].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[2].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[3].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
        }
        if (whichPiece == 1)
        {
            pieceButton[0].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[1].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            pieceButton[2].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[3].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
        }
        if (whichPiece == 2)
        {
            pieceButton[0].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[1].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[2].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            pieceButton[3].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
        }
        if (whichPiece == 3)
        {
            pieceButton[0].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[1].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[2].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
            pieceButton[3].GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
    }

    void puzzlePieceEnd(int valuePieceFinal)
    {
        if (valuePieceFinal == whichPiece)
        {
            pieceButton[valuePieceFinal].gameObject.SetActive(false);
            pieceButton[valuePieceFinal].interactable = false;
            pieceEmpty[valuePieceFinal].gameObject.SetActive(false);
            pieceEmpty[valuePieceFinal].interactable = false;

            pieceButton[0].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            pieceButton[1].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            pieceButton[2].GetComponent<Image>().color = new Color(255, 255, 255, 1);
            pieceButton[3].GetComponent<Image>().color = new Color(255, 255, 255, 1);

            if (whichPiece == 0)
            {
                piece[randomPiece1].enabled = true;
            } else if (whichPiece == 1)
            {
                piece[randomPiece2].enabled = true;
            }
            else if (whichPiece == 2)
            {
                piece[randomPiece3].enabled = true;
            }
            else if (whichPiece == 3)
            {
                piece[randomPiece4].enabled = true;
            }
        }
    }

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
            cloth[closureIndex].GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-212f, 212f), -142f);
        }

        /*-------- LIGHTS --------*/
        for (int i = 0; i < lights.Length; i++)
        {
            int closureIndex = i;
            lights[closureIndex].onClick.AddListener(() => changeLight(closureIndex));

            RandomLights();
        }

        /*-------- PUZZLE --------*/
        for (int i = 0; i < pieceButton.Length; i++)
        {
            int closureIndex = i;
            pieceButton[closureIndex].onClick.AddListener(() => puzzlePieceBgn(closureIndex));
            pieceEmpty[closureIndex].onClick.AddListener(() => puzzlePieceEnd(closureIndex));
        }
        GetRandom(0, piece.Length);

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
            alertButton[2].gameObject.SetActive(false);
            alertButton[2].interactable = false;

            MakeHappy(5);

            //Los reiniciamos todos
            for (var i = 0; i < cloth.Length; i++)
            {
                cloth[i].gameObject.SetActive(true);

                //RANDOM CLOTHES
                cloth[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-212f, 212f), -142f);
            }

            clothCounter = 0; //Lo igualamos a 0 para que no entre en el bucle más veces

            timeAlertClothes = timeAlerts;
        }

        //TIMER
        timeAlertClothes -= Time.deltaTime;
        if (timeAlertClothes < 0)
        {
            alertCloth.SetActive(true);
            alertButton[2].gameObject.SetActive(true);
            alertButton[2].interactable = true;
        }

        /*-------- LIGHTS --------*/
        //Si se clickan todas las luces, se cierra la interfaz, se elimina el alert y se aumenta la barra
        if (light_active[0] == true && light_active[1] == true && light_active[2] == true && light_active[3] == true && light_active[4] == true && light_active[5] == true)
        {
            alertLights.SetActive(false);
            mgLights.SetActive(false);
            alertButton[1].gameObject.SetActive(false);
            alertButton[1].interactable = false;

            MakeHappy(5);

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
            alertButton[1].gameObject.SetActive(true);
            alertButton[1].interactable = true;
        }

        /*-------- PUZZLE --------*/
        if (piece[randomPiece1].enabled == true && piece[randomPiece2].enabled == true && piece[randomPiece3].enabled == true && piece[randomPiece4].enabled == true)
        {
            alertPuzzle.SetActive(false);
            mgPuzzle.SetActive(false);
            alertButton[0].gameObject.SetActive(false);
            alertButton[0].interactable = false;

            MakeHappy(5);

            //Los reiniciamos todos
            for (var i = 0; i < pieceButton.Length; i++)
            {
                pieceButton[i].gameObject.SetActive(true);
                pieceButton[i].interactable = true;
                pieceEmpty[i].gameObject.SetActive(true);
                pieceEmpty[i].interactable = true;
            }

            GetRandom(0, piece.Length);
            timeAlertPuzzle = timeAlerts;
        }

        //TIMER
        timeAlertPuzzle -= Time.deltaTime;
        if (timeAlertPuzzle < 0)
        {
            alertPuzzle.SetActive(true);
            alertButton[0].gameObject.SetActive(true);
            alertButton[0].interactable = true;
        }
    }


}
