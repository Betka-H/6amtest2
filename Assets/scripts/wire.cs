using UnityEngine;

public class wire : MonoBehaviour, IReset
{
	audioManager audioMan;
	screwManager screwMan;
	SpriteRenderer spriteRenderer;
	public Sprite intactSprite;
	public Sprite cutSprite;
	public item shears;

	Transform[] allWires;
	Transform parent;

	void Start()
	{
		parent = GetComponentInParent<Transform>();
		allWires = parent.GetComponentsInChildren<Transform>();

		audioMan = FindObjectOfType<audioManager>();
		screwMan = FindObjectOfType<screwManager>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = intactSprite;
	}

	void OnMouseDown()
	{
		if (inventory.items.Contains(shears))
		{
			if (screwMan.wireCheck())
			{
				foreach (Transform w in allWires)
				{
					w.gameObject.GetComponent<Collider2D>().enabled = false;
				}
				audioMan.playRandomSfx(audioMan.sfxWireSnip);
				audioMan.playRandomSfx(audioMan.sfxWireSparks);
				spriteRenderer.sprite = cutSprite;
				// GetComponent<Collider2D>().enabled = false;
				// Invoke("explode", Random.Range(1, 3));
				explode();
			}
		}
	}

	void explode()
	{
		Debug.Log("boom");
		audioMan.playSfx(audioMan.sfxExplosion);
		GetComponent<kill>().die(1);
	}

	public void resetState()
	{
		spriteRenderer.sprite = intactSprite;
		GetComponent<Collider2D>().enabled = true;
	}
}
