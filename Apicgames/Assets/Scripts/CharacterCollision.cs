using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    //UI con los minijuegos
    public GameObject[] minijuego;

    //Variable para la animación
    public Animator animator;

    //Variable de posición actual
    float characterPosActual;
    //Variable de posición al final
    float characterPosFinal;

    void Start()
    {
        characterPosActual = transform.position.x;
        characterPosFinal = transform.position.x;
        //Escondemos todos los minijuegos
        for (var i = 0; i < minijuego.Length; i++)
        {
            minijuego[i].SetActive(false);
        }

        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("isWalkingRight", false);

    }

    void Update()
    {
        //Actualizamos la variable de posición actual
        characterPosActual = transform.position.x;

        //Si el valor inicial es el mismo que el actual > idle (ambos valores son flase)
        if (characterPosActual == characterPosFinal)
        {
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", false);
        }
        //Si el valor inicial es mayor que el actual > andar izquierda (movimiento en x en negativo)
        else if (characterPosActual < characterPosFinal)
        {
            animator.SetBool("isWalkingLeft", true);
            animator.SetBool("isWalkingRight", false);
        }
        //Si el valor inicial es menor que el actual > andar derecha (movimiento en x en positivo)
        else if (characterPosActual > characterPosFinal)
        {
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", true);
        }

        //Actualizamos la variable de posición al final
        characterPosFinal = transform.position.x;
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
