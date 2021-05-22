using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public Text demoText;
    public static int currentGold;
    public bool textBlink = true;

    void Start()
    {
        StartCoroutine("FlashText");
    }

    public IEnumerator FlashText()
    {
        while (textBlink)
        {
            demoText.enabled = false;
            yield return new WaitForSeconds(.5f);
            demoText.enabled = true;
            yield return new WaitForSeconds(.5f);
        }
    }
}
