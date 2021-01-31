using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shoe : Interactable
{
	protected override void OnItemPickup(GameObject go)
	{
		base.OnItemPickup(go);
		TextWriter.WriteText_Static($"{ItemTexts.ItemTextDictionary[Item]}", 0.04f, _text);
	}
}
