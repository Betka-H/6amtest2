using System.Collections;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class gunArm : MonoBehaviour
{
	public Transform pivot;  // Reference to the pivot transform
	public Camera mainCamera;   // Reference to the main camera
	public GameObject fire;
	private Vector3 mousePosInWorld;

	bool isOnCooldown;
	void Update()
	{
		mousePosInWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition); // convert the mouse coords idk does funky shit without
		if (!isOnCooldown)
		{
			aim();
			if (Input.GetMouseButtonDown(0))
			{
				shoot();
			}
		}
	}

	float angle;
	void aim()
	{
		Vector3 direction = mousePosInWorld - pivot.position; // vector from the pivot to the mouse
		angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // get the angle from the direction vector

		// float dirX;
		if (angle <= 80 && angle >= -69)
		{
			// dirX = direction.x;
			pivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // actually rotate the arm
		}
		/* else
		{
			dirX = -direction.x;
		} */

		// float angle = Mathf.Atan2(direction.y, dirX) * Mathf.Rad2Deg; // get the angle from the direction vector
		// pivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // actually rotate the arm
	}

	public void shoot()
	{
		playFireAnimation();

		summonHole();
		StartCoroutine(cooldown());
	}

	void playFireAnimation()
	{
		fire.GetComponent<gunFire>().fire(); // play the fire shooting animation
	}

	public GameObject holePrefab; // hole prefab. has texture and script to delete it after time/when deactivated
	public Transform holeParent; // layer in which the holes are
	void summonHole()
	{
		GameObject hole = Instantiate(holePrefab);
		hole.transform.SetParent(holeParent, false);
		hole.transform.position = new Vector3(mousePosInWorld.x, mousePosInWorld.y, 0);
	}

	IEnumerator cooldown()
	{
		isOnCooldown = true;
		// StartCoroutine(recoil());
		yield return new WaitForSeconds(0.5f);
		isOnCooldown = false;
	}

	IEnumerator recoil()
	{
		for (float i = 0.1f; i < 10; i *= 1.5f)
		{
			pivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle + i));
			yield return new WaitForSeconds(0.01f);
		}
	}
}