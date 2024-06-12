using UnityEngine;

public class paperStack : MonoBehaviour, IReset
{
	audioManager audioMan;
	SpriteRenderer spriteRenderer;
	public Sprite[] stages = new Sprite[3];
	lever lever;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		lever = FindObjectOfType<lever>();
	}

	int clicks = 0;
	void OnMouseDown()
	{
		audioMan.playRandomSfx(audioMan.sfxPaper);
		clicks++;
		spriteRenderer.sprite = stages[clicks];
		if (clicks == stages.Length - 1)
		{
			GetComponent<Collider2D>().enabled = false;
			lever.GetComponent<Collider2D>().enabled = true;
		}
	}

	public void resetState()
	{
		GetComponent<Collider2D>().enabled = true;
		spriteRenderer.sprite = stages[0];
		clicks = 0;
	}
}
