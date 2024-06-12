using UnityEngine;

public class safeDigit : MonoBehaviour
{
	safeDigitManager manager;
	bool correct;
	int number;
	[Range(0, 3)]
	public int digitPosition; // specify which digit this is

	public void setNumber(int num)
	{
		manager = GetComponentInParent<safeDigitManager>(true);

		if (num < 0)
			number = 9;
		else if (num > 9)
			number = 0;
		else number = num;

		// Debug.Log(manager);
		GetComponentInChildren<SpriteRenderer>(true).sprite = manager.numbers[number];

		if (number == manager.checkCode(digitPosition))
			correct = true;
		else correct = false;
		//? Debug.Log(gameObject.name + $" ({number}) is correct: " + correct);
	}

	public bool isCorrect()
	{
		return correct;
	}

	public int getNumber()
	{
		return number;
	}
}
