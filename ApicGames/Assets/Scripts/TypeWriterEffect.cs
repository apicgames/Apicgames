using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
	public Button close;
	public float delay = 0.03f;
	public string fullText;
	private string currentText = "";

	public Text finalText;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ShowText());

		close.onClick.AddListener(() => completeText());
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i < fullText.Length; i++)
		{
			currentText = fullText.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
		print(fullText.Substring(0, fullText.Length));
	}

    void completeText()
	{
		finalText.text = fullText.Substring(0, fullText.Length);
	}
}
