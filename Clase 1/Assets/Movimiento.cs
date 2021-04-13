using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed; // publico, esto se puede modificar
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0.0f, 0.0f)); //movimiento derecha izquierdamultiplicado por la velocidad
        
    }
}
