using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class cutsceneManager : MonoBehaviour, IReset
{
	public Animator sleepAnimator;
	public clockRing clockRing;
	public clockRing clockRingCutscene;
	SpriteRenderer introScreen;
	menuController hamburger;

	void Start()
	{
		sleepAnimator.Play("sleep");

		hamburger = FindObjectOfType<menuController>();
		hamburger.gameObject.SetActive(false);

		introScreen = GetComponentInChildren<SpriteRenderer>();

		clockRingCutscene.ring(true);
		disableCols();
	}

	bool isAwake;
	void Update()
	{
		if (Input.anyKeyDown && !isAwake)
		{
			isAwake = true;
			StartCoroutine(fadeIntroScreenOut());

			Invoke("ringAlarm", 1.5f);
			Invoke("enableCols", 7);

			// enabled = false; // stop running the update check
			// sleepAnimator.SetTrigger("playIntro");
			//!mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
			// Debug.LogWarning("cutscene skip: testing only");
			enableCols();
		}
		sleepAnimator.SetBool("isAwake", isAwake);
	}

	/* public void sleep()
	{
		Debug.Log("sleep motherfucker");
		sleepAnimator.Play("sleep some more");
		clockRing.ring(false);
		Invoke("ringAlarm", 1.5f);
	} */

	void ringAlarm()
	{
		// clockRing.onOff = true;
		// Debug.Log("ring motherfucker");
		clockRing.ring(true);
	}

	IEnumerator fadeIntroScreenOut()
	{
		for (float i = 1; i >= 0; i -= Time.deltaTime * 2 * i)
		{
			if (i < 0.001f)
				break;
			introScreen.color = new Color(0f, 0f, 0f, i);
			yield return null;
		}
	}

	// bool safeRevealed;
	List<Collider2D> activeObjs;
	void disableCols()
	{
		hamburger.gameObject.SetActive(false); // disable the menu

		activeObjs = new List<Collider2D>(); // make an empty list
		foreach (Collider2D col in FindObjectsOfType<Collider2D>()) // finds all colliders in the scene
		{
			if (col.isActiveAndEnabled) // only for colliders that are... active and enabled...
			{
				//? Debug.LogError("disabling colliders for " + col.name);
				col.enabled = false;
				activeObjs.Add(col); // note it down to enable it correctly later
									 // if (col.name == "safe")
									 // col.gameObject.SetActive(safeRevealed);
			}
		}
	}
	void enableCols()
	{
		if (activeObjs != null)
			foreach (Collider2D col in activeObjs)
			{
				//? Debug.LogWarning("enabling colliders for " + col.name);
				col.enabled = true;
				// if (col.name == "painting")
				// safeRevealed = col.GetComponent<painting>().safe.activeSelf;
			}
		hamburger.gameObject.SetActive(true); // enable the menu
	}

	public void resetState()
	{
		// safeRevealed = false;
		// Debug.LogWarning("??????????????");
		// clockRing.ring(false);
		// isAwake = false;
		disableCols();
		sleepAnimator.Play("wake up");
		Invoke("enableCols", 3.5f);
	}
}
