using UnityEngine;

public class gameManager : MonoBehaviour
{
	public void saveBool(string name, bool value)
	{
		if (value)
			PlayerPrefs.SetString(name, "true");
		else
			PlayerPrefs.SetString(name, "false");
		PlayerPrefs.Save();
	}

	public bool loadBool(string name)
	{
		if (PlayerPrefs.GetString(name) == "true")
			return true;
		else
			return false;
	}

	public void saveString(string name, string value)
	{
		PlayerPrefs.SetString(name, value);
		PlayerPrefs.Save();
	}

	public void saveInt(string name, int value)
	{
		PlayerPrefs.SetInt(name, value);
		PlayerPrefs.Save();
	}

	public void saveFloat(string name, float value)
	{
		PlayerPrefs.SetFloat(name, value);
		PlayerPrefs.Save();
	}
}
