using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour, IReset
{
	public GameObject menu;
	public GameObject menuMain;
	public GameObject[] menuOthers;

	void Start()
	{
		menu.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			toggle();
		}
	}

	void OnMouseDown()
	{
		toggle();
	}

	public void toggle()
	{
		if (!menu.activeSelf) // if active == false
		{
			disableCols();
			open();
		}
		else
		{
			enableCols();
		}
		//? Debug.Log("menu open: " + menu.activeSelf);
		menu.SetActive(!menu.activeSelf);
	}

	// makes it so that every time the menu is opened, the main menu is open and all others are closed
	void open()
	{
		menuMain.SetActive(true);
		foreach (GameObject menu in menuOthers)
		{
			menu.SetActive(false);
		}
	}

	List<Collider2D> activeObjs;
	void disableCols()
	{
		activeObjs = new List<Collider2D>(); // make an empty list
		foreach (Collider2D col in FindObjectsOfType<Collider2D>()) // finds all colliders in the scene
		{
			if (col.isActiveAndEnabled) // only for colliders that are... active and enabled...
			{
				//? Debug.LogError("disabling colliders for " + col.name);
				col.enabled = false;
				activeObjs.Add(col); // note it down to enable it correctly later
			}
		}
		// vvv only thing that would be disabled incorrectly is the hamburger
		gameObject.GetComponent<Collider2D>().enabled = true;
	}
	void enableCols()
	{
		if (activeObjs != null)
			foreach (Collider2D col in activeObjs)
			{
				//? Debug.LogWarning("enabling colliders for " + col.name);
				col.enabled = true;
			}
	}

	public void resetState()
	{
		gameObject.SetActive(false); // disable the menu
		menu.SetActive(false);
		enableCols();
	}
}
