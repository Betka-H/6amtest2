using UnityEngine;

public class safeDigitArrow : MonoBehaviour
{
	public bool isUp; // if the arrow is changing the number up (true) or down (false)
	safeDigit digit;
	audioManager audioMan;

	void Start()
	{
		audioMan = FindObjectOfType<audioManager>();
		digit = GetComponentInParent<safeDigit>();
	}

	void OnMouseDown()
	{
		audioMan.playSfx(audioMan.sfxSmallButtonPushSingle);
		switch (isUp)
		{
			case true:
				digit.setNumber(digit.getNumber() + 1);
				break;
			case false:
				digit.setNumber(digit.getNumber() - 1);
				break;
		}
	}
}