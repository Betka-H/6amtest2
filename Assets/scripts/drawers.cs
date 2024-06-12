using UnityEngine;

public class drawers : MonoBehaviour, IReset
{
	audioManager audioMan;
	public bool isLocked;
	public item key;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
	}

	void OnMouseEnter()
	{
		if (isLocked)
			GetComponent<toggleActive>().enabled = false;
		if (isLocked && inventory.items.Contains(key))
			GetComponent<toggleActive>().enabled = true;
		// Debug.Log(inventory.items.Contains(key));
	}

	/* void OnEnable()
	{
		audioMan = FindObjectOfType<audioManager>();
		audioMan.playSfx(audioMan.sfxDrawerClose);
	} */

	void OnDisable()
	{
		audioMan.playSfx(audioMan.sfxDrawerOpen);
	}

	public void resetState()
	{
		if (isLocked)
			GetComponent<toggleActive>().enabled = false;
	}
}
