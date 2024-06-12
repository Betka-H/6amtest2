using TMPro;
using UnityEngine;

public class stats : MonoBehaviour
{
	gameManager gameMan;

	public TMP_Text deathsText;

	void Start()
	{
		gameMan = FindObjectOfType<gameManager>();
	}

	void OnEnable()
	{
		deathsText.text = $"times died:\n{PlayerPrefs.GetInt("timesDied", 0)}";
	}
}

