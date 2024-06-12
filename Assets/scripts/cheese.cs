using UnityEngine;

public class cheese : MonoBehaviour
{
	audioManager audioMan;
	kill kill;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
		kill = GetComponent<kill>();
	}

	void OnMouseDown()
	{
		audioMan.playSfx(audioMan.sfxCheese);
		kill.die(2);
	}
}
