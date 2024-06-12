using UnityEngine;

public class room : MonoBehaviour, IReset
{
	public bool setActiveAtStart = false;

	void Start()
	{
		gameObject.SetActive(setActiveAtStart);
	}

	public void resetState()
	{
		Start();
	}
}
