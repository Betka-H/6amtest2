using UnityEngine;

public class safeDigitManager : MonoBehaviour, IReset
{
	safeDigit[] digits;
	public Sprite[] numbers = new Sprite[10];
	public SpriteRenderer[] codeItemSpriterenderers = new SpriteRenderer[4];
	int[] code;

	// bool wasStarted;

	void Awake()
	{
		digits = GetComponentsInChildren<safeDigit>();
		generateCode();
		// wasStarted = true;
	}

	public bool checkState()
	{
		int correctDigits = 0;
		foreach (safeDigit digit in digits)
			if (digit.isCorrect())
				correctDigits++;
		if (correctDigits == digits.Length)
		{
			// Debug.Log("all digits are correct!");
			return false;
		}
		else
			return true;
	}

	void generateCode()
	{
		code = new int[4];
		for (int i = 0; i < 4; i++)
		{
			code[i] = Random.Range(0, 9);
			codeItemSpriterenderers[i].sprite = numbers[code[i]];
		}

		foreach (safeDigit digit in digits)
		{
			digit.setNumber(Random.Range(0, 9));
		}

		Debug.LogWarning("the safe code is " + code[0] + code[1] + code[2] + code[3]);
	}

	public int checkCode(int pos)
	{
		return code[pos];
	}

	public void resetState()
	{
		// if (wasStarted)
		generateCode();
	}
}