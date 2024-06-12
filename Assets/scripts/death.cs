using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class death : MonoBehaviour, IReset
{
	public SpriteRenderer title;
	TextMeshProUGUI messageTxtField;
	GameObject resetButton;
	public SpriteRenderer bg;
	gameManager gameMan;

	public void Awake()
	{
		gameMan = FindObjectOfType<gameManager>();

		messageTxtField = GetComponentInChildren<TextMeshProUGUI>();
		resetButton = GetComponentInChildren<reset>().gameObject;
	}

	public void die(string deathMessage, float delay)
	{
		disableCols();
		messageTxtField.text = deathMessage;
		Invoke("dieRest", delay);
	}

	void dieRest()
	{
		gameMan.saveInt("timesDied", PlayerPrefs.GetInt("timesDied") + 1);

		// make transparent
		messageTxtField.alpha = 0;
		bg.color = new Color(1f, 1f, 1f, 0f);

		resetButton.SetActive(false);

		gameObject.SetActive(true);
		StartCoroutine(fadeIn());
	}

	List<Collider2D> activeObjs = new List<Collider2D>();
	void disableCols()
	{
		activeObjs = new List<Collider2D>();
		FindObjectOfType<menuController>(true).gameObject.SetActive(false);
		foreach (Collider2D col in FindObjectsOfType<Collider2D>())
		{
			if (col.isActiveAndEnabled)
			{
				//? Debug.LogError("disabling colliders for " + col.name);
				col.enabled = false;
				activeObjs.Add(col);
			}
		}
	}

	public void resetState()
	{
		foreach (Collider2D col in activeObjs)
		{
			//? Debug.LogWarning("enabling colliders for " + col.name);
			col.enabled = true;
		}
		FindObjectOfType<menuController>(true).gameObject.SetActive(true);
	}

	IEnumerator fadeIn()
	{
		for (float i = 0; i >= 1; i += Time.deltaTime) // for (float i = 1; i >= 0; i -= Time.deltaTime) to fade out
		{
			title.color = new Color(1, 1, 1, i);
			yield return null;
		}
		// after the title fades in completely
		StartCoroutine(fadeInRest());
	}

	IEnumerator fadeInRest()
	{
		for (float i = 0; i <= 1; i += Time.deltaTime / 2f) // for (float i = 1; i >= 0; i -= Time.deltaTime) to fade out
		{
			messageTxtField.alpha = i;
			bg.color = new Color(0f, 0f, 0f, i);
			yield return null;
		}
		// lastly, enable the reset button
		resetButton.gameObject.SetActive(true);
	}
}
