using UnityEngine;

public class keySounds : MonoBehaviour
{
	// [Tooltip("true=key, false=drawer")]
	// public bool define;
	audioManager audioMan;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
	}
	void OnMouseDown()
	{
		if (GetComponent<drawers>() != null && GetComponent<drawers>().isLocked == true)
		{
			audioMan.playSfx(audioMan.sfxKeyUse);
		}
		else
		{
			audioMan.playSfx(audioMan.sfxKeyPickup);
		}
	}
}
