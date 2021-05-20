using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;


    private void Start()
    {
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(Block1);

        Button btn2 = button2.GetComponent<Button>();
        btn2.onClick.AddListener(Block2);

        Button btn3 = button3.GetComponent<Button>();
        btn3.onClick.AddListener(Block3);

        Button btn4 = button4.GetComponent<Button>();
        btn4.onClick.AddListener(Block4);

        block1.SetActive(true);
        block2.SetActive(false);
        block3.SetActive(false);
        block4.SetActive(false);
    }

    void Block1()
    {
        block1.SetActive(false);
        block2.SetActive(true);
        block3.SetActive(false);
        block4.SetActive(false);
    }

    void Block2()
    {
        block1.SetActive(false);
        block2.SetActive(false);
        block3.SetActive(true);
        block4.SetActive(false);
    }

    void Block3()
    {
        block1.SetActive(false);
        block2.SetActive(false);
        block3.SetActive(false);
        block4.SetActive(true);
    }

    void Block4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
