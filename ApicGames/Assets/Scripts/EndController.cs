using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public Button button1;

    private void Start()
    {
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(StartAgain);
    }

    void StartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
