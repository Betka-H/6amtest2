using UnityEngine;

public class item : MonoBehaviour, IReset
{
	audioManager audioMan;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
	}

	void OnMouseDown()
	{
		audioMan.playSfx(audioMan.sfxItemPickUp);
		inventory.addItem(GetComponent<item>());
		gameObject.SetActive(false);
	}

	public void resetState()
	{
		gameObject.SetActive(true);
		inventory.removeItem(GetComponent<item>());
	}
}