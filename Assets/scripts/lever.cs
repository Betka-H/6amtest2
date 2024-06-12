using UnityEngine;

public class lever : MonoBehaviour, IReset
{
	Animator animator;
	audioManager audioMan;

	public GameObject thisRoom;
	public GameObject cutsceneRoom;

	SpriteRenderer endScreen;

	void Awake()
	{
		// Debug.LogWarning("make lever go back up");
		endScreen = FindObjectOfType<endScreen>(true).GetComponent<SpriteRenderer>();
		endScreen.gameObject.SetActive(false);
		
		animator = GetComponent<Animator>();
		audioMan = FindObjectOfType<audioManager>();
		GetComponent<Collider2D>().enabled = false;
	}

	void OnMouseDown()
	{
		animator.SetTrigger("leave");
		audioMan.playSfx(audioMan.sfxLever);
		GetComponent<Collider2D>().enabled = false;
		Invoke("playCutscene", 1.5f);
		// Debug.Log("l bozo");
		// gameObject.GetComponent<kill>().die(4);
		// endScreen.gameObject.SetActive(true);
		
		endScreen.GetComponent<endScreen>().endThisAll();
	}

	void playCutscene()
	{
		thisRoom.SetActive(false);
		cutsceneRoom.SetActive(true);
	}

	public void resetState()
	{
		FindObjectOfType<menuController>(true).gameObject.SetActive(true);
		endScreen.gameObject.SetActive(false);
	}
}
