using UnityEngine;
using System.Collections;

public class safeWheel : MonoBehaviour, IReset
{
	safeDigitManager digitMan;
	audioManager audioMan;
	toggleActive togglerScript;
	safeLed led;

	Quaternion originalRotation;


	void Start()
	{
		// Debug.LogWarning("safe is unlocked: testing only");

		digitMan = FindObjectOfType<safeDigitManager>();
		audioMan = FindObjectOfType<audioManager>();

		togglerScript = GetComponent<toggleActive>();
		togglerScript.enabled = false;

		led = FindObjectOfType<safeLed>();

		originalRotation = transform.rotation;
	}

	void OnMouseDown()
	{
		// m!mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
		// togglerScript.run();

		if (digitMan.checkState())
		{
			StartCoroutine(turnLocked());
			if (audioMan.sfxSource.isPlaying)
				audioMan.playSfx(audioMan.sfxBuzzerWrong);
		}
		else
		{
			StartCoroutine(turnOpen());
			audioMan.playSfx(audioMan.sfxBuzzerRight);
		}
	}

	IEnumerator turnLocked()
	{
		led.red();
		GetComponent<Collider2D>().enabled = false;
		for (float i = 0.1f; i < 3; i *= 1.75f)
		{
			yield return new WaitForSeconds(0.01f);
			rotate(-i);
		}
		for (float i = 0.1f; i < 3; i *= 1.75f)
		{
			yield return new WaitForSeconds(0.01f);
			rotate(-i * -1);
		}
		GetComponent<Collider2D>().enabled = true;
	}

	IEnumerator turnOpen()
	{
		GetComponent<Collider2D>().enabled = false;
		for (float i = 0.1f; i < 10; i *= 1.5f)
		{
			yield return new WaitForSeconds(0.01f);
			rotate(-i);
		}
		led.green();
		for (float i = 10; i > 0.1f; i /= 1.2f)
		{
			yield return new WaitForSeconds(0.01f);
			rotate(-i);
		}
		yield return new WaitForSeconds(0.5f);
		audioMan.playSfx(audioMan.sfxSafeCreakOpen);
		togglerScript.run();
		resetRotation();
	}

	void rotate(float rotation)
	{
		Vector3 axis = new Vector3(0, 0, 1); // define the rotation axis (z in this case)
		transform.Rotate(axis, rotation); // rotate around the pivot and the axis
	}

	void resetRotation()
	{
		transform.rotation = originalRotation;
		GetComponent<Collider2D>().enabled = true;
	}

	public void resetState()
	{
		resetRotation();
	}
}
