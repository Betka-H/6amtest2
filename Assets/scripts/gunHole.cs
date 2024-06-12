using System.Collections;
using UnityEngine;

public class gunHole : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(beGone());
	}

	IEnumerator beGone()
	{
		yield return new WaitForSeconds(15);
		Destroy(gameObject);
	}

	void OnDisable()
	{
		Destroy(gameObject);
	}
}
