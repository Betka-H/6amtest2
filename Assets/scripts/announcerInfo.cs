using UnityEngine;

public class announcerInfo : MonoBehaviour
{
	public string message;
	announcer announcer;

	void Awake()
	{
		announcer = FindObjectOfType<announcer>(true); // true includes inactive
	}

	void OnMouseEnter()
	{
		if (enabled)
		{
			announcer.setMsg(message);
			announcer.show();
		}
	}

	void OnMouseExit()
	{
		announcer.hide();
	}

	void OnDisable()
	{
		OnMouseExit();
	}
}
