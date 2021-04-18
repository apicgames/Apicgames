using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    //UI con los minijuegos
    public GameObject[] minijuego;
    Animator anim;

    void Start()
    {

        //Escondemos todos los minijuegos
        for (var i = 0; i < minijuego.Length; i++)
        {
            minijuego[i].SetActive(false);
        }

    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Minijuego 1 > Señora mayor
        if (other.gameObject.name == "CP1D")
        {
            minijuego[0].SetActive(true);
        }
        //Minijuego 2 > Fachamilia
        else if (other.gameObject.name == "CP3I")
        {
            minijuego[1].SetActive(true);
        }
        //Minijuego 3 > Destender ropa
        else if (other.gameObject.name == "CP4D")
        {
            minijuego[2].SetActive(true);
        }
    }
}
