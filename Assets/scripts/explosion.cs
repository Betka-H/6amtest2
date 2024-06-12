using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour
{
	public Sprite[] images;

	public void bang()
	{
	//	Debug.Log("*explodes*");
		StartCoroutine(explode());
	}

	IEnumerator explode()
	{
		for (int i = 0; i < images.Length; i++)
		{
			GetComponent<SpriteRenderer>().sprite = images[i];
			yield return new WaitForSeconds(0.05f);
		}
	}
}
