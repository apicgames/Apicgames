using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 90; //iniciamos el timer en 90
    public Text timerText; //este es el hueco para meter el texto del tiempo
    public Text dayText; //este es el hueco para meter el texto del dia

    public SpriteRenderer background;
    float opacity = 1f;

    void Update()
    {
        background.color = new Color(1f, 1f, 1f, opacity);

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
            if (timeValue < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            /*if (timeValue < 20)
            {
               background_0.GetComponent<SpriteRenderer>().color = new Color32(0,0,0,100);

            }
            for
            
         */
        }


        //Para el fondo
        if (timeValue < 90 && timeValue > 85)
        {
            opacity = opacity - 0.005f;
        } else if (timeValue == 86)
        {
            opacity = 0f;
        }

        else if (timeValue < 65 && timeValue > 59)
        {
            opacity = opacity + 0.005f;
        }
        else if (timeValue == 59)
        {
            opacity = 1f;
        } else if (timeValue < 60 && timeValue > 55)
        {
            opacity = opacity - 0.005f;
        }
        else if (timeValue == 55)
        {
            opacity = 0f;
        }

        else if (timeValue < 35 && timeValue > 29)
        {
            opacity = opacity + 0.005f;
        }
        else if (timeValue == 29)
        {
            opacity = 1f;
        }
        else if (timeValue < 30 && timeValue > 25)
        {
            opacity = opacity - 0.005f;
        }
        else if (timeValue == 25)
        {
            opacity = 0f;
        }

        else if (timeValue < 5 && timeValue > 1)
        {
            opacity = opacity + 0.005f;
        }
        else if (timeValue == 1)
        {
            opacity = 1f;
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
