using UnityEngine;
using System.Collections;

public class gunFire : MonoBehaviour
{
	public Sprite[] images;

	public void fire()
	{
		StartCoroutine(bang());
	}

	IEnumerator bang()
	{
		for (int i = 0; i < images.Length; i++)
		{
			GetComponent<SpriteRenderer>().sprite = images[i];
			yield return new WaitForSeconds(0.05f);
		}
	}
}
