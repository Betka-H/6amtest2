using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class painting : MonoBehaviour, IReset
{
	audioManager audioMan;

	public GameObject safe;
	public Transform pivot; // pivot point for the painting

	Vector3 originalPos;
	quaternion originalRot;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();

		originalPos = transform.position;
		originalRot = transform.rotation;

		safe.GetComponent<Collider2D>().enabled = false; // disable the collider for the safe
	}

	bool clicked = false;
	void OnMouseDown()
	{
		if (!clicked)
		{
			clicked = true;
			rotate(-10);
			audioMan.playSfx(audioMan.sfxPainting1);
		}
		else
		{
			audioMan.playSfx(audioMan.sfxPainting2);
			safe.GetComponent<Collider2D>().enabled = true; // enable the collider for the safe
			GetComponent<Collider2D>().enabled = false; // disable the collider for the painting
			StartCoroutine(fall());
		}
	}

	void rotate(float rotation)
	{
		Vector3 axis = new Vector3(0, 0, 1); // define the rotation axis (z in this case)
		transform.RotateAround(pivot.transform.position, axis, rotation); // rotate around the pivot and the axis
	}

	IEnumerator fall()
	{
		for (float i = 0.1f; i < 2; i *= 1.2f)
		{
			yield return new WaitForSeconds(0.01f);
			rotate(-2 - i);
			transform.position = transform.position - new Vector3(0, i, 0);
		}
		gameObject.SetActive(false);
	}

	public void resetState()
	{
		clicked = false;

		transform.position = originalPos;
		transform.rotation = originalRot;

		gameObject.SetActive(true);

		GetComponent<Collider2D>().enabled = true; // enable the collider for the painting

		safe.GetComponent<Collider2D>().enabled = false; // disable the collider for the safe
	}
}
