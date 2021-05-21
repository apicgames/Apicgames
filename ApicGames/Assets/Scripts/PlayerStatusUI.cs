using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [Range(0,5)]
    [SerializeField] private float barSpeed = 1f;
    [SerializeField] private Image barraFelicidad;

    private float maxFelicidad;

    private void Awake()
    {
        barraFelicidad.fillAmount = 0f;

        maxFelicidad = barraFelicidad.fillAmount;
    }

    private void Update()
    {
        if (barraFelicidad.fillAmount != maxFelicidad)
        {
            barraFelicidad.fillAmount = Mathf.MoveTowards(barraFelicidad.fillAmount, maxFelicidad, Time.deltaTime * barSpeed);
        }
    }

    public void SetHealth(float healthPercentage)
    {
        maxFelicidad = maxFelicidad + 0.1f;
    }

}
