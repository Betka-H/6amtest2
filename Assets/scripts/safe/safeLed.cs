using UnityEngine;

public class safeLed : MonoBehaviour, IReset
{
	SpriteRenderer spriteRenderer;
	public Sprite redSprite;
	public Sprite greenSprite;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		red();
	}

	public void red()
	{
		// spriteRenderer.color = Color.red;
		spriteRenderer.sprite = redSprite;
	}
	public void green()
	{
		// spriteRenderer.color = Color.green;
		spriteRenderer.sprite = greenSprite;
	}

	public void resetState()
	{
		red();
	}
}
