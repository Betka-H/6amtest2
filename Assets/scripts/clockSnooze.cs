using UnityEngine;

public class clockSnooze : MonoBehaviour, IReset
{
	audioManager audioMan;

	int angerThreshold;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
		setAnger();
	}

	int timesClockSnoozed = 0;
	void OnMouseDown()
	{
		audioMan.playSfx(audioMan.sfxButtonPush);

		moveDown();

		Invoke("moveUp", 0.1f);
		timesClockSnoozed++;

		if (timesClockSnoozed == angerThreshold)
		{
			FindObjectOfType<menuController>().gameObject.SetActive(false);
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponentInChildren<explosion>().bang();
			audioMan.playSfx(audioMan.sfxExplosion);
			gameObject.GetComponent<kill>().die(1);

		}
	}

	void setAnger()
	{
		angerThreshold = Random.Range(2, 5);
	}

	// moves up, counts times snoozed + dies
	/* void OnMouseUp()
	{
		moveUp();
		variables.timesClockSnoozed++;
		if (variables.timesClockSnoozed == angerThreshold)
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			gameObject.GetComponentInChildren<explosion>().bang();
			audioMan.playExplosion();
			Invoke("die", 1);
		}
	} */

	float moveAmount = 0.5f; // 0.5f
	void moveDown()
	{
		// vvv prevents being able to click it while its down, making it go down infinitely
		// gameObject.GetComponent<Collider2D>().enabled = false;
		transform.position = transform.position + new Vector3(0, -moveAmount, 0);
	}
	void moveUp()
	{
		transform.position = transform.position + new Vector3(0, moveAmount, 0);
		// vvv prevents being able to click it while its down, making it go down infinitely
		// gameObject.GetComponent<Collider2D>().enabled = true;
	}

	public void resetState()
	{
		setAnger();
		timesClockSnoozed = 0;
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}
}
