using UnityEngine;
using System.Linq;

public class reset : MonoBehaviour
{
	void OnMouseDown()
	{
		ireset();
	}

	void ireset()
	{
		Debug.Log("resetting game");
		IReset[] iresets = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<IReset>().ToArray();

		foreach (IReset obj in iresets)
		{
			//? Debug.Log("resetting " + obj);
			obj.resetState();
		}
	}
}
