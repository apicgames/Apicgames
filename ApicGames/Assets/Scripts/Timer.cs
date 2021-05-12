using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 90; //iniciamos el timer en 90
    public Text timerText; //este es el hueco para meter el texto del tiempo
    public Text dayText; //este es el hueco para meter el texto del dia

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 90;
        }
        DisplayTime(timeValue);

        if (timeValue < 90)
        {
            dayText.text = ("Primer día");

            if (timeValue < 60)
            {
                dayText.text = ("Segundo día");
            }
            if (timeValue < 30)
            {
                dayText.text = ("Último Día");
            }
            /*if (timeValue < 20)
            {
               background_0.GetComponent<SpriteRenderer>().color = new Color32(0,0,0,100);

            }
            for
            
         */
        }
    }

    //si el tiempo es <0 y la barra de felicidad no está completa {viene la poli a reventarte}
    //si el tiempo es <0 y la barra de felicidad está completa {resetar el tiempo y cambiar el dia al siguiente}
        
    void DisplayTime(float timeToDisplay) //y esto es para decirle como displayearlo
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay %60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        

    }
}
