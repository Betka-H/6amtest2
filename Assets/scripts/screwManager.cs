using System.Collections;
using UnityEngine;

public class screwManager : MonoBehaviour, IReset
{
	screw[] screws;
	int screwsScrewed;
	public GameObject front;
	Vector3 frontOriginalPos;
	Quaternion frontOriginalRot;

	public item screwdriver;

	void Awake()
	{
		screwsScrewed = 0;
		screws = GetComponentsInChildren<screw>();

		frontOriginalPos = front.transform.position;
		frontOriginalRot = front.transform.rotation;
	}

	bool isRevealed;
	public void screwScrew()
	{
		screwsScrewed++;
		if (screwsScrewed == screws.Length)
		{
			isRevealed = true;
			makeFall(front);
		}
	}

	public void makeFall(GameObject obj)
	{
		StartCoroutine(fall(obj));
	}

	IEnumerator fall(GameObject obj)
	{
		for (float i = 0.1f; i < 5; i *= 1.2f)
		{
			yield return new WaitForSeconds(0.01f);
			rotate(obj, -2 - i / 2);
			obj.transform.position -= new Vector3(0, i, 0);
		}
		obj.SetActive(false);
	}

	public void rotate(GameObject obj, float rotation)
	{
		Vector3 axis = new Vector3(0, 0, 1); // define the rotation axis (z in this case)
		obj.transform.Rotate(axis, rotation); // rotate around the axis
	}

	public bool wireCheck()
	{
		return isRevealed;
	}

	public void resetState()
	{
		isRevealed = false;

		screwsScrewed = 0;

		front.transform.position = frontOriginalPos;
		front.transform.rotation = frontOriginalRot;
		front.SetActive(true);
	}
}
