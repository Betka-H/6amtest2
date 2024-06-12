using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class screw : MonoBehaviour, IReset
{
	screwManager manager;
	audioManager audioManager;

	Vector3 originalPos;
	quaternion originalRot;

	void Start()
	{
		manager = GetComponentInParent<screwManager>();
		audioManager = FindObjectOfType<audioManager>();
		originalPos = transform.position;
		originalRot = transform.rotation;
		setRandomClicks();
	}

	int clicksRandom;
	int clicks = 0;
	void OnMouseDown()
	{
		if (inventory.items.Contains(manager.screwdriver))
		{
			if (clicks < clicksRandom)
			{
				clicks++;
				manager.rotate(gameObject, -UnityEngine.Random.Range(5, 10));
				audioManager.playRandomSfx(audioManager.sfxScrewTurn);
			}
			else
			{
				manager.screwScrew();
				GetComponent<Collider2D>().enabled = false;
				manager.makeFall(gameObject);
				// audioManager.playRandomSfx(audioManager.sfxScrewFall);
				Invoke("playFall", 0.2f);
			}
		}
		else
		{
			audioManager.playRandomSfx(audioManager.sfxScrewLocked);
		}
	}

	void playFall()
	{
		audioManager.playRandomSfx(audioManager.sfxScrewFall);
	}

	void setRandomClicks()
	{
		clicksRandom = UnityEngine.Random.Range(2, 5);
	}

	public void resetState()
	{
		transform.position = originalPos;
		transform.rotation = originalRot;
		gameObject.SetActive(true);
		GetComponent<Collider2D>().enabled = true;

		clicks = 0;
		setRandomClicks();
	}
}
