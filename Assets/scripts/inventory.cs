using UnityEngine;
using System.Collections.Generic;

static class inventory
{
	public static List<item> items = new List<item>();

	public static void printItems()
	{
		foreach (item it in items)
		{
			Debug.LogWarning("item: " + it);
		}
	}

	public static void addItem(item item)
	{
		items.Add(item);
	}
	public static void removeItem(item item)
	{
		items.Remove(item);
	}
}