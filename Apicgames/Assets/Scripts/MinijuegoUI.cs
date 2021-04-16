using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MinijuegoUI : MonoBehaviour
{
    public Button closeButton;
    public GameObject UIinterface;

    void Start()
    {
        Button btn = closeButton.GetComponent<Button>();
        btn.onClick.AddListener(closeMinigame);
    }

    void closeMinigame()
    {
        UIinterface.SetActive(false);
    }
}
