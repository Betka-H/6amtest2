using TMPro;
using UnityEngine;

public class announcer : MonoBehaviour
{
	public TMP_Text textField;

	void Start()
	{
		// Debug.LogWarning("announcer is disabled");
		hide();
	}

	public void show()
	{
		//! gameObject.SetActive(true);
	}
	public void hide()
	{
		gameObject.SetActive(false);
	}

	public void setMsg(string message)
	{
		gameObject.GetComponentInChildren<TMP_Text>().text = message;
	}
}
