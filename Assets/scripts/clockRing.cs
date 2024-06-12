using UnityEngine;

public class clockRing : MonoBehaviour, IReset
{
	audioManager audioMan;
	public GameObject lines;
	public bool alwaysActive;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
		lines.SetActive(alwaysActive);
		// OnEnable();
	}

	public void ring(bool onOff)
	{
		if (onOff)
		{
			lines.SetActive(true);
			// Debug.Log("lines where bozo");
			// Debug.Log(lines.activeSelf);
			if (!alwaysActive)
				audioMan.playAlarm();
		}
		else
		{
			lines.SetActive(false);
		}
	}

	void Update()
	{
		if (isActiveAndEnabled)
			if (audioMan != null)
				audioMan.alarmVolumeHigh();
	}

	/* void OnEnable()
	{
		// Debug.Log("enable");
		if (audioMan != null)
			audioMan.alarmVolumeHigh();
	}
	*/

	void OnDisable()
	{
		// Debug.Log("disable");
		if (audioMan != null)
			audioMan.alarmVolumeLow();
	}

	public void resetState()
	{
		// OnEnable();
	}
}
