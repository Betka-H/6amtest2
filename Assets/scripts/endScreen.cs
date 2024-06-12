using System.Collections;
using UnityEngine;

public class endScreen : MonoBehaviour
{
	/* void Start()
	{
		gameObject.SetActive(false);
		gameObject.GetComponentInChildren<reset>(true).gameObject.SetActive(false);
	} */

	public void endThisAll()
	{
		gameObject.SetActive(true);
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

		GetComponentInChildren<reset>(true).gameObject.SetActive(false);
		FindObjectOfType<menuController>().gameObject.SetActive(false);

		Debug.Log(gameObject.name + " is active " + gameObject.activeSelf);
		StartCoroutine("end");
	}

	IEnumerator end()
	{
		yield return new WaitForSeconds(4);
		for (float i = 0; i >= 1; i += Time.deltaTime) // for (float i = 1; i >= 0; i -= Time.deltaTime) to fade out
		{
			Debug.Log(i);
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
			yield return null;
		}
		GetComponentInChildren<reset>(true).gameObject.SetActive(true);
	}
}
