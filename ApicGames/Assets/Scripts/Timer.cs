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
    float animationDaySpeed = 0.005f;

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
  
        }


        //Para el fondo
        if (timeValue < 90 && timeValue > 85 && opacity > animationDaySpeed)
        {
            opacity = opacity - animationDaySpeed;
        } else if (timeValue == 86)
        {
            opacity = 0f;
        }

        else if (timeValue < 65 && timeValue > 59 && opacity < 1f - animationDaySpeed)
        {
            opacity = opacity + animationDaySpeed;
        }
        else if (timeValue == 59)
        {
            opacity = 1f;
        } else if (timeValue < 60 && timeValue > 55 && opacity > animationDaySpeed)
        {
            opacity = opacity - animationDaySpeed;
        }
        else if (timeValue == 55)
        {
            opacity = 0f;
        }

        else if (timeValue < 35 && timeValue > 29 && opacity < 1f - animationDaySpeed)
        {
            opacity = opacity + animationDaySpeed;
        }
        else if (timeValue == 29)
        {
            opacity = 1f;
        }
        else if (timeValue < 30 && timeValue > 25 && opacity > animationDaySpeed)
        {
            opacity = opacity - animationDaySpeed;
        }
        else if (timeValue == 25)
        {
            opacity = 0f;
        }

        else if (timeValue < 5 && timeValue > 1 && opacity < 1f - animationDaySpeed)
        {
            opacity = opacity + animationDaySpeed;
        }
        else if (timeValue == 1)
        {
            opacity = 1f;
        }
    }

        
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
