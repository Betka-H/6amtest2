using UnityEngine;

public class toggleActive : MonoBehaviour
{
	public GameObject[] things = new GameObject[2];

	public void OnMouseDown()
	{
		if (enabled)
			run();
	}

	public void run()
	{
		foreach (GameObject obj in things)
			obj.SetActive(!obj.activeSelf);
	}
}
