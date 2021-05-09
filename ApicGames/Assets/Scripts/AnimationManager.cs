using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    //Variable para la animación
    public Animator characterAnimator;

    //Variable de posición actual
    float posActual;
    //A donde se mueve el personaje
    Vector2 mov;

    //Velocidad de movimiento
    private float speed = 0.8f;

    //Timer que se reinicia para que el personaje pare cierto tiemp
    private float timer = 0.0f;
    private float waitTime = 1.0f;

    //Posiciones entre las que se puede mover
    public float posX1;
    public float posX2;

// Start is called before the first frame update
void Start()
    {
        posActual = transform.position.x;
        characterAnimator.SetBool("WalkingLeft", true);
        characterAnimator.SetBool("WalkingRight", false);
        mov = new Vector2(posX2, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizamos la variable de posición actual
        posActual = transform.position.x;

        transform.position = Vector2.MoveTowards(transform.position, mov, speed * Time.deltaTime);

        if (mov == new Vector2(transform.position.x, transform.position.y))
        {
            //Ponemos al personaje en posición idle
            characterAnimator.SetBool("WalkingLeft", false);
            characterAnimator.SetBool("WalkingRight", false);

            //El personaje parará unos segundos y seguirá
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                mov = new Vector2(Random.Range(posX1, posX2), transform.position.y);
                if (posActual > mov.x)
                {
                    characterAnimator.SetBool("WalkingLeft", true);
                    characterAnimator.SetBool("WalkingRight", false);
                }
                //Si el valor inicial es menor que el actual > andar derecha (movimiento en x en positivo)
                if (posActual < mov.x)
                {
                    characterAnimator.SetBool("WalkingLeft", false);
                    characterAnimator.SetBool("WalkingRight", true);
                }
                timer = 0.0f;
                waitTime = Random.Range(0.8f, 2.0f);
            }
        }
        //Si el valor inicial es mayor que el actual > andar izquierda (movimiento en x en negativo)
        if (posActual > mov.x)
        {
            characterAnimator.SetBool("WalkingLeft", true);
            characterAnimator.SetBool("WalkingRight", false);
        }
        //Si el valor inicial es menor que el actual > andar derecha (movimiento en x en positivo)
        if (posActual < mov.x)
        {
            characterAnimator.SetBool("WalkingLeft", false);
            characterAnimator.SetBool("WalkingRight", true);
        }

    }
}
