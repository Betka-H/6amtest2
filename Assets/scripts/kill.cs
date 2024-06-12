using UnityEngine;

public class kill : MonoBehaviour
{
	death deathScreen;
	public string deathMessage;

	void Start()
	{
		deathScreen = FindObjectOfType<death>(true); // true includes inactive
	}

	public void die(float delay)
	{
		deathScreen.die(deathMessage, delay);
	}
}

//  alternate ver (not working)
/* 
using UnityEngine;
using System.Collections;
using TMPro;

public class kill : MonoBehaviour
{
	public GameObject deathScreen;
	// death deathScreen;
	public string deathMessage;

	void Start()
	{
		// deathScreen = FindObjectOfType<death>(true); // true includes inactive
	}

	void OnMouseDown()
	{
		if (enabled) // can be disabled when needed - like the snooze button that will only kill after being clicked multiple times
			die(deathMessage);
	}

	//!===================================

	public SpriteRenderer title;
	TextMeshProUGUI messageTxtField;
	GameObject resetButton;
	public SpriteRenderer bg;

	// ! disable other colliders

	public void Awake()
	{
		deathScreen.SetActive(false);
		messageTxtField = deathScreen.GetComponentInChildren<TextMeshProUGUI>();
		resetButton = deathScreen.GetComponentInChildren<reset>().gameObject;
	}

	public void die(string deathMessage)
	{
		variables.timesDied++;

		// make transparent
		messageTxtField.alpha = 0;
		bg.color = new Color(1f, 1f, 1f, 0f);

		messageTxtField.text = deathMessage;
		resetButton.SetActive(false);

		deathScreen.gameObject.SetActive(true);
		StartCoroutine(fadeIn());
	}

	IEnumerator fadeIn()
	{
		for (float i = 0; i <= 1; i += Time.deltaTime) // for (float i = 1; i >= 0; i -= Time.deltaTime) to fade out
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
 */
