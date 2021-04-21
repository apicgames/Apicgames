using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
    //UI con los minijuegos
    public GameObject[] minijuego;

    //Velocidad de movimiento
    private float speed = 4.0f;
    //Se actualizará la posición a la que debe ir el personaje en esta variable. Dividida en 3 pasos:
    private Vector2 posFloorY; //Posición de la planta en Y
    private Vector2 posObjectX; //Punto final en X
    private Vector2 posEnd; //Punto que actualiza al personaje

    //Establecemos la posición del ascensor
    public GameObject gameObjectLift;
    private Vector2 posEndLift;
    private Vector2 posFloorYLift;

    //GameObject del personaje
    public GameObject character;
    private Vector2 character2D;

    //GameObject del punto de interacción
    //public GameObject[] minigamePuntoInteract;
    public GameObject[] minigamePuntoCollision;

    void Start()
    {
        //La pisición inicial a la que se dirige es la propia del elemento (no queremos que se mueva)
        posEnd = character.transform.position;
        //El ascensor se moverá al piso en el que esté el personaje
        posEndLift = new Vector2(gameObjectLift.transform.position.x, character.transform.position.y + 0.2f);
    }

    void Update()
    {
        //Sacamos los valores del personaje como 2D (solo x e y)
        character2D = new Vector2(character.transform.position.x, character.transform.position.y);

        //Actualiza la posición del personaje y del ascensor
        //MoveTowards(posición inicial, posición final, velocidad)
        character.transform.position = Vector2.MoveTowards(character.transform.position, posEnd, speed * Time.deltaTime);
        gameObjectLift.transform.position = Vector2.MoveTowards(gameObjectLift.transform.position, posEndLift, speed * Time.deltaTime);

        if (character2D.x == gameObjectLift.transform.position.x)
        {
            posEnd = posFloorY;
            posEndLift = posFloorYLift;
        }

        if (character2D == posFloorY)
        {
            posEnd = posObjectX;
        }

        //Mantiene al personaje siempre recto
        character.transform.rotation = Quaternion.identity;

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                //Pos ratón en 3D
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //La convertimos a 2D
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                //Si el ratón hace click en algo, se moverá a la posición del objeto
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    //1º Derecha > Minijuego señora mayor
                    if (hit.collider.gameObject.name == "1D")
                    {
                        //Asignamos las variables de movimiento por pasos (ascensor, planta, objeto)
                        posEnd = new Vector2(gameObjectLift.transform.position.x, character.transform.position.y);
                        posFloorY = new Vector2(gameObjectLift.transform.position.x, minigamePuntoCollision[0].transform.position.y);
                        posFloorYLift = new Vector2(gameObjectLift.transform.position.x, minigamePuntoCollision[0].transform.position.y + 0.2f);
                        posObjectX = new Vector2(minigamePuntoCollision[0].transform.position.x, minigamePuntoCollision[0].transform.position.y);

                        if (character2D.x == posObjectX.x && character2D.y == posObjectX.y)
                        {
                            posEnd = posObjectX;
                            minijuego[0].SetActive(true);
                        }
                    }
                    //3º Izquierda > Minijuego fachafamilia
                    else if (hit.collider.gameObject.name == "3I")
                    {
                        //Asignamos las variables de movimiento por pasos (ascensor, planta, objeto)
                        posEnd = new Vector2(gameObjectLift.transform.position.x, character.transform.position.y);
                        posFloorY = new Vector2(gameObjectLift.transform.position.x, minigamePuntoCollision[1].transform.position.y);
                        posFloorYLift = new Vector2(gameObjectLift.transform.position.x, minigamePuntoCollision[1].transform.position.y + 0.2f);
                        posObjectX = new Vector2(minigamePuntoCollision[1].transform.position.x, minigamePuntoCollision[1].transform.position.y);

                        if (character2D.x == posObjectX.x && character2D.y == posObjectX.y)
                        {
                            posEnd = posObjectX;
                            minijuego[1].SetActive(true);
                        }
                    }
                    //4º Derecha > Minijuego ropa tendida
                    else if (hit.collider.gameObject.name == "4D")
                    {
                        //Asignamos las variables de movimiento por pasos (ascensor, planta, objeto)
                        posEnd = new Vector2(gameObjectLift.transform.position.x, character.transform.position.y);
                        posFloorY = new Vector2(gameObjectLift.transform.position.x, minigamePuntoCollision[2].transform.position.y);
                        posFloorYLift = new Vector2(gameObjectLift.transform.position.x, minigamePuntoCollision[2].transform.position.y + 0.2f);
                        posObjectX = new Vector2(minigamePuntoCollision[2].transform.position.x, minigamePuntoCollision[2].transform.position.y);

                        if (character2D.x == posObjectX.x && character2D.y == posObjectX.y)
                        {
                            posEnd = posObjectX;
                            minijuego[2].SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
